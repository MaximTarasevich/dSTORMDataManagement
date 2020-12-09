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
    public class InitialVideoController : Controller
    {
        private readonly DataManager _dm;

        public InitialVideoController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetInitialVideo/{id}")]
        public async Task<IActionResult> GetInitialVideo([FromRoute] int id)
        {
            try
            {
                var item = await _dm.InitialVideoAccessor.GetInitialVideo(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                InitialVideoViewModel model = item.ToInitialVideoViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetInitialVideos")]
        public async Task<JsonResult> GetInitialVideos([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildInitialVideoFilters(this.HttpContext);
            var count = await _dm.InitialVideoAccessor.GetInitialVideosCount();
            var list = await _dm.InitialVideoAccessor.GetInitialVideos(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    name = e.Name,
                    format = e.Format,
                    resolution = e.Resolution,
                    framefrequency = e.FrameFrequency,
                    size = e.Size,
                    duration = e.Duration,
                    descriptionform = e.Description

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
                    Items = new List<InitialVideoEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] InitialVideoViewModel model)
        {
            try
            {
                InitialVideoEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                //var item = await _dm.InitialVideoAccessor.GetInitialVideo(model.Producer, model.Model);
                //if (item != null && item.Id != model.Id)
                //    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new InitialVideoEntity();
                }
                else
                {
                    entity = await _dm.InitialVideoAccessor.GetInitialVideo(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToInitialVideoEntity();

                var savedItem = await _dm.InitialVideoAccessor.SaveInitialVideo(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success, Description = savedItem.Id.ToString() }); ;
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] CameraViewModel model)
        {
            try
            {
                var item = await _dm.CameraAccessor.GetCamera(model.Id);
                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });

                await _dm.CameraAccessor.DeleteCamera(item.Id);
                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError });
            }
        }

        [Route("author")]
        public async Task<JsonResult> GetAuthors([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildAuthorFilters(this.HttpContext);
            var items = (await _dm.AuthorAccessor.GetAuthors(filters, 0, 1000, "")).ToAuthorViewModelCollection().ToList();
            if (IsFilter)
                items.Add(new AuthorViewModel() { Id = -1, FullName = "All" });
            return Json(items);
        }
    }
}
