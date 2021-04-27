using System.Threading.Tasks;
using Domain.Pedidos.Shared;

namespace Domain.Pedidos.Aggregates.Cliente
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        Task<Cliente> BuscaAsync(string BuyerIdentityGuid);
        Task<Cliente> BuscaPorIdAsync(string id);
    }
}