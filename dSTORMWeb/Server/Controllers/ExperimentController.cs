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
    public class ExperimentController : Controller
    {
        private readonly DataManager _dm;

        public ExperimentController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetExperiment/{id}")]
        public async Task<IActionResult> GetExperiment([FromRoute] int id)
        {
            try
            {
                var item = await _dm.ExperimentAccessor.GetExperiment(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                ExperimentViewModel model = item.ToExperimentViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetExperiments")]
        public async Task<JsonResult> GetExperiment([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildSetupFilters(this.HttpContext);
            var count = await _dm.ExperimentAccessor.GetExperimentsCount();
            var list = await _dm.ExperimentAccessor.GetExperiments(filters, skip, top, sortfield);



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
                    Items = new List<ExperimentEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] ExperimentViewModel model)
        {
            try
            {
                ExperimentEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                var item = await _dm.ExperimentAccessor.GetExperiment(model.SetupId, model.ResearchObjectId, model.FluorophoreId, model.PhysicalPropertyId);
                if (item != null && item.Id != model.Id)
                    return Ok(new ResponseModel() { Result = ResultCode.AlreadyExists });
                if (model.Id <= 0)
                {
                    entity = new ExperimentEntity();
                }
                else
                {
                    entity = await _dm.ExperimentAccessor.GetExperiment(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToExperimentEntity();

                await _dm.ExperimentAccessor.SaveExperiment(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }



        [Route("physicalproperties")]
        public async Task<JsonResult> GetPhProp([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildPhysicalPropertiesFilters(this.HttpContext);
            var items = (await _dm.PhysicalPropertiesAccessor.GetPhysicalProperties(filters, 0, 1000, "")).ToPhysicalPropertyViewModelCollection().ToList();
            if (IsFilter)
                items.Add(new PhysicalPropertyViewModel() { Id = -1, Name = "All" });
            return Json(items);
        }
        [Route("fluorophores")]
        public async Task<JsonResult> GetFluorophores([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildFluorophoreFilter(this.HttpContext);
            var items = await _dm.FluorophoreAccessor.GetFluorophores(filters, 0, 1000, "");
            if(IsFilter)
                items.Add(new FluorophoreEntity() { Id = -1, Name = "All" });
            return Json(items);
        }
        [Route("researchobjects")]
        public async Task<JsonResult> GetResearchObjects([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildFluorophoreFilter(this.HttpContext);
            var items = await _dm.ResearchObjectAccessor.GetResearchObjects(filters, 0, 1000, "");
            if (IsFilter)
                items.Add(new ResearchObjectEntity() { Id = -1, Name = "All" });
            return Json(items);
        }
        [Route("setups")]
        public async Task<JsonResult> GetSetups([FromQuery(Name = "isFilter")] bool IsFilter = false)
        {
            var filters = FilterHelper.BuildAOTFilterFilters(this.HttpContext);
            var items = (await _dm.SetupAccessor.GetSetups(filters, 0, 1000, "")).ToSetupViewModelCollection().ToList();
            if (IsFilter)
                items.Add(new SetupViewModel() { Id = -1, Name = "All" });
            return Json(items);
        }
    }
}
