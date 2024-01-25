using Microsoft.EntityFrameworkCore;
using prueba1.Models;
using prueba1.Repositorio;
using prueba1.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace prueba1.Dato
{
    public class CustomerRepositorio : Repositorio<Customer>, ICustomerRepositorio
    {


        #region constructor
        public readonly NorthwindContext _bd;

        public CustomerRepositorio(NorthwindContext db) : base(db)
        {
                _bd = db;
        }

        #endregion

        #region Actualizar
        public async Task<Customer> Actualizar(Customer customer)
        {
            customer.Fax = "S/F";
            _bd.Customers.Update(customer);
            await _bd.SaveChangesAsync();
            return customer;
        }
        #endregion


    }
}
