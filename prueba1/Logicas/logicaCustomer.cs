using Microsoft.EntityFrameworkCore;
using prueba1.Interfaces;
using prueba1.Models;
using prueba1.Repositorio.IRepositorio;


namespace prueba1.Logicas
{
    public class logicaCustomer : IlogicaCustomer
    {
        #region constructor
        // 
        private readonly ICustomerRepositorio _customer;
        private readonly IOrderRepositorio _order;
        public logicaCustomer(ICustomerRepositorio c, IOrderRepositorio order)
        {
            _customer = c;
            _order = order;
        }

        public async Task<Order> FoD_Order()
        {
            // ALFKI
            var orden = await _order.Obtener(x => x.CustomerId == "ALFKI");

            return orden;
        }
        #endregion



        public async Task<IEnumerable<Customer>> ListCustomer()
        {
            return await _customer.ObtenerTodos();
        }

   

   

        public async Task<IEnumerable<Order>> ListOrder()
        {
            return await _order.ObtenerTodos();
        }



        #region paginacion (PRIMERA VERSION)
        public async Task<Paginacion<Customer>> PaginacionCustomer(
            string buscar,
            string ordenActual,
            int? numpag,
            string filtroActual)
        {

            var vendedores = await _customer.ObtenerTodos();

            if (buscar != null)
            {
                numpag = 1;
            }
            else
            {
                buscar = filtroActual;
            }

            if (!string.IsNullOrEmpty(buscar))
            {
                vendedores = await _customer.ObtenerTodos(s => s.Country!.Contains(buscar));
            }

            #region orden
            switch (ordenActual)
            {
                case "ContactNameDescendente":
                    vendedores = vendedores.OrderByDescending(x => x.ContactName).ToList();
                    break;

                case "CompanyNameDescendente":
                    vendedores = vendedores.OrderByDescending(x => x.CompanyName).ToList();
                    break;
                case "CompanyNameAscendente":
                    vendedores = vendedores.OrderBy(x => x.CompanyName).ToList();
                    break;

                default:
                    vendedores = vendedores.OrderBy(x => x.ContactName).ToList();
                    break;
            }
            #endregion


            return await Paginacion<Customer>.CrearPaginacion(vendedores, numpag ?? 1, 6);
        }



        #endregion


        #region paginacion generica (SEGUNDA VERSION)

        public async Task<Page<Customer>> PaginacionGenerica(string buscar, 
            string ordenActual, 
            int? numpag, 
            string filtroActual, 
            bool orden,
            string campo)
        {
            var vendedores = await _customer.ObtenerTodos();

            if (buscar != null)
            {
                numpag = 1;
            }
            else
            {
                buscar = filtroActual;
            }

            if (!string.IsNullOrEmpty(buscar))
            {
                vendedores = await _customer.ObtenerTodos(s => s.Country!.Contains(buscar));

            }

            #region orden



            //switch (ordenActual)
            //{
            //    case "ContactNameDescendente":
            //        vendedores = vendedores.OrderByDescending(x => x.ContactName).ToList();
            //        break;

            //    case "CompanyNameDescendente":
            //        vendedores = vendedores.OrderByDescending(x => x.CompanyName).ToList();
            //        break;
            //    case "CompanyNameAscendente":
            //        vendedores = vendedores.OrderBy(x => x.CompanyName).ToList();
            //        break;

            //    default:
            //        vendedores = vendedores.OrderBy(x => x.ContactName).ToList();
            //        break;
            //}
            #endregion

            return await Page<Customer>.Paginado(vendedores, numpag ?? 1, 6, campo, orden);
        }



        #endregion


    }
}
