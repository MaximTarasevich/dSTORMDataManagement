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
    public class CameraController : Controller
    {
        private readonly DataManager _dm;

        public CameraController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetCamera/{id}")]
        public async Task<IActionResult> GetCamera([FromRoute] int id)
        {
            try
            {
                var item = await _dm.CameraAccessor.GetCamera(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                CameraViewModel model = item.ToCameraViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetCameras")]
        public async Task<JsonResult> GetCameras([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildCameraFilters(this.HttpContext);
            var count = await _dm.CameraAccessor.GetCamerasCount();
            var list = await _dm.CameraAccessor.GetCameras(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    model = e.Model,
                    objective = e.Objective,
                    producer = e.Producer,
                    focallength = e.FocalLength,
                    matrixtype = e.MatrixType,
                    descriptionform = e.Description,

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
                    Items = new List<CameraEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] CameraViewModel model)
        {
            try
            {
                CameraEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.CameraAccessor.GetCamera(model.Producer, model.Model);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new CameraEntity();
                }
                else
                {
                    entity = await _dm.CameraAccessor.GetCamera(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToCameraEntity();

                await _dm.CameraAccessor.SaveCamera(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
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
    }
}
