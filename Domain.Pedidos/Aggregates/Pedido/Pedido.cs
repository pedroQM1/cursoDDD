using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Pedidos.DomainException;
using Domain.Pedidos.Events;
using Domain.Pedidos.Shared;

namespace Domain.Pedidos.Aggregates.Pedido
{
    public class Pedido : Entity , IAggregateRoot
    {
        
        private DateTime _dataPedido;
        public Endereco Endereco {get;private set;}
        public int ? ClienteId =>_clienteId;
        private int? _clienteId;
        private string _descricao;
        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems=>_pedidoItems;
        private int? _formaPagamento;
        private int _statusPedido;


        protected Pedido(){
            _pedidoItems = new List<PedidoItem>();
        }
        public Pedido(string atendenteId,string NomeAtendente,Endereco endereco,int tipoCartao,string numeroCartao,string numeroSegurancaCartao,
        string nomeTitulaCartao,DateTime dataExpiracaoCartao, int? clienteId = null, int? formaPagamentoId = null
        ):this(){
            _pedidoItems = new List<PedidoItem>();
            _clienteId = clienteId;
            _formaPagamento = formaPagamentoId;
            _dataPedido = DateTime.UtcNow;
            _statusPedido = PedidoStatus.Submetido.Id;
            Endereco = endereco;

        }
         public void AddPeditoItem(int produtoId, string nomeProduto, decimal valorUnitario, decimal desconto, string fotoUrl, int unidade = 1)
        {

            var produtoExistenteNoPedido = _pedidoItems.Where(o => o.ProdutoID == produtoId).SingleOrDefault();    
            if (produtoExistenteNoPedido != null)
            {
                if (desconto > produtoExistenteNoPedido.GetDescontoAtual())
                    produtoExistenteNoPedido.AdicionarNovoDesconto(desconto);

                produtoExistenteNoPedido.AdicionarQuantidade(unidade);
            }
            else
            {
                var pedidoItem = new PedidoItem(produtoId, nomeProduto, valorUnitario, desconto, fotoUrl, unidade);
                _pedidoItems.Add(pedidoItem);
            }
        }
         public void CancelarPedido()
        {
            if (_statusPedido == PedidoStatus.Pago.Id ||
                _statusPedido == PedidoStatus.Enviado.Id)
            {
                StatusChangeException(PedidoStatus.Cancelado);
            }

            _statusPedido = PedidoStatus.Cancelado.Id;
            _descricao = $"O pedido foi cancelado.";
            AddDomainEvent(new PedidoCanceladoDomainEvent(this));
        }
         private void StatusChangeException(PedidoStatus orderStatusToChange)
        {
            throw new PedidoDomainException($"Não é possivel mudar o status do pedido para {orderStatusToChange.Name}");
        }

    }
}