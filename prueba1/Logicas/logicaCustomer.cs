﻿using prueba1.Interfaces;
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





    }
}