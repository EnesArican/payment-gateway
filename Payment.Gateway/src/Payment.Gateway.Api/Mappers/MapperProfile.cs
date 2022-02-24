namespace Payment.Gateway.Api.Mappers;

using AutoMapper;
using client = Client.Dtos;
using Payment.Gateway.Api.Dtos;
using Payment.Gateway.Api.Models;
using Payment.Gateway.Api.Extensions;

public class MapperProfile : Profile
{
    public MapperProfile() 
    {
        CreateMap<PaymentRequest, client.SendPaymentRequest>();
        CreateMap<client.GetPaymentResponse, PaymentDetails>()
            .ForMember(d => d.CardNumber, opt => opt.MapFrom(s => s.CardNumber.Mask()));
    }
}

