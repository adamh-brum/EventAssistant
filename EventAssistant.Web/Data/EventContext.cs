namespace EventAssistant.Web.Data
{
    using EventAssistant.Models;
    using Microsoft.EntityFrameworkCore;
    using MySQL.Data.EntityFrameworkCore.Extensions;

    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options)
        : base(options)
        { }

        public DbSet<EventViewModel> Employees { get; set; }
    }

    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class EventContextFactory
    {
        public static EventContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new EventContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}