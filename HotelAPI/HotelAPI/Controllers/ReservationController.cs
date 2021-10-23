using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.Interfaces;
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
        public IReservationService _reservationService { get; set; }
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Route("CheckAvailability")]
        public ActionResult CheckRoomAvailability()
        {
            return Ok("Test");
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(CreateReservationInputDTO reservationDTO) 
        {
            try
            {
                _reservationService.CreateReservation(reservationDTO);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update()
        {
            return Ok("Test");
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete()
        {
            return Ok("Test");
        }
    }
}
