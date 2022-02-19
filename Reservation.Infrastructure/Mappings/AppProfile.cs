using AutoMapper;
using ReservationProject.Domain.Entities.Cateogry;
using ReservationProject.Infrastructure.DTOs.Cateogry;
using ReservationProject.Domain.Entities.ServiceModal;
using ReservationProject.Infrastructure.DTOs.ServiceModal;
using ReservationProject.Domain.Entities.ServicePolicy;
using ReservationProject.Infrastructure.DTOs.ServicePolicy;
using ReservationProject.Domain.Entities.ServicePolicyItem;
using ReservationProject.Infrastructure.DTOs.ServicePolicyItem;
using ReservationProject.Infrastructure.DTOs.Discount;
using ReservationProject.Domain.Entities.Discount;
using ReservationProject.Infrastructure.DTOs.AvailableService;
using ReservationProject.Domain.Entities.AvailableService;
using ReservationProject.Infrastructure.DTOs.AvailableServiceTime;
using ReservationProject.Domain.Entities.AvailableServiceTime;
using ReservationProject.Infrastructure.DTOs.Location;
using ReservationProject.Domain.Entities.Location;
using ReservationProject.Domain.Entities.TemporaryReservation;
using ReservationProject.Infrastructure.DTOs.TemporaryReservation;
using ReservationProject.Infrastructure.DTOs;
using ReservationProject.Domain.Entities.Rate;

namespace ReservationProject.Infrastructure.Mappings
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CategoryView, Category>().ReverseMap();
            CreateMap<ServiceModalView, ServiceModal>().ReverseMap();
            CreateMap<ServicePolicyView, ServicePolicy>().ReverseMap();
            CreateMap<ServicePolicyItemView, ServicePolicyItem>().ReverseMap();
            CreateMap<DiscountView, Discount>().ReverseMap();
            CreateMap<AvailableServiceView, AvailableService>().ReverseMap();
            CreateMap<AvailableServiceTimeView, AvailableServiceTime>().ReverseMap();
            CreateMap<LocationView, Location>().ReverseMap();
            CreateMap<TemporaryReservationView, TemporaryReservation>().ReverseMap();
            CreateMap<RateView, Rate>().ReverseMap();
        }
    }
}