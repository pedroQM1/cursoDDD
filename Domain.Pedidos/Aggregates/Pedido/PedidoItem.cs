using Domain.Pedidos.DomainException;

namespace Domain.Pedidos.Aggregates.Pedido
{
    public class PedidoItem
    {
        private string _nome;
        private string _urlFoto;
        private decimal _valorUnitario;
        private decimal _desconto;
        private int _unidade;

        public int ProdutoID { get; private set; }
        protected PedidoItem() { }

         public PedidoItem(int produtoId, string nome, decimal valorUnitario, decimal desconto, string urlFoto, int unidade = 1)
        {
            if (unidade <= 0)
            {
                throw new PedidoDomainException("Número de unidade do Produto está inválida");
            }

            if ((valorUnitario * unidade) < desconto)
            {
                throw new PedidoDomainException("O valor total do pedido e menor que o desconto");
            }

            ProdutoID = produtoId;
            _nome = nome;
            _valorUnitario = valorUnitario;
            _desconto = desconto;
            _unidade = unidade;
            _urlFoto = urlFoto;
        }
        public string GetFotoUrl() => _urlFoto;

        public decimal GetDescontoAtual()
        {
            return _desconto;
        }

        public int GetUnidades()
        {
            return _unidade;
        }

        public decimal GetValorUnitario()
        {
            return _valorUnitario;
        }

        public string GetNomeDoProdutoDoPedido() => _nome;

        public void AdicionarNovoDesconto(decimal desconto)
        {
            if (desconto < 0)
            {
                throw new PedidoDomainException("Desconto não é valido");
            }

            _desconto = desconto;
        }

        public void AdicionarQuantidade(int unidade)
        {
            if (unidade < 0)
            {
                throw new PedidoDomainException("Quandite de unidade  inválida");
            }

            _unidade += unidade;
        }

    }
}