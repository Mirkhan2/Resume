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
		public DbSet<CustomerFeedBack> customerFeedBacks { get; set; }
		public DbSet<CustomerLogo> CustomerLogos { get; set; }
		public DbSet<Education> Educations { get; set; }
		public DbSet<Experience> Experiences { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<Portofolio> Portofolios { get; set; }
		public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
		public DbSet<SocialMedia> SocialMedias { get; set; }
		public DbSet<Information> information { get; set; }
		public DbSet<Message> Messages { get; set; }


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
