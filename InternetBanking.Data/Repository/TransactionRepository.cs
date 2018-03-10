using InternetBanking.Core;
using InternetBanking.Core.Order;
using InternetBanking.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InternetBanking.Data.Repository
{
	public class TransactionRepository : IRepository<TransactionOrder>
	{
		private readonly TransactionDbContext _context;
		private readonly DbSet<TransactionOrder> _dbSet;

		public TransactionRepository(TransactionDbContext context)
		{
			this._context = context;
			this._dbSet = _context.Set<TransactionOrder>();
		}

		public void Create(TransactionOrder order)
		{
			_dbSet.Add(order);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var orderToDelete = _dbSet.Find(id);
			_dbSet.Remove(orderToDelete);
			_context.SaveChanges();
		}

		public IEnumerable<TransactionOrder> GetAll()
		{
			return _dbSet.ToList();
		}

		public TransactionOrder GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public void Update(TransactionOrder order)
		{
			_dbSet.Attach(order);
			_context.Entry(order).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public IEnumerable<TransactionOrder> GetBuyUser(string userId)
		{
			var orders = this.GetAll().Where(order => order.UserId == userId);
			return orders;
		}
	}
}
