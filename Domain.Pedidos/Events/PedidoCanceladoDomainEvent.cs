using Domain.Pedidos.Aggregates.Pedido;
using MediatR;

namespace Domain.Pedidos.Events
{
    public class PedidoCanceladoDomainEvent : INotification
    {   

        public Pedido Pedido {get;}    

        public PedidoCanceladoDomainEvent(Pedido pedido){
            Pedido = pedido;
        }
    }
}