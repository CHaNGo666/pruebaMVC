using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using prueba1.Interfaces;
using prueba1.Models;

namespace prueba1.Dato
{
    public class datoCustomer : IDatoCustomer<Customer>
    {
        #region constructor
            public readonly NorthwindContext _bd;
            public datoCustomer(NorthwindContext bd)
            {
                _bd = bd;
            }

        #endregion

        #region MyRegion
        //    public async IQueryable<Customer> ListCustomer() => await _bd.Customers.ToListAsync();
        public async Task<IEnumerable<Customer>> ListCustomer() => await _bd.Customers.ToListAsync();
        #endregion

        #region MyRegion
        public async Task<Customer> PostCustomer(Customer model)
            {

                _bd.Customers.Add(model);
                await _bd.SaveChangesAsync();

                return model;
            }
        #endregion



    }
}
