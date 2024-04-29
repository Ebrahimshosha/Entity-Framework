using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2_OneToOne
{
	public class AppDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = .; DataBase = EX10EF; Trusted_Connection = True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Blog>()
				.HasOne(b => b.BlogImage)
				.WithOne(i => i.Blog)
				.HasForeignKey<BlogImage>(i => i.BlogId)
				.OnDelete(DeleteBehavior.Restrict);

		}

		public DbSet<Blog> Blogs { get; set; }
		public DbSet<BlogImage> BlogImages { get; set; }
	}

	public class Blog
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public BlogImage BlogImage { get; set; }
    }

	public class BlogImage
	{
		public int Id { get; set; }
		public string Image { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
	}
}
