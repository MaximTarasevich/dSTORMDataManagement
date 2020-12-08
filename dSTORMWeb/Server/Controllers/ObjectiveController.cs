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
    public class ObjectiveController : Controller
    {
        private readonly DataManager _dm;

        public ObjectiveController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetObjective/{id}")]
        public async Task<IActionResult> GetObjective([FromRoute] int id)
        {
            try
            {
                var item = await _dm.ObjectiveAccessor.GetObjective(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                ObjectiveViewModel model = item.ToObjectiveViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetObjectives")]
        public async Task<JsonResult> GetObjectives([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildObjectiveFilters(this.HttpContext);
            var count = await _dm.ObjectiveAccessor.GetObjectivesCount();
            var list = await _dm.ObjectiveAccessor.GetObjectives(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    name = e.Name,
                    magnification = e.Magnification,
                    resolution = e.Resolution,
                    eyepiece = e.EyePiece,
                    objectivelens = e.ObjectiveLens,
                    description = e.Description
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
                    Items = new List<ObjectiveEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] ObjectiveViewModel model)
        {
            try
            {
                ObjectiveEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                if (model.Id <= 0)
                {
                    entity = new ObjectiveEntity();
                }
                else
                {
                    entity = await _dm.ObjectiveAccessor.GetObjective(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToObjectiveEntity();

                await _dm.ObjectiveAccessor.SaveObjective(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] ObjectiveViewModel model)
        {
            try
            {
                var item = await _dm.ObjectiveAccessor.GetObjective(model.Id);
                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });

                await _dm.ObjectiveAccessor.DeleteItem(item.Id);
                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError });
            }
        }
    }
}
