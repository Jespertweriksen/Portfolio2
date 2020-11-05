using DataService.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DataService
{
    public class ImdbContext : DbContext
    {
        PostgresSQL_Connect_String myConnection = new PostgresSQL_Connect_String();

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseNpgsql(myConnection.ToString());
        }

        public DbSet<Genre> genre { get; set; }
        
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().ToTable("genre");
            modelBuilder.Entity<Genre>().Property(x => x.Id).HasColumnName("genre_id");
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasColumnName("genre_name");

            modelBuilder.Entity<Title_Genre>().ToTable("title_genre");
            modelBuilder.Entity<Title_Genre>().Property(x => x.Id).HasColumnName("title_genre_id");
            modelBuilder.Entity<Title_Genre>().Property(x => x.GenreId).HasColumnName("genre_id");
            modelBuilder.Entity<Title_Genre>().Property(x => x.TitleId).HasColumnName("title_id");
            
            modelBuilder.Entity<Person>().ToTable("person");
            modelBuilder.Entity<Person>().Property(x => x.Id).HasColumnName("person_id");
            modelBuilder.Entity<Person>().Property(x => x.Name).HasColumnName("primary_name");
            modelBuilder.Entity<Person>().Property(x => x.BirthYear).HasColumnName("birth_year");
            modelBuilder.Entity<Person>().Property(x => x.DeathYear).HasColumnName("birth_year");
            
            

            
            
            
            
            
            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}