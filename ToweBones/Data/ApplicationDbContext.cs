using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToweBones.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ToweBones.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public DbSet<Devlog> Devlogs { get; set; }

		public override DbSet<User> Users { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}
}