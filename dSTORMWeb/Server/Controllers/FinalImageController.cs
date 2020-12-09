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
    public class FinalImageController : Controller
    {
        private readonly DataManager _dm;
        public FinalImageController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetFinalImage/{id}")]
        public async Task<IActionResult> GetFinalImage([FromRoute] int id)
        {
            try
            {
                var item = await _dm.FinalImageAccessor.GetFinalImage(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                FinalImageViewModel model = item.ToFinalImageViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetFinalImages")]
        public async Task<JsonResult> GetFinalImages([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuilddSTORMFilters(this.HttpContext);

            var count = await _dm.FinalImageAccessor.GetFinalImagesCount();
            var list = await _dm.FinalImageAccessor.GetFinalImages(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    format = e.Format,
                    resolution = e.Resolution,
                    initialvideoname = e.InitialVideo.Name,
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
                    Items = new List<FinalImageEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] FinalImageViewModel model)
        {
            try
            {
                FinalImageEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.FinalImageAccessor.GetFinalImageS(model.InitialVideoId);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new FinalImageEntity();
                }
                else
                {
                    entity = await _dm.FinalImageAccessor.GetFinalImage(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToFinalImageEntity();

                var savedItem = await _dm.FinalImageAccessor.SaveFinalImage(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success, Description = savedItem.Id.ToString() });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

        [Route("initialvideos")]
        public async Task<JsonResult> Getinitialvideos([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildAOTFilterFilters(this.HttpContext);
            var items = await _dm.InitialVideoAccessor.GetInitialVideos(filters, 0, 1000, "");
            foreach(var item in items)
            {
                item.VideoBlob = new byte[0];
            }
            if (IsFilter)
                items.Add(new InitialVideoEntity() { Id = -1, Name = "All" });
            return Json(items);
        }
    }
}
