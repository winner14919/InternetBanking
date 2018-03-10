using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core
{
	public interface IRepository<T>
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Create(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
