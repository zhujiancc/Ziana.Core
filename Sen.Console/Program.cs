using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Sen.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Linq;
namespace Sen.Console
{
    class Program
    {
        /// <summary>
        /// 
        /// Bulk Operator
        ///     context.BulkInsert(entitiesList);                 context.BulkInsertAsync(entitiesList);
        ///     context.BulkInsertOrUpdate(entitiesList);         context.BulkInsertOrUpdateAsync(entitiesList);      //Upsert
        ///     context.BulkInsertOrUpdateOrDelete(entitiesList); context.BulkInsertOrUpdateOrDeleteAsync(entitiesList);//Sync
        ///     context.BulkUpdate(entitiesList);                 context.BulkUpdateAsync(entitiesList);
        ///     context.BulkDelete(entitiesList);                 context.BulkDeleteAsync(entitiesList);
        ///     context.BulkRead(entitiesList);                   context.BulkReadAsync(entitiesList);
        ///     context.Truncate<Entity>();                       context.TruncateAsync<Entity>();</summary>
        /// 
        /// Dapper Query
        /// 
        /// Migration Init
        ///     dotnet tool install --global dotnet-ef         
        ///     dotnet add package Microsoft.EntityFrameworkCore.Design
        ///     dotnet ef migrations add InitialCreate
        ///     dotnet ef database update
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            var context = new ConsoleDbContext();

            var console = new MyConsole
            {
                Content = "Hello World",
                CreatedBy = 1,
            };

            context.MyConsoles.Add(console);
            await context.SaveChangesAsync();

            var consoles = context.Query<MyConsole>("select Content,CreatedBy from MyConsoles").ToList();

            context.BulkInsert(consoles);

            System.Console.WriteLine(string.Join(",", consoles));
        }
    }


    public class ConsoleDbContext : SenDbContext
    {

        public DbSet<MyConsole> MyConsoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Administrator\Desktop\codes\Ziana\Ziana.Core\Sen.Console\blogging.db");
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class MyConsole : SenFullEntity
    {
        public string Content { get; set; }
    }
}
