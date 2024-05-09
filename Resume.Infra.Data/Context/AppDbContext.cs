using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;

namespace Resume.Infra.Data.Context
{
	public class AppDbContext : DbContext
	{
		#region Constructor
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		#endregion
		#region DbSet
		public DbSet<ThingIDo> ThingIDos { get; set; }

		#endregion
		#region On Model Cretaing
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}


			base.OnModelCreating(modelBuilder);
		}
		#endregion



	}
}
