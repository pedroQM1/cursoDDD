using System;
using System.Collections.Generic;
using Domain.Pedidos.Shared;

namespace Domain.Pedidos.Aggregates.Pedido
{
    public class Endereco : ValueObject
    {
        
        public String Rua { get; private set; }
        public String Cidade { get; private set; }
        public String Estado { get; private set; }
        public String Cep { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }

        public Endereco() { }

        public Endereco(string rua, string bairro, string cidade, string estado, string cep,int numero)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Numero = numero;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Rua;
            yield return Cidade;
            yield return Estado;
            yield return Numero;
            yield return Cep;
            yield return Bairro;

        }
    }
}