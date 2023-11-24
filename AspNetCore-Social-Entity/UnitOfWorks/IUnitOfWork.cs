using AspNetCore_Social_Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.UnitOfWorks
{
	public interface IUnitOfWork
	{
		IGenericRepository<T> GetRepository<T>() where T : class,new();  //unitofworks üzerinden repoya erişmek için
		void Commit(); //save
		Task CommitAsync(); //saveAsync
	}
}
