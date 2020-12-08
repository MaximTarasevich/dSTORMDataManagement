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
    public class LaserController : Controller
    {
        private readonly DataManager _dm;

        public LaserController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetLaser/{id}")]
        public async Task<IActionResult> GetLaser([FromRoute] int id)
        {
            try
            {
                var item = await _dm.LaserAccessor.GetLaser(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                LaserViewModel model = item.ToLaserViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetLasers")]
        public async Task<JsonResult> GetLasers([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildLaserFilter(this.HttpContext);
            var count = await _dm.LaserAccessor.GetLaserCount();
            var list = await _dm.LaserAccessor.GetLasers(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    model = e.Model,
                    type = e.Type,
                    producer = e.Producer,
                    wavelength = e.WaveLength,
                    maxpower = e.MaxPower,
                    outputpower = e.OutputPower,
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
                    Items = new List<LaserEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] LaserViewModel model)
        {
            try
            {
                LaserEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.LaserAccessor.GetLaser(model.Producer, model.Model, model.Type);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new LaserEntity();
                }
                else
                {
                    entity = await _dm.LaserAccessor.GetLaser(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToLaserEntity();

                await _dm.LaserAccessor.SaveLaser(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] LaserViewModel model)
        {
            try
            {
                var item = await _dm.LaserAccessor.GetLaser(model.Id);
                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });

                await _dm.LaserAccessor.DeleteLaser(item.Id);
                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError });
            }
        }
    }
}
