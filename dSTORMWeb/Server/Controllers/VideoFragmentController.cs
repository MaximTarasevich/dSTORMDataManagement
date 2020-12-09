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
    public class VideoFragmentController : Controller
    {
        private readonly DataManager _dm;

        public VideoFragmentController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetVideoFragment/{id}")]
        public async Task<IActionResult> GetVideoFragment([FromRoute] int id)
        {
            try
            {
                var item = await _dm.VideoFragmentAccessor.GetVideoFragment(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                VideoFragmentViewModel model = item.ToVideoFragmentViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetVideoFragments")]
        public async Task<JsonResult> GetVideoFragments([FromQuery(Name = "initialVideoId")] int initialVideoId = 0, [FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildSetupFilters(this.HttpContext);

            filters.Add("InitialVideoId", new FilterEntity() { Name = "InitialVideoId", Type = FilterType.String, Value = new List<string>() { initialVideoId.ToString() } });
            var count = await _dm.VideoFragmentAccessor.GetVideoFragmentCount();
            var list = await _dm.VideoFragmentAccessor.GetVideoFragments(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    frametime = e.FrameTime

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
                    Items = new List<VideoFragmentEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] VideoFragmentViewModel model)
        {
            try
            {
                VideoFragmentEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.VideoFragmentAccessor.GetVideoFragment(model.InitialVideoId,model.FrameTime);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new VideoFragmentEntity();
                }
                else
                {
                    entity = await _dm.VideoFragmentAccessor.GetVideoFragment(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToVideoFragmentEntity();

                var savedItem = await _dm.VideoFragmentAccessor.SaveVideoFragment(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success,Description = savedItem.Id.ToString() });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }


    }
}