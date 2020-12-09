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
    public class ResearchObjectController : Controller
    {
        private readonly DataManager _dm;

        public ResearchObjectController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetResearchObject/{id}")]
        public async Task<IActionResult> GetResearchObject([FromRoute] int id)
        {
            try
            {
                var item = await _dm.ResearchObjectAccessor.GetResearchObject(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                ResearchObjectViewModel model = item.ToResearchObjectViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetResearchObjects")]
        public async Task<JsonResult> GetResearchObjects([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildSetupFilters(this.HttpContext);
            var count = await _dm.ResearchObjectAccessor.GetResearchObjectsCount();
            var list = await _dm.ResearchObjectAccessor.GetResearchObjects(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    name = e.Name

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
                    Items = new List<ResearchObjectEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] ResearchObjectViewModel model)
        {
            try
            {
                ResearchObjectEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.ResearchObjectAccessor.GetResearchObject(model.Name);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new ResearchObjectEntity();
                }
                else
                {
                    entity = await _dm.ResearchObjectAccessor.GetResearchObject(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToPhysicalPropertyEntity();

                await _dm.ResearchObjectAccessor.SaveResearchObject(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }


    }
}
