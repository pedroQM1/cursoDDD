using System;

namespace Domain.Pedidos.DomainException
{
    public class PedidoDomainException : Exception
    {
        public PedidoDomainException()
        { }

        public PedidoDomainException(string message)
            : base(message)
        { }

        public PedidoDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}