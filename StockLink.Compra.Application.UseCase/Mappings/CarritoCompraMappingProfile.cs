using AutoMapper;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.CreateCommand;
using StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.UpdateCommand;
using StockLink.Compra.Domain.Entities;

namespace StockLink.Compra.Application.UseCase.Mappings
{
    public class CarritoCompraMappingProfile : Profile
    {
        public CarritoCompraMappingProfile()
        {
            CreateMap<CreateCarritoCompraCommand, CarritoCompra>();

            CreateMap<UpdateCarritoCompraCommand, CarritoCompra>();
        }
    }
}