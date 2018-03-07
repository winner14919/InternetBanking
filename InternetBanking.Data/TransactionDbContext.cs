using InternetBanking.Core.TransactionService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Data
{
    public class TransactionDbContext : DbContext
    {
		public DbSet<TransactionOrder> Order { get; set; }
    }
}
