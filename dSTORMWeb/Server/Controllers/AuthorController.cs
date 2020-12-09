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
    public class AuthorController : Controller
    {
        private readonly DataManager _dm;
        public AuthorController(DataManager dm)
        {
            _dm = dm;
        }

        [HttpGet]
        [Route("GetAuthor/{id}")]
        public async Task<IActionResult> GetAuthor([FromRoute] int id)
        {
            try
            {
                var item = await _dm.AuthorAccessor.GetAuthor(id);

                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });


                AuthorViewModel model = item.ToAuthorViewModel();

                return Ok(model);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }
        [Route("GetAuthors")]
        public async Task<JsonResult> GetAuthors([FromQuery(Name = "$skip")] int skip = 0, [FromQuery(Name = "$top")] int top = 20,
                    [FromQuery(Name = "$orderby")] string sortfield = "name")
        {
            var filters = FilterHelper.BuildAuthorFilters(this.HttpContext);
            var count = await _dm.AuthorAccessor.GetAuthorsCount();
            var list = await _dm.AuthorAccessor.GetAuthors(filters, skip, top, sortfield);



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    firstname = e.FirstName,
                    academicrank = e.AcademicRank,
                    middlename = e.MiddleName,
                    lastname = e.LastName,
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
                    Items = new List<AuthorEntity>()
                };
                return Json(result);
            }
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] AuthorViewModel model)
        {
            try
            {
                AuthorEntity entity = null;
                if (!ModelState.IsValid)
                    return Ok(new ResponseModel() { Result = ResultCode.NotValidData });
                if (model.Id <= 0)
                {
                    entity = new AuthorEntity();
                }
                else
                {
                    entity = await _dm.AuthorAccessor.GetAuthor(model.Id);
                    if (entity == null)
                        return Ok(new ResponseModel()
                        { Result = ResultCode.AlreadyExists });

                }
                var entityToSave = model.ToAuthorEntity();

                await _dm.AuthorAccessor.SaveAuthor(entityToSave);

                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError, Description = ex.Message });
            }
        }

        /*[HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] au model)
        {
            try
            {
                var item = await _dm.AOTFilterAccessor.GetAOTFilter(model.Id);
                if (item == null)
                    return Ok(new ResponseModel() { Result = ResultCode.NotFound });

                await _dm.AOTFilterAccessor.DeletFilter(item.Id);
                return Ok(new ResponseModel() { Result = ResultCode.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { Result = ResultCode.ServerError });
            }
        }*/
    }

}
