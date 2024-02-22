using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace prueba1.Models
{
    public class Page<T> : List<T> //: IPaginacion<T> where T : class
    {
        // https://www.youtube.com/watch?v=TrQ7YFp9rMU

        #region var
        public int PaginaInicio { get; private set; }
        public int PaginasTotales { get; private set; }
        #endregion

        #region constructor
        public Page(List<T> items, int contador, int paginaInicio, int cantRegistros)
        {
            PaginaInicio = paginaInicio;
            PaginasTotales = (int)Math.Ceiling(contador / (double)cantRegistros);

            this.AddRange(items);
        }
        #endregion

        #region PASA A LA VISTA LA PAGINACION
        public bool PaginasAnteriores => PaginaInicio > 1;
        public bool PaginasPosteriores => PaginaInicio < PaginasTotales;
        #endregion

        #region CrearPaginacion
        //
        // List<T> fuente       =>  lista con todos los elementos a paginar
        // paginaInicio         => pagina donde empieza a devolver los items
        // cantRegistros        => cantidad de items a devolver
        // property             => campo por el que se ordena
        // orderByDescending    => tipo de orden (asc o desc)
        public static async Task<Page<T>> Paginado(List<T> fuente, 
            int paginaInicio, 
            int cantRegistros, 
            string propertyName, 
            bool orderByDescending)
        {
            #region orden
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.Property(param, propertyName);
            var keySel= Expression.Lambda<Func<T, object>>(Expression.Convert(body, typeof(object)), param);

            fuente = fuente.OrderBy(keySel.Compile()).ToList();

            if (orderByDescending)
            {
                fuente = fuente.OrderByDescending(keySel.Compile()).ToList();
            }
            else
            {
                fuente = fuente.OrderBy(keySel.Compile()).ToList();
            }
            #endregion
        
            // cantidad de registros
            var contador = Task.Run(() => fuente.Count());
            // posicionamiento en la paginacion (pageina 1, 2, 3 etc)
            var items = Task.Run(() => fuente.Skip((paginaInicio - 1) * cantRegistros).Take(cantRegistros).ToList());
            //---------------------------------------------------------------------------
            //---------------------------------------------------------------------------
            //                              RETURN
            // items            => devuelve los item x pagina
            // contador         => devuelve el total de items
            // paginaInicio     => pagina donde empieza a devolver los items
            // cantRegistros    => cantidad de items a devolver
            //--------------------------------------------------------------------------
            return new Page<T>(await items, await contador, paginaInicio, cantRegistros);

        }
        #endregion


      //  Método genérico para ordenar una lista por una propiedad específica
        //public static List<T> OrderByProperty<T, TKey>(List<T> list, Func<T, TKey> keySelector)
        //{
        //    return list.OrderBy(keySelector).ToList();
        //}



    }
}
