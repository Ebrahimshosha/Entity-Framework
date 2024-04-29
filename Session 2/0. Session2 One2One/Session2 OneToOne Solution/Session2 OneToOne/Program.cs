namespace Session2_OneToOne
{
	internal class Program
	{
		static void Main(string[] args)
		{
			AppDbContext db = new AppDbContext();

			var Blog = new Blog()
			{
				
				Name = "blog1" 
			};
			db.Blogs.Add(Blog);
			db.SaveChanges();
		}
	}
}