using prueba1.Models;

namespace prueba1.Interfaces
{
    public interface IlogicaCustomer
    {
        Task<IEnumerable<Customer>> ListCustomer();

        Task<IEnumerable<Order>> ListOrder();

        Task<Order> FoD_Order();
    }
}
