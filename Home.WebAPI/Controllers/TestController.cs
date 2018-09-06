using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Home.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class TestController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post( TestModel tm)
        {
            if (ModelState.IsValid)
            {
                return Ok("Valid Model");
            }
            else
            {
                return BadRequest("Invalid Model");
            }
        }
    }

    public class TestModel
    {
        [Required]
        public string Test { get; set; }
        
    }
}