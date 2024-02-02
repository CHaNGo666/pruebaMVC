using prueba1.Models;

namespace prueba1.Interfaces
{
    public interface IlogicaCustomer
    {
        Task<IEnumerable<Customer>> ListCustomer();

        Task<IEnumerable<Order>> ListOrder();

        Task<Order> FoD_Order();



        Task<Paginacion<Customer>> PaginacionCustomer(string buscar, string filtro, int? numpag, string filtroActual);
    }
}
