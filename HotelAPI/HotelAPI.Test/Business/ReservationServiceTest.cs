using AutoMapper;
using HotelAPI.Business;
using HotelAPI.Business.DTO.Output;
using HotelAPI.Business.Interfaces;
using HotelAPI.Data.Entities;
using HotelAPI.Data.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HotelAPI.Test.Business
{
    [TestFixture]
    public class ReservationServiceTest
    {
        private ReservationService _reservationService;
        Mock<IReservationRepository> _reservationRepository;
        Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _mapper = new Mock<IMapper>();
            _reservationRepository = new Mock<IReservationRepository>();
            _reservationService = new ReservationService(_reservationRepository.Object, _mapper.Object);
        }

        [Test]
        public void CheckRoomAvailability_NoInput_ReturnsListOfReservationDTO()
        {
            List<CheckRoomAvailabilityOutputDTO> reservList = new List<CheckRoomAvailabilityOutputDTO>();
            CheckRoomAvailabilityOutputDTO res1 = new CheckRoomAvailabilityOutputDTO()
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(2)
            };
            CheckRoomAvailabilityOutputDTO res2 = new CheckRoomAvailabilityOutputDTO()
            {
                StartDate = DateTime.Today.AddDays(4),
                EndDate = DateTime.Today.AddDays(5)
            };
            reservList.Add(res1);
            reservList.Add(res2);


            _reservationRepository.Setup(m => m.Find(It.IsAny<Expression<Func<Reservation, bool>>>())).Returns(new List<Reservation>());
            _mapper.Setup(m => m.Map<List<CheckRoomAvailabilityOutputDTO>>(It.IsAny<List<Reservation>>())).Returns(reservList);
            List<CheckRoomAvailabilityOutputDTO> result = _reservationService.CheckRoomAvailability();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].StartDate, DateTime.Today);
            Assert.AreEqual(result[0].EndDate, DateTime.Today.AddDays(2));
            Assert.AreEqual(result[1].StartDate, DateTime.Today.AddDays(4));
            Assert.AreEqual(result[1].EndDate, DateTime.Today.AddDays(5));
        }


        [Test]
        public void DeleteReservation_Id_ExecutesDeleteReservation()
        {
            List<Reservation> reservList = new List<Reservation>();
            Reservation reserv = new Reservation();
            reservList.Add(reserv);

            _reservationRepository.Setup(m => m.Find(It.IsAny<Expression<Func<Reservation, bool>>>())).Returns(reservList);
            _reservationRepository.Setup(m => m.Delete(It.IsAny<int>()));

            _reservationService.DeleteReservation(1);

            _reservationRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.AtLeastOnce());
        }
    }
}
