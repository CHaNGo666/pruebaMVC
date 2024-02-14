using prueba1.Models;

namespace prueba1.Interfaces
{
    public interface IlogicaCustomer
    {
        Task<IEnumerable<Customer>> ListCustomer();

        Task<IEnumerable<Order>> ListOrder();

        Task<Order> FoD_Order();

        // segunda version
        Task<Page<Customer>> PaginacionGenerica(string buscar, string ordenActual, int? numpag, string filtroActual, bool orden, string campo);

        Task<Paginacion<Customer>> PaginacionCustomer(string buscar, string ordenActual, int? numpag, string filtroActual);
    }
}
