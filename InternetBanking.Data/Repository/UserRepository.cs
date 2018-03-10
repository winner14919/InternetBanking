using InternetBanking.Core;
using InternetBanking.Core.User;
using InternetBanking.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Data.Repository
{
	public class UserRepository : IRepository<User>
	{
		private readonly UserDbContext _context;
		private readonly DbSet<User> _dbSet;

		public UserRepository(UserDbContext context)
		{
			this._context = context;
			this._dbSet = _context.Set<User>();
		}

		public void Create(User user)
		{
			_dbSet.Add(user);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var userToDelete = _dbSet.Find(id);
			_dbSet.Remove(userToDelete);
			_context.SaveChanges();
		}

		public IEnumerable<User> GetAll()
		{
			return _dbSet.ToListAsync<User>().Result;
		}

		public User GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public void Update(User user)
		{
			_dbSet.Attach(user);
			_context.Entry(user).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}
