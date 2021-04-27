using Domain.Pedidos.Shared;

namespace Domain.Pedidos.Aggregates.Cliente
{
    public class TiposCartao : Enumeration
    {
        public static TiposCartao Amex = new TiposCartao(1, nameof(Amex));
        public static TiposCartao Visa = new TiposCartao(2, nameof(Visa));
        public static TiposCartao MasterCard = new TiposCartao(3, nameof(MasterCard));
        public TiposCartao(int id, string name)
            : base(id, name)
        {
        }
    }
}