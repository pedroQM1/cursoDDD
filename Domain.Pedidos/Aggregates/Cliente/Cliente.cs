using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Pedidos.Events;
using Domain.Pedidos.Shared;

namespace Domain.Pedidos.Aggregates.Cliente
{
    public class Cliente : Entity , IAggregateRoot
    {
        public string IdentityGuid { get; private set; }
        public string Nome { get; private set; }
        private List<FormaPagamento> _formasPagamentos;
        public IEnumerable<FormaPagamento> FormaPagamento => _formasPagamentos.AsReadOnly();

        protected Cliente()
        {

            _formasPagamentos = new List<FormaPagamento>();
        }
        public Cliente(string identity, string nome) : this()
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Nome = !string.IsNullOrWhiteSpace(nome) ? nome : throw new ArgumentNullException(nameof(nome));
        }
        public FormaPagamento VerificaOuAdicionaFormaDePagamento(
            int cardTypeId, string alias, string cardNumber,
            string securityNumber, string cardHolderName, DateTime expiration, int orderId)
        {
            var existingPayment = _formasPagamentos
                .SingleOrDefault(p => p.IsEqualTo(cardTypeId, cardNumber, expiration));

            if (existingPayment != null)
            {
                AddDomainEvent(new ClienteVerificouFormaPagamentoDomainEvent(this, existingPayment, orderId));

                return existingPayment;
            }

            var payment = new FormaPagamento(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration);

            _formasPagamentos.Add(payment);

            AddDomainEvent(new ClienteVerificouFormaPagamentoDomainEvent(this, payment, orderId));

            return payment;
        }
    }
}