using Microsoft.EntityFrameworkCore;

namespace prueba1.Models
{
    public class Paginacion<T> : List<T>
    {

        // https://www.youtube.com/watch?v=TrQ7YFp9rMU
        public int PaginaInicio {  get; private set; }
        public int PaginasTotales { get; private set; }

        public Paginacion(List<T> items, int contador, int paginaInicio, int cantRegistros)
        {
            PaginaInicio = paginaInicio;
            PaginasTotales = (int)Math.Ceiling(contador / (double)cantRegistros);

            this.AddRange(items);   
         }

        public bool PaginasAnteriores => PaginaInicio > 1;
        public bool PaginasPosteriores => PaginaInicio < PaginasTotales;

        public static async Task<Paginacion<T>> CrearPaginacion(List<T> fuente, int paginaInicio, int cantRegistros)
        {
 

            var contador = Task.Run(() =>
            {

            return fuente.Count();

            });


            var items = Task.Run(() =>
            {

            return fuente.Skip((paginaInicio - 1) * cantRegistros).Take(cantRegistros).ToList();

            });

            return new Paginacion<T>(await items,await contador, paginaInicio, cantRegistros);

        }

    }
}
