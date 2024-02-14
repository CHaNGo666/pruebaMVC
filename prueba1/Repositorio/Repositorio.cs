using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using prueba1.Models;
using prueba1.Repositorio.IRepositorio;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
//----------------------------------------------------------------------//
//              PATRON DE REPOSITORIO    Clase                          //
//----------------------------------------------------------------------//

namespace prueba1.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        #region constructor
        public readonly NorthwindContext _bd;
        internal DbSet<T> dbSet;

        public Repositorio(NorthwindContext db)
        {
            _bd = db;
            dbSet = _bd.Set<T>();
        }
        #endregion

        #region crear
        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad);
        }
        #endregion

        #region grabar
        public async Task Grabar()
        {
            await _bd.SaveChangesAsync();
        }
        #endregion

        #region obtener uno
        public async Task<T> Obtener(Expression<Func<T, bool>>? filtro = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.FirstOrDefaultAsync();

        }
        #endregion

        #region obtener todos


        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.ToListAsync();

        }
        #endregion

        #region remover
        public async Task Remover(T emtidad)
        {
            dbSet.Remove(emtidad);
            await Grabar();

        }
        #endregion

    }
}
