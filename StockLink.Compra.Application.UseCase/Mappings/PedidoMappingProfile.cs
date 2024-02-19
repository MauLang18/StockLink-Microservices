using AutoMapper;
using StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.ChangeStateCommand;
using StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.CreateCommand;
using StockLink.Compra.Domain.Entities;

namespace StockLink.Compra.Application.UseCase.Mappings
{
    public class PedidoMappingProfile : Profile
    {
        public PedidoMappingProfile()
        {
            CreateMap<CreatePedidoCommand, Pedido>();

            CreateMap<ChangeStatePedidoCommand, Pedido>();
        }
    }
}