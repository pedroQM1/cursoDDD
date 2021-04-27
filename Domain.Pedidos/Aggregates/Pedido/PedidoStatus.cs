using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Pedidos.DomainException;
using Domain.Pedidos.Shared;

namespace Domain.Pedidos.Aggregates.Pedido
{
    public class PedidoStatus : Enumeration
    {
        public static PedidoStatus Submetido = new PedidoStatus(1, nameof(Submetido).ToLowerInvariant());
        public static PedidoStatus EsperandoValidacao = new PedidoStatus(2, nameof(EsperandoValidacao).ToLowerInvariant());
        public static PedidoStatus PedidoConfirmado = new PedidoStatus(3, nameof(PedidoConfirmado).ToLowerInvariant());
        public static PedidoStatus Pago = new PedidoStatus(4, nameof(Pago).ToLowerInvariant());
        public static PedidoStatus Enviado = new PedidoStatus(5, nameof(Enviado).ToLowerInvariant());
        public static PedidoStatus Cancelado = new PedidoStatus(6, nameof(Cancelado).ToLowerInvariant());
        public PedidoStatus(int id, string name)
            : base(id, name)
        {
        }
        public static IEnumerable<PedidoStatus> List() =>
            new[] { Submetido, EsperandoValidacao, PedidoConfirmado, Pago, Enviado, Cancelado };

        
        public static PedidoStatus DoNome(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new PedidoDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static PedidoStatus Do(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new PedidoDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

    }
}