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
    public class FluorophoreController : Controller
    {
        private readonly DataManager _dm;

        public FluorophoreController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetFluorophore/{id}")]
        public async Task<IActionResult> GetFluorophore([FromRoute] int id)
        {
            try
            {
                var item = await _dm.FluorophoreAccessor.GetFluorophore(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                FluorophoreViewModel model = item.ToFluorophoreViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetFluorophores")]
        public async Task<JsonResult> GetFluorophore([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildFluorophoreFilter(this.HttpContext);
            var count = await _dm.FluorophoreAccessor.GetFluorophoresCount();
            var list = await _dm.FluorophoreAccessor.GetFluorophores(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    name = e.Name,
                    Class = e.Class,
                    absorption = e.Absorption,
                    emission = e.Emission,

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
                    Items = new List<FluorophoreEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] FluorophoreViewModel model)
        {
            try
            {
                FluorophoreEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.FluorophoreAccessor.GetFluorophore(model.Name);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new FluorophoreEntity();
                }
                else
                {
                    entity = await _dm.FluorophoreAccessor.GetFluorophore(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToFluorophoreEntity();

                await _dm.FluorophoreAccessor.SaveFluorophore(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

    }
}
