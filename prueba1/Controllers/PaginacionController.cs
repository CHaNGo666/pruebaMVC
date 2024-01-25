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
    }
}
