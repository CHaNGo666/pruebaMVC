using System.Linq.Expressions;

namespace prueba1.Page
{
    public interface IPaginacion<T> where T : class
    {
        //   Task<List<T>> CrearPage(Expression<Func<T, bool>>? filtro = null, int paginaInicio, int cantRegistros);

        // salida
        // algo ok
        Task<List<T>> CrearPaginacion(List<T> fuente, int paginaInicio, int cantRegistros);
    }
}
