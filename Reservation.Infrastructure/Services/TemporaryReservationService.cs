using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.TemporaryReservation;
using ReservationProject.Infrastructure.DTOs.TemporaryReservation;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    public class TemporaryReservationService : ITemporaryReservationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;
     
        public TemporaryReservationService (IMapper mapper, IUnitOfWork UoW)
        {
            _mapper = mapper;
            _UoW = UoW;
        }
        
        public async Task<Result<List<TemporaryReservationView>>> GetAllTemporaryReservation()
        {
            // get all temporary reservation
            var temporaryReservation =await _UoW.TemporaryReservationRepository.GetAllAsync(); 
            
            // map it with mapper 
            var temporaryReservationWithMap = _mapper.Map<List<TemporaryReservationView>>(temporaryReservation); 

            // return the reault with seccess message  
            return await Result<List<TemporaryReservationView>>.SuccessAsync(temporaryReservationWithMap, "Temporary Reservation Recored");
        }

        public async Task<Result<List<TemporaryReservationView>>> GetTemporaryReservationById(long id)
        {
            // get all temporary reservation
            var temporaryReservation = _UoW.TemporaryReservationRepository.Entities.Where(c => c.Id == id).ToList();

            // ckeck if it null or not 
            if (temporaryReservation.Count == 0)
                return await Result<List<TemporaryReservationView>>.SuccessAsync(null, "The Reservation with Given Id is Not Exist");

            // map it with mapper 
            var temporaryReservationWithMap = _mapper.Map<List<TemporaryReservationView>>(temporaryReservation);

            // return the reault with seccess message  
            return await Result<List<TemporaryReservationView>>.SuccessAsync(temporaryReservationWithMap, "Temporary Reservation Recored");
        }

        public async Task<Result<List<TemporaryReservationView>>> GetTemporaryReservationByUserId(string id)
        {
            // get all temporary reservation
            var temporaryReservation = _UoW.TemporaryReservationRepository.Entities.Where(c => c.ReservationUserId == id).ToList();

            // ckeck if it null or not 
            if (temporaryReservation.Count == 0)
                return await Result<List<TemporaryReservationView>>.SuccessAsync(null, "The Reservation with Given Id is Not Exist");

            // map it with mapper 
            var temporaryReservationWithMap = _mapper.Map<List<TemporaryReservationView>>(temporaryReservation);

            // return the reault with seccess message  
            return await Result<List<TemporaryReservationView>>.SuccessAsync(temporaryReservationWithMap, "The List Of Temporary Reservation");
        }

        public async Task<IResult> Create(TemporaryReservationView temporaryReservation)
        {
            try
            {
                var temporaryReservationMapper = _mapper.Map<TemporaryReservation>(temporaryReservation);

                await _UoW.TemporaryReservationRepository.AddAsync(temporaryReservationMapper);

                await _UoW.Commit(new CancellationToken());

                return await Result.SuccessAsync(message: "created successfully");
            }
            catch
            {
                await _UoW.Rollback();
                return Result.Fail(message: "something wrong happened");
            }
        }

        public async Task<IResult> Delete(long id)
        {
            // get the cateogry from database 
            var temporaryReservation = await _UoW.TemporaryReservationRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (temporaryReservation != null)
            {
                // change the Isdelete prop
                await _UoW.TemporaryReservationRepository.DeleteAsync(temporaryReservation);
                await _UoW.Commit(new CancellationToken());

                // return message with done 
                return await Result.SuccessAsync(message: String.Format("deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The Temporary Reservation with Given Id is Not Exist");
        }

    }
}
