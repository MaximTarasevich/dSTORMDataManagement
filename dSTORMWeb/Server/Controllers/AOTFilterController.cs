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
    public class AOTFilterController : Controller
    {
        private readonly DataManager _dm;

        public AOTFilterController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetFilter/{id}")]
        public async Task<IActionResult> GetFilter([FromRoute] int id)
        {
            try
            {
                var item = await _dm.AOTFilterAccessor.GetAOTFilter(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                AOTFilterViewModel model = item.ToAOTFilterViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetFilters")]
        public async Task<JsonResult> GetFilters([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildAOTFilterFilters(this.HttpContext);
            var count = await _dm.AOTFilterAccessor.GetAOTFiltersCount();
            var list = await _dm.AOTFilterAccessor.GetAOTFilters(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    name = e.Name,
                    intensityvalue = e.IntensityValue,
                    descriptionFORM = e.Description,
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
                    Items = new List<AOTFilterEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] AOTFilterViewModel model)
        {
            try
            {
                AOTFilterEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.AOTFilterAccessor.GetAOTFilter(model.Name);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new AOTFilterEntity();
                }
                else
                {
                    entity = await _dm.AOTFilterAccessor.GetAOTFilter(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToAOTFilterEntity();

                await _dm.AOTFilterAccessor.SaveAOTFilter(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] AOTFilterViewModel model)
        {
            try
            {
                var item = await _dm.AOTFilterAccessor.GetAOTFilter(model.Id);
                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });

                await _dm.AOTFilterAccessor.DeletFilter(item.Id);
                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError });
            }
        }
    }
}
