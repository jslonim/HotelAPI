using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.Exceptions;
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

        [HttpGet]
        [Route("GetMyReservations")]
        public ActionResult GetMyReservations()
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
            catch (DayLimitException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DaysInAdvanceException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (ReservedException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception)
            {
                return StatusCode(500);
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
        public ActionResult Delete(int id)
        {
            try
            {
                _reservationService.DeleteReservation(id);
                return Ok();
            }
            catch (ReservationNotExistentException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
