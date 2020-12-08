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
    public class MicroscopeController : Controller
    {
        private readonly DataManager _dm;

        public MicroscopeController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetMicroscope/{id}")]
        public async Task<IActionResult> GetMicroscope([FromRoute] int id)
        {
            try
            {
                var item = await _dm.MicroscopeAccessor.GetMicroscope(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                MicroscopeViewModel model = item.ToMicroscopeViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetMicroscopes")]
        public async Task<JsonResult> GetMicroscopes([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildMicroscopeFilters(this.HttpContext);
            var count = await _dm.MicroscopeAccessor.GetMicroscopesCount();
            var list = await _dm.MicroscopeAccessor.GetMicroscopes(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    model = e.Model,
                    type = e.Type,
                    producer = e.Producer,

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
        public async Task<IActionResult> Save([FromBody] MicroscopeViewModel model)
        {
            try
            {
                MicroscopeEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.MicroscopeAccessor.GetMicroscope(model.Producer, model.Model, model.Type);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new MicroscopeEntity();
                }
                else
                {
                    entity = await _dm.MicroscopeAccessor.GetMicroscope(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToMicroscopeEntity();

                await _dm.MicroscopeAccessor.SaveMicroscope(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteMicroscopeItem([FromBody] MicroscopeViewModel model)
        {
            try
            {
                var item = await _dm.MicroscopeAccessor.GetMicroscope(model.Id);
                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });

                await _dm.MicroscopeAccessor.DeleteMicroscopeItem(item.Id);
                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError });
            }
        }
    }
}
