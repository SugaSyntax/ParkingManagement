using AutoMapper;
using ParkingManagement.Core.Entities;
using ParkingManagement.UseCases.DTOs;

namespace ParkingManagement.UseCases.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DateRange, DaterangeDTO>().ReverseMap();
            CreateMap<BookingRequest, BookingRequestDTO>().ReverseMap();
            CreateMap<BookingResponse, BookingResponseDTO>().ReverseMap();
            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<Prices, PriceDTO>().ReverseMap();
            CreateMap<AvailableSpaces, AvailablespacesDTO>().ReverseMap();
            
        }
    }
}