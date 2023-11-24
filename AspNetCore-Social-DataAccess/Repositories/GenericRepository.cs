using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AspNetCore_Social_DataAccess.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
	{
		private readonly SocialContext _socialContext;
		private DbSet<T> _dbSet;

		public GenericRepository(SocialContext socialContext)
		{
			_socialContext = socialContext;
			_dbSet = _socialContext.Set<T>();
		}

		public async Task Add(T entity)
		{
			try
			{
				await _dbSet.AddAsync(entity);
			}
			catch (Exception)
			{

				throw;
			}
			
		}

		public void Delete(T entity)
		{
			try
			{
				_dbSet.Remove(entity);
			}
			catch (Exception)
			{

				throw;
			}
			
		}

		public async Task<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
		{
			try
			{
				IQueryable<T> query = _dbSet;  //tabloyu alır filtreleri uygulayarak filtrelenmiş verileri dödürür
				if (filter != null)  //filtre varsa
				{
					query = query.Where(filter);
				}				
				foreach (var table in includes)  //ilişkili tablolar istenmişse
				{
					query = query.Include(table);
				}
				return await query.AsNoTracking().FirstOrDefaultAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
		{
			try
			{
				IQueryable<T> query = _dbSet;  //tabloyu alır filtreleri uygulayarak filtrelenmiş verileri dödürür
				if (filter != null)  //filtre varsa
				{
					query = query.Where(filter);
				}
				if (orderby != null)  //sıralama istenmişse
				{
					query = orderby(query);
				}
				foreach (var table in includes)  //ilişkili tablolar istenmişse
				{
					query = query.Include(table);
				}
				return await query.ToListAsync();
			}
			catch (Exception)
			{

				throw;
			}
	
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			try
			{
				return await _dbSet.AsNoTracking().ToListAsync();
			}
			catch (Exception)
			{

				throw;
			}
			
		}

		public async Task<T> GetById(int id)
		{
			try
			{
				return await _dbSet.FindAsync(id);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void Update(T entity)
		{
			try
			{
				_dbSet.Update(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
