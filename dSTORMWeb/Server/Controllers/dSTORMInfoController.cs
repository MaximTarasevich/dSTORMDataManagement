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
    public class dSTORMInfoController : Controller
    {
        private readonly DataManager _dm;
        public dSTORMInfoController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetdSTORMInfoItem/{id}")]
        public async Task<IActionResult> GetdSTORMInfoItem([FromRoute] int id)
        {
            try
            {
                var item = await _dm.dSTORMInfoAccessor.GetdSTORMInfo(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                dSTORMInfoViewModel model = item.TodSTORMInfoViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetdSTORMInfoItems")]
        public async Task<JsonResult> GetdSTORMInfoItems([FromQuery(Name = "videoFragmentId")] int videoFragmentId = 0,[FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuilddSTORMFilters(this.HttpContext);

            filters.Add("VideoFragmentId", new FilterEntity() { Name = "VideoFragmentId", Type = FilterType.String, Value = new List<string>() { videoFragmentId.ToString() } });

            var count = await _dm.dSTORMInfoAccessor.GetdSTORMInfosCount();
            var list = await _dm.dSTORMInfoAccessor.GetdSTORMInfos(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    xcoord = e.XCoord,
                    ycoord = e.YCoord,
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
                    Items = new List<dSTORMInfoEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] dSTORMInfoViewModel model)
        {
            try
            {
                dSTORMInfoEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.dSTORMInfoAccessor.GetdSTORMInfo(model.XCoord, model.YCoord,model.VideoFragmentId);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new dSTORMInfoEntity();
                }
                else
                {
                    entity = await _dm.dSTORMInfoAccessor.GetdSTORMInfo(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.TodSTORMInfoEntity();

                var savedItem = await _dm.dSTORMInfoAccessor.SavedSTORMInfo(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success, Description = savedItem.Id.ToString() });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
    }
}
