using System;
using Domain.Pedidos.DomainException;
using Domain.Pedidos.Shared;

namespace Domain.Pedidos.Aggregates.Cliente
{
    public class FormaPagamento : Entity
    {
        private string _alias;
        private string _numeroCartao;
        private string _numeroSeguranca;
        private string _nomeTitular;
        private DateTime _DataExpiracao;


        protected FormaPagamento() { }
        private int _tipoCartaoId;
        public TiposCartao tipoCartao { get; private set; }

        public FormaPagamento(int tipoId, string alias, string numeroCartao, string numeroSeguranca, string nomeTitular, DateTime dataExpiracao)
        {

            _numeroCartao = !string.IsNullOrWhiteSpace(numeroCartao) ? numeroCartao : throw new PedidoDomainException(nameof(numeroCartao));
            _numeroSeguranca = !string.IsNullOrWhiteSpace(numeroSeguranca) ? numeroSeguranca : throw new PedidoDomainException(nameof(numeroSeguranca));
            _nomeTitular = !string.IsNullOrWhiteSpace(nomeTitular) ? nomeTitular : throw new PedidoDomainException(nameof(nomeTitular));

            if (dataExpiracao < DateTime.UtcNow)
            {
                throw new PedidoDomainException(nameof(dataExpiracao));
            }

            _alias = alias;
            _DataExpiracao = dataExpiracao;
            _tipoCartaoId = tipoId;
        }

        public bool IsEqualTo(int tipoCartaoId, string numeroCartao, DateTime dataExpiracao)
        {
            return _tipoCartaoId == tipoCartaoId
                && _numeroCartao == numeroCartao
                && _DataExpiracao == dataExpiracao;
        }
    }
}