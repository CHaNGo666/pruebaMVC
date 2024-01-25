using prueba1.Models;

namespace prueba1.Repositorio.IRepositorio
{
    public interface IOrderRepositorio : IRepositorio<Order>
    {
        Task<Order> ActualizarOrder(Order order);
    }
}