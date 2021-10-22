using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public ReservationController()
        {

        }

        [HttpGet]
        [Route("CheckAvailability")]
        public async Task<ActionResult> CheckRoomAvailability()
        {
            return Ok("Test");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create() 
        {
            return Ok("Test");
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update()
        {
            return Ok("Test");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete()
        {
            return Ok("Test");
        }
    }
}
