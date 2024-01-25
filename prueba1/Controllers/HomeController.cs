using Microsoft.AspNetCore.Mvc;
using prueba1.Interfaces;
using prueba1.Logicas;
using prueba1.Models;
using System.Diagnostics;

namespace prueba1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IlogicaCustomer _logi;
        public HomeController(ILogger<HomeController> logger, IlogicaCustomer logica)
        {
            _logger = logger;
            _logi = logica;
        }

        public IActionResult Index()
        {


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #region ok lista
        public async Task<ActionResult> ListaCustomer()
        {

            return View( await _logi.ListCustomer());
        }
        #endregion


        #region ok lista
        public async Task<ActionResult> ListaOrder()
        {

            return View(await _logi.ListOrder());
        }
        #endregion

        public async Task<ActionResult> FoD_Order()
        {
            return View(await _logi.FoD_Order());

        }


        public ActionResult Customer()
        {

            return View();
        }

        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Customer> Customer(CustomerCreateDto cDto)
        {



            return View(cDto);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
