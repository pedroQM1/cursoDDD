using Domain.Pedidos.Aggregates.Cliente;
using MediatR;

namespace Domain.Pedidos.Events
{
    public class ClienteVerificouFormaPagamentoDomainEvent : INotification
    {
        public Cliente Cliente { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public int PedidoID { get; private set; }

        public ClienteVerificouFormaPagamentoDomainEvent(Cliente cliente, FormaPagamento formaPagamento, int pedidoID){
            Cliente = cliente;
            FormaPagamento = formaPagamento;
            PedidoID = pedidoID;
        }
    }

    // teste
    // teste
    // teste
    // teste
    // teste
    // teste
    // teste
    // teste



     // teste
    // teste
    // teste
    // teste
    // teste
    // teste
    // teste
    // teste

}