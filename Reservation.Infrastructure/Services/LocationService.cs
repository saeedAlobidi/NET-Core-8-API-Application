using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.Location;
using ReservationProject.Infrastructure.DTOs.Location;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    public class LocationService : ILocationService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;
         

        public LocationService(IMapper mapper, IUnitOfWork UoW)
        {
            _mapper = mapper;
            _UoW = UoW;
        }

        public async Task<IResult> Create(LocationView location)
        {
            try
            {
                // map the location objcet 
                var locationMapper = _mapper.Map<Location>(location);
                // adding the object 
                await _UoW.LocationRepository.AddAsync(locationMapper);
                // save it 
                await _UoW.Commit(new CancellationToken());
                // return with  successfully message 
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
            // get location by id 
            var location = await _UoW.LocationRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (location != null)
            {
                // change the Isdelete prop
                await _UoW.LocationRepository.DeleteAsync(location);
                await _UoW.Commit(new CancellationToken());
                // return message with done 
                return await Result.SuccessAsync(message: String.Format("deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The Location with Given Id is Not Exist");
        }
 
        public async Task<IResult> Edit(long id, LocationView location)
        {
            var locationFromDB = await _UoW.LocationRepository.GetByIdAsync(id);

            // mapping the CateogryView to Cateogry to make the edit by mapping  
            _mapper.Map<LocationView, Location>(location, locationFromDB);

            // save in database 
            await _UoW.Commit(new CancellationToken());
            // return the message for done 
            return await Result.SuccessAsync(message: String.Format("updated successfully"));
        }

        public async Task<Result<List<LocationView>>> GetLocationByServiceId(long id)
        {
            // get all Location
            var locations = _UoW.LocationRepository.Entities.Where(c => c.serviceId == id).ToList();

            // map it with mapper 
            var categoriesWithMap = _mapper.Map<List<LocationView>>(locations);

            // return the reault with seccess message  
            return await Result<List<LocationView>>.SuccessAsync(categoriesWithMap, "List of Cateogry");
        }
    }
}
