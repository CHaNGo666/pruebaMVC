using prueba1.Models;
using prueba1.Repositorio.IRepositorio;
using prueba1.Repositorio;

namespace prueba1.Dato
{
    public class OrderRepositorio : Repositorio<Order>, IOrderRepositorio
    {


        #region constructor
        public readonly NorthwindContext _bd;

        public OrderRepositorio(NorthwindContext db) : base(db)
        {
            _bd = db;
        }

        #endregion

        #region Actualizar

        public async Task<Order> ActualizarOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _bd.Orders.Update(order);
            await _bd.SaveChangesAsync();
            return order;
        }
        #endregion
    }
}