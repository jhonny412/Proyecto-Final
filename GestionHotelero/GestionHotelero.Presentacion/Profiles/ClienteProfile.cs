using AutoMapper;
using GestionHotelero.Dto.Response;
using GestionHotelero.Entities;
using GestionHotelero.Presentacion.Models;

namespace GestionHotelero.Presentacion.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDtoResponse>()
                .ForMember(d => d.IdCliente, o => o.MapFrom(x => x.IdCliente));

            CreateMap<ClienteViewModel, Cliente>()
                .ReverseMap();
        }
    }
}
