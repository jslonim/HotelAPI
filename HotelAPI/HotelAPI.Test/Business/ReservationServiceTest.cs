using AutoMapper;
using HotelAPI.Business;
using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.DTO.Output;
using HotelAPI.Business.Exceptions;
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
            Reservation reserv = new Reservation();

            _reservationRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns(reserv);
            _reservationRepository.Setup(m => m.Delete(It.IsAny<int>()));

            _reservationService.DeleteReservation(1);

            _reservationRepository.Verify(x => x.Delete(It.IsAny<object>()), Times.Once());
        }

        [Test]
        public void DeleteReservation_Id_ThrowsExeptionReservationDoesNotExist()
        {
            List<Reservation> reservList = new List<Reservation>();

            _reservationRepository.Setup(m => m.Find(It.IsAny<Expression<Func<Reservation, bool>>>())).Returns(reservList);
            _reservationRepository.Setup(m => m.Delete(It.IsAny<int>()));

            Assert.Throws<ValidationException>(() => _reservationService.DeleteReservation(1));
        }

        [Test]
        public void CreateReservation_CreateReservationInputDTO_CreatesReservation()
        {
            CreateReservationInputDTO reservationDTO = new CreateReservationInputDTO()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            Reservation reservation = new Reservation()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            _reservationRepository.Setup(m => m.Insert(It.IsAny<Reservation>()));
            _mapper.Setup(m => m.Map<Reservation>(It.IsAny<CreateReservationInputDTO>())).Returns(reservation);
            _reservationService.CreateReservation(reservationDTO);

            _reservationRepository.Verify(x => x.Insert(It.IsAny<Reservation>()), Times.Once());
        }
        [Test]
        public void CreateReservation_CreateReservationInputDTO_ThowsValidationExceptionForUsingTodayDate()
        {
            CreateReservationInputDTO reservationDTO = new CreateReservationInputDTO()
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            Reservation reservation = new Reservation()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            _reservationRepository.Setup(m => m.Insert(It.IsAny<Reservation>()));
            _mapper.Setup(m => m.Map<Reservation>(It.IsAny<CreateReservationInputDTO>())).Returns(reservation);

            Assert.Throws<ValidationException>(() => _reservationService.CreateReservation(reservationDTO));
        }
        [Test]
        public void CreateReservation_CreateReservationInputDTO_ThowsValidationExceptionForExtraDays()
        {
            CreateReservationInputDTO reservationDTO = new CreateReservationInputDTO()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(6),
                CustomerFullName = "Julian Slonim"
            };

            Reservation reservation = new Reservation()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            _reservationRepository.Setup(m => m.Insert(It.IsAny<Reservation>()));
            _mapper.Setup(m => m.Map<Reservation>(It.IsAny<CreateReservationInputDTO>())).Returns(reservation);

            Assert.Throws<ValidationException>(() => _reservationService.CreateReservation(reservationDTO));
        }

        [Test]
        public void CreateReservation_CreateReservationInputDTO_ThowsValidationExceptionFor30DaysForward()
        {
            CreateReservationInputDTO reservationDTO = new CreateReservationInputDTO()
            {
                StartDate = DateTime.Today.AddDays(40),
                EndDate = DateTime.Today.AddDays(41),
                CustomerFullName = "Julian Slonim"
            };

            Reservation reservation = new Reservation()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            _reservationRepository.Setup(m => m.Insert(It.IsAny<Reservation>()));
            _mapper.Setup(m => m.Map<Reservation>(It.IsAny<CreateReservationInputDTO>())).Returns(reservation);

            Assert.Throws<ValidationException>(() => _reservationService.CreateReservation(reservationDTO));
        }
        [Test]
        public void UpdateReservation_UpdateReservationInputDTO_UpdatesReservation()
        {
            UpdateReservationInputDTO reservationDTO = new UpdateReservationInputDTO()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            Reservation reservation = new Reservation()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };


            _reservationRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns(reservation);
            _reservationRepository.Setup(m => m.Update(It.IsAny<Reservation>()));
            _mapper.Setup(m => m.Map<Reservation>(It.IsAny<UpdateReservationInputDTO>())).Returns(reservation);
            _reservationService.UpdateReservation(reservationDTO);

            _reservationRepository.Verify(x => x.Update(It.IsAny<Reservation>()), Times.Once());
        }
        [Test]
        public void UpdateReservation_UpdateReservationInputDTO_ThowsValidationExceptionForUsingTodayDate()
        {
            UpdateReservationInputDTO reservationDTO = new UpdateReservationInputDTO()
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            Reservation reservation = new Reservation()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            _reservationRepository.Setup(m => m.Insert(It.IsAny<Reservation>()));
            _mapper.Setup(m => m.Map<Reservation>(It.IsAny<UpdateReservationInputDTO>())).Returns(reservation);

            Assert.Throws<ValidationException>(() => _reservationService.UpdateReservation(reservationDTO));
        }
        [Test]
        public void UpdateReservation_UpdateReservationInputDTO_ThowsValidationExceptionForExtraDays()
        {
            UpdateReservationInputDTO reservationDTO = new UpdateReservationInputDTO()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(6),
                CustomerFullName = "Julian Slonim"
            };

            Reservation reservation = new Reservation()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            _reservationRepository.Setup(m => m.Insert(It.IsAny<Reservation>()));
            _mapper.Setup(m => m.Map<Reservation>(It.IsAny<UpdateReservationInputDTO>())).Returns(reservation);

            Assert.Throws<ValidationException>(() => _reservationService.UpdateReservation(reservationDTO));
        }

        [Test]
        public void UpdateReservation_UpdateReservationInputDTO_ThowsValidationExceptionFor30DaysForward()
        {
            UpdateReservationInputDTO reservationDTO = new UpdateReservationInputDTO()
            {
                StartDate = DateTime.Today.AddDays(40),
                EndDate = DateTime.Today.AddDays(41),
                CustomerFullName = "Julian Slonim"
            };

            Reservation reservation = new Reservation()
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2),
                CustomerFullName = "Julian Slonim"
            };

            _reservationRepository.Setup(m => m.Insert(It.IsAny<Reservation>()));
            _mapper.Setup(m => m.Map<Reservation>(It.IsAny<UpdateReservationInputDTO>())).Returns(reservation);

            Assert.Throws<ValidationException>(() => _reservationService.UpdateReservation(reservationDTO));
        }

    }
}
