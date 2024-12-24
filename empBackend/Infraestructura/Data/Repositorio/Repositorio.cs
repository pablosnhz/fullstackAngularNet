using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Especificaciones;
using Infraestructura.Data.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task Agregar(T entidad)
        {
            await dbSet.AddAsync(entidad);
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null) // "Compania, Cargo, Departamento" separa por coma
            {
                foreach (var ip in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        // retorna la lista segun los filtros
        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null) // "Compania, Cargo, Departamento" separa por coma
            {
                foreach (var ip in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToArrayAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<PagedList<T>> ObtenerTodosPaginado(Parametro parametro, Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null) // "Compania, Cargo, Departamento" separa por coma
            {
                foreach (var ip in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }
            if (orderBy != null)
            {
                await orderBy(query).ToArrayAsync();
                return PagedList<T>.ToPagedList(query, parametro.PageNumber, parametro.PageSize);
            }
            return PagedList<T>.ToPagedList(query, parametro.PageNumber, parametro.PageSize);
        }

        public void Remover(T entidad)
        {
            dbSet.Remove(entidad);
        }
    }
}