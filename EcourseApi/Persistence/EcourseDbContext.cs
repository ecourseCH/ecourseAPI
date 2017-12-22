using EcourseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcourseApi.Persistence
{
    /// <summary>
    /// This class handles the sqlite database
    /// </summary>
    public class EcourseDbContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Notice> Notice { get; set; }


        public EcourseDbContext(){
            Database.Migrate();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the path of the database here
            optionsBuilder.UseSqlite("Filename=./ecourse.sqlite");
        }


    }
}