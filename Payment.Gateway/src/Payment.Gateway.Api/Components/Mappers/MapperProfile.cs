namespace Payment.Gateway.Api.Components.Mappers;

using AutoMapper;
using client = Client.Dtos;
using Payment.Gateway.Api.Components.Dtos;
using Payment.Gateway.Api.Components.Models;
using Payment.Gateway.Api.Components.Extensions;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<PaymentRequest, client.SendPaymentRequest>();
        CreateMap<client.GetPaymentResponse, PaymentDetails>()
            .ForMember(d => d.CardNumber, opt => opt.MapFrom(s => s.CardNumber.Mask()));
    }
}

