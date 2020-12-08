using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL;
using dSTORMWeb.Server.Converters;
using dSTORMWeb.Server.Helpers;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Enums;
using dSTORMWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace dSTORMWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalPropertyController : Controller
    {
        private readonly DataManager _dm;

        public PhysicalPropertyController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetPhysicalProperty/{id}")]
        public async Task<IActionResult> GetPhysicalProperty([FromRoute] int id)
        {
            try
            {
                var item = await _dm.PhysicalPropertiesAccessor.GetPhysicalProperty(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                PhysicalPropertyViewModel model = item.ToPhysicalPropertyViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetPhysicalProperties")]
        public async Task<JsonResult> GetPhysicalProperties([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildPhysicalPropertiesFilters(this.HttpContext);
            var count = await _dm.PhysicalPropertiesAccessor.GetPhysicalPropertiesCount();
            var list = await _dm.PhysicalPropertiesAccessor.GetPhysicalProperties(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    temperature = e.Temperature,
                    humidity = e.Humidity,

                }).ToList();

                var result = new
                {
                    Count = count,
                    Items = usersPagedData
                };
                return Json(result);
            }
            else
            {
                var result = new
                {
                    Count = 0,
                    Items = new List<MicroscopeEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] PhysicalPropertyViewModel model)
        {
            try
            {
                PhysicalPropertyEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.PhysicalPropertiesAccessor.GetPhysicalProperty(model.Humidity, model.Temperature);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new PhysicalPropertyEntity();
                }
                else
                {
                    entity = await _dm.PhysicalPropertiesAccessor.GetPhysicalProperty(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToPhysicalPropertyEntity();

                await _dm.PhysicalPropertiesAccessor.SavePhysicalProperty(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteItem([FromBody] PhysicalPropertyViewModel model)
        {
            try
            {
                var item = await _dm.PhysicalPropertiesAccessor.GetPhysicalProperty(model.Id);
                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });

                await _dm.PhysicalPropertiesAccessor.DeletePhysicalPropertyItem(item.Id);
                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError });
            }
        }
    }
}
