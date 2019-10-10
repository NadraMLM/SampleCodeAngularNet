using CodeSample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeSample.Data
{
	public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
		public DbSet<Client> Clients { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Client>().ToTable("Clients");

			builder.Entity<IdentityUser>().Property(s => s.Email).IsRequired();
			builder.Entity<IdentityUser>().HasIndex(s => s.Email).IsUnique();
			builder.Entity<IdentityUser>().Property(s => s.UserName).IsRequired();

			builder.Entity<Client>().Property(s => s.IdentityId).IsRequired();
			builder.Entity<Client>().HasKey(e => new { e.Id });
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

	}
}
