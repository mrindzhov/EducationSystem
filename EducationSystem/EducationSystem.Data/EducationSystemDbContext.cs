namespace EducationSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EducationSystemDbContext : DbContext
    {
        // Your context has been configured to use a 'EducationSystemDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EducationSystem.Data.EducationSystemDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EducationSystemDbContext' 
        // connection string in the application configuration file.
        public EducationSystemDbContext()
            : base("name=EducationSystemDbContext")
        {
        }

        public static EducationSystemDbContext Create()
        {
            return new EducationSystemDbContext();
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}