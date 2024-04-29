using Microsoft.EntityFrameworkCore;
using Session_1.Contexts;

namespace Session_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // To apply Migrate

            // Way 1
            dbContexts dbContexts = new dbContexts();
            dbContexts.Database.Migrate();

            // Way 2 
            // Write in Package Manager Console: Update-Database

            // What will Happen: "up" method in all migration will be Applied as long as Not Applied before
        }
    }
}