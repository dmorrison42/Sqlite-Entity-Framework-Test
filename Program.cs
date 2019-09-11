using System;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Database.Migrate();
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet", Description = "ADO Blog", Publisher = "Microsoft" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0} - {1} - {2}", blog.Url, blog.Description, blog.Publisher);
                }
            }
        }
    }
}
