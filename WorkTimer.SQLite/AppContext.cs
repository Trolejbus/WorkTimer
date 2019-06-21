using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using WorkTimer.SQLite.Entities;

namespace WorkTimer.SQLite
{
    internal class AppContext : DbContext
    {
        public AppContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = @"C:\Test\WorkTimerDB.db",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WorkTask> WorkTasks { get; set; }
    }
}
