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
    public class SetupController : Controller
    {
        private readonly DataManager _dm;

        public SetupController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetSetup/{id}")]
        public async Task<IActionResult> GetSetup([FromRoute] int id)
        {
            try
            {
                var item = await _dm.SetupAccessor.GetSetup(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                SetupViewModel model = item.ToSetupViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetSetups")]
        public async Task<JsonResult> GetSetups([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildSetupFilters(this.HttpContext);
            var count = await _dm.SetupAccessor.GetSetupsCount();
            var list = await _dm.SetupAccessor.GetSetups(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    filtername =e.AOTFilter.Name,
                    cameraname = e.Camera.Producer,
                    objectivename = e.Objective.Name,
                    lasername = e.Laser.Producer,
                    microscopename = e.Microscope.Producer

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
                    Items = new List<SetupEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] SetupViewModel model)
        {
            try
            {
                SetupEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.SetupAccessor.GetSetup(model.AOTFilterId,model.CameraId,model.LaserId,model.MicroscopeId,model.ObjectiveId);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new SetupEntity();
                }
                else
                {
                    entity = await _dm.SetupAccessor.GetSetup(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToSetupEntity();

                await _dm.SetupAccessor.SaveSetup(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }



        [Route("aotfilters")]
        public async Task<JsonResult> GetFiltersForSelector([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildAOTFilterFilters(this.HttpContext);
            var items = await _dm.AOTFilterAccessor.GetAOTFilters(filters, 0, 1000, "");
            if (IsFilter)
                items.Add(new AOTFilterEntity() { Id = -1, Name = "All" });
            return Json(items);
        }
        [Route("cameras")]
        public async Task<JsonResult> GetCamerasForSelector([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildAOTFilterFilters(this.HttpContext);
            var items = (await _dm.CameraAccessor.GetCameras(filters, 0, 1000, "")).ToCameraViewModelCollection().ToList();
            if (IsFilter)
                items.Add(new CameraViewModel() { Id = -1, Name = "All" });
            return Json(items);
        }
        [Route("objectives")]
        public async Task<JsonResult> GetObjectivesForSelector([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildAOTFilterFilters(this.HttpContext);
            var items = await _dm.ObjectiveAccessor.GetObjectives(filters, 0, 1000, "");
            if (IsFilter)
                items.Add(new ObjectiveEntity() { Id = -1, Name = "All" });
            return Json(items);
        }
        [Route("lasers")]
        public async Task<JsonResult> GetLasersForSelector([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildAOTFilterFilters(this.HttpContext);
            var items = (await _dm.LaserAccessor.GetLasers(filters, 0, 1000, "")).ToLaserViewModelCollection().ToList();
            if (IsFilter)
                items.Add(new LaserViewModel() { Id = -1, Name = "All" });
            return Json(items);
        }
        [Route("microscopes")]
        public async Task<JsonResult> GetMicroscopesForSelector([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildAOTFilterFilters(this.HttpContext);
            var items = (await _dm.MicroscopeAccessor.GetMicroscopes(filters, 0, 1000, "")).ToMicroscopeViewModelCollection().ToList();
            if (IsFilter)
                items.Add(new MicroscopeViewModel() { Id = -1, Name = "All" });
            return Json(items);
        }
    }
}
