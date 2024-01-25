using System.Reflection.Metadata;

namespace prueba1.Models
{
    public class ClassPaginacion
    {
        public IEnumerable<Customer> customer { get; set; }
        public int customerPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(customer.Count() / (double)customerPerPage));
        }
        public IEnumerable<Customer> PaginateCustomer()
        {
            int start = (CurrentPage - 1) * customerPerPage;

            return customer.OrderBy(b => b.CustomerId).Skip(start).Take(customerPerPage);
        }

    }
}
