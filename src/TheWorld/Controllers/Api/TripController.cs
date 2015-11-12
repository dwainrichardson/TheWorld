using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TheWorld.Services;
using TheWorld.Models;
using System.Net;
using TheWorld.ViewModels;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld.Controllers.Api
{
    [Route("api/[controller]")]
    public class TripController : Controller
    {

        private IWorldRepository _repository;

        public TripController(IWorldRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_repository.GetAllTrips());

               // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]TripViewModel value)
        {
            //Trip nt = new Trip()
            //{
            //    Created = DateTime.Now,
            //    TripName = "My trip",
            //    UserName = "dwainrichardson",
            //    TripId = 1
            //};
       

            if (!ModelState.IsValid)
            {

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = "Failed", ModelState = ModelState });
            }
            else
            {
              //  var trip = Mapper.Map<Trip>(value);
                //  _repository.AddTrip(value);

                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json("SUCCESS");
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
