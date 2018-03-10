using InternetBanking.Core.Order;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Data.Context
{
	public class TransactionDbContext : DbContext
    {
		public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
		{

		}

		public DbSet<InternetBanking.Core.Order.TransactionOrder> Order { get; set; }
    }
}
