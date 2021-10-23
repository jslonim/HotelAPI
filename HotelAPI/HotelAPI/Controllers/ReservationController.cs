﻿using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.DTO.Output;
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
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Route("CheckAvailability")]
        public ActionResult CheckRoomAvailability()
        {
            try
            {
                List<CheckRoomAvailabilityOutputDTO> reservationList = _reservationService.CheckRoomAvailability();
                return Ok(reservationList);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
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
        public ActionResult Update(UpdateReservationInputDTO reservationDTO)
        {
            try
            {
                _reservationService.UpdateReservation(reservationDTO);
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
            catch (ReservationNotExistentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
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
