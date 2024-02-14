using Microsoft.AspNetCore.Mvc;
using prueba1.Interfaces;
using prueba1.Models;

namespace prueba1.Controllers
{
    public class PaginacionController : Controller
    {
        #region MyRegion
            private readonly IlogicaCustomer _logi;
            public PaginacionController(IlogicaCustomer logica)
            {
                _logi = logica;
            }
        #endregion

        #region --->> paginacion customer (PRIMERA VERSION)
        // buscar           => input de nueva busqueda
        // ordenActual      => fila a ordenar
        // numpag           => numero de pagina 
        // filtroActual     => busqueda actual
        // model            => Paginacion.cs
        public async Task<IActionResult> Index(string buscar, string ordenActual, int? numpag, string filtroActual)
        {
            // tipo de orden
            ViewData["ordenActual"] = ordenActual;
            // pasa la busqueda nueva o la actual
            ViewData["filtroActual"] = buscar ?? filtroActual;

            // orden de cada filtro (cabecera)
            ViewData["filtroContactName"] = string.IsNullOrEmpty(ordenActual) ? "ContactNameDescendente" : "";
            ViewData["filtroCompanyName"] = ordenActual == "CompanyNameAscendente" ? "CompanyNameDescendente" : "CompanyNameAscendente";


            var x = await _logi.PaginacionCustomer(buscar, ordenActual, numpag, filtroActual);


            return View(x);
        }
        #endregion

        #region --->> paginacion customer (SEGUNDA VERSION)
        // buscar           => input de nueva busqueda
        // ordenActual      => fila a ordenar
        // numpag           => numero de pagina 
        // filtroActual     => busqueda actual
        // model            => Page/Page.cs
        public async Task<IActionResult> Index1(string buscar, string ordenActual, int? numpag, string filtroActual, string campo = "CompanyName", string orden = "False")
        {
            // tipo de orden
            ViewData["ordenActual"] = ordenActual;

            // pasa la busqueda nueva o la actual
            ViewData["filtroActual"] = buscar ?? filtroActual;

            

            // orden de cada filtro (cabecera)
            // ViewData["filtroContactName"] = string.IsNullOrEmpty(ordenActual) ? "ContactNameDescendente" : "";
            //   ViewData["CompanyName"] = ordenActual == "CompanyNameAscendente" ? "CompanyNameDescendente" : "CompanyNameAscendente";
            ViewData["Orden"] = orden == "True" ? "False" : "True";

               var x = await _logi.PaginacionGenerica(buscar, ordenActual, numpag, filtroActual, Convert.ToBoolean(orden), campo);


            return View(x);
        }
        #endregion

        #region viejo
        public async Task<IActionResult> Paginacion(int page=1)
        {

            IEnumerable<Customer> x = await _logi.ListCustomer();

            var customerView = new ClassPaginacion
            {
                customerPerPage = 5,
                customer = x,
                CurrentPage = page
            };
            return View(customerView);
        }
        #endregion

    }
}
