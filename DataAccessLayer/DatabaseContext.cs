using CommonEntities;
using System.Data.Entity;


namespace DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("dbconnection")
        {
        }

        public DbSet<Person> PersonList { get; set; }
    }
}