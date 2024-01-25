using prueba1.Models;

namespace prueba1.Repositorio.IRepositorio
{
    public interface ICustomerRepositorio : IRepositorio<Customer>
    {
        Task<Customer> Actualizar(Customer customer);
    }
}
