using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_DataAccess.Repositories;
using AspNetCore_Social_Entity.Repositories;
using AspNetCore_Social_Entity.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_DataAccess.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SocialContext _context;

		public UnitOfWork(SocialContext context)
		{
			_context = context;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}

		public IGenericRepository<T> GetRepository<T>() where T : class, new()
		{
			return new GenericRepository<T>(_context);
		}
	}
}
