using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin_API.Models;
using Admin_API.ServiceContract;
using Admin_API.Services;
using Admin_API.TokenModels;
using Admin_API.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private ICountry_Repository _ICountry_Repository;
        public CountryController()
        {
            _ICountry_Repository = new Country_Repository();
        }
        // GET: api/Country
        [HttpGet]
        public IActionResult GetCountryMaster()
        {
            var data = _ICountry_Repository.GetAll().Result;
            return Ok(APIResponse.SetResponse(APIResponseStatus.Ok, "Country List", APIOpStatus.Success, data));
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        [AuthorizeUser(Roles = "A")]
        public async Task<IActionResult> GetCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState.ResponseValidation());
            try
            {
                var obj = await _ICountry_Repository.GetById(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return Ok(APIResponse.SetResponse(APIResponseStatus.Ok, "Country get successfully", APIOpStatus.Success, obj));
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SetResponse(APIResponseStatus.Error, ex.Message, APIOpStatus.Error, null));
            }
        }

        // POST: api/Country
        [HttpPost]
        [AuthorizeUser(Roles = "A")]
        public async Task<IActionResult> PostCountry([FromBody] CountryMaster obj)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState.ResponseValidation());

            obj.IsActive = true;
            await _ICountry_Repository.Insert(obj);
            return Ok(APIResponse.SetResponse(APIResponseStatus.Ok, "Country save successfully.", APIOpStatus.Success, obj));
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        [AuthorizeUser(Roles = "A")]
        public async Task<IActionResult> PutCountry([FromRoute] int id, [FromBody] CountryMaster obj)
        {
            obj.CountryId = id;
            if (!ModelState.IsValid)
                return Ok(ModelState.ResponseValidation());

            if (id != obj.CountryId)
                return BadRequest();
            try
            {
                obj.IsActive = true;
                await _ICountry_Repository.Update(obj);
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SetResponse(APIResponseStatus.Error, ex.Message, APIOpStatus.Error, null));
            }
            return Ok(APIResponse.SetResponse(APIResponseStatus.Ok, "Country updated successfully.", APIOpStatus.Success, obj));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [AuthorizeUser(Roles = "A")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            try
            {
                return Ok(APIResponse.SetResponse(APIResponseStatus.Ok, "Country deleted successfully.", APIOpStatus.Success, await _ICountry_Repository.Delete(id)));
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.SetResponse(APIResponseStatus.Error, ex.Message, APIOpStatus.Error, null));
            }
        }
    }
}
