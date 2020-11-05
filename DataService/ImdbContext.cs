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
        public DbSet<Title_Genre> title_genre { get; set; }
        public DbSet<Akas_Type> akas_type { get; set; }
        public DbSet<Akas_Akas_Type> akas_akas_type { get; set; }
        
        public DbSet<Person_known_title> PersonKnownTitles { get; set; }
        
        public DbSet<Person_Person_Known_Title> PersonPersonKnownTitles { get; set; }
        
        public DbSet<Person_Profession> PersonProfessions { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Rating> rating { get; set; }
        public DbSet<Title_Rating> title_rating { get; set; }
        public DbSet<Search_History> search_history { get; set; }
        public DbSet<Person_Bookmarks> person_bookmarks { get; set; }
        public DbSet<Person_Bookmark_list> person_bookmark_list { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().ToTable("genre");
            modelBuilder.Entity<Genre>().Property(x => x.Id).HasColumnName("genre_id");
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasColumnName("genre_name");

            modelBuilder.Entity<Title_Genre>().ToTable("title_genre");
            modelBuilder.Entity<Title_Genre>().Property(x => x.Id).HasColumnName("title_genre_id");
            modelBuilder.Entity<Title_Genre>().Property(x => x.GenreId).HasColumnName("genre_id");
            modelBuilder.Entity<Title_Genre>().Property(x => x.TitleId).HasColumnName("title_id");
            
            modelBuilder.Entity<Users>().ToTable("users");
            modelBuilder.Entity<Users>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Users>().Property(x => x.Surname).HasColumnName("surname");
            modelBuilder.Entity<Users>().Property(x => x.Last_Name).HasColumnName("last_name");
            modelBuilder.Entity<Users>().Property(x => x.Age).HasColumnName("age");
            modelBuilder.Entity<Users>().Property(x => x.Email).HasColumnName("email");
            
            modelBuilder.Entity<Rating>().ToTable("rating");
            modelBuilder.Entity<Rating>().Property(x => x.Id).HasColumnName("rating_id");
            modelBuilder.Entity<Rating>().Property(x => x.User_Id).HasColumnName("user_id");
            modelBuilder.Entity<Rating>().Property(x => x.Title_Id).HasColumnName("title_id");
            modelBuilder.Entity<Rating>().Property(x => x.Rating_).HasColumnName("rating");
            modelBuilder.Entity<Rating>().HasKey(r => new {r.User_Id});
            
            //Person
            modelBuilder.Entity<Person>().ToTable("person");
            modelBuilder.Entity<Person>().Property(x => x.Id).HasColumnName("person_id");
            modelBuilder.Entity<Person>().Property(x => x.Name).HasColumnName("primary_name");
            modelBuilder.Entity<Person>().Property(x => x.BirthYear).HasColumnName("birth_year");
            modelBuilder.Entity<Person>().Property(x => x.DeathYear).HasColumnName("birth_year");
            
            modelBuilder.Entity<Person_Bookmarks>().ToTable("person_bookmarks");
            modelBuilder.Entity<Person_Bookmarks>().Property(x => x.Id).HasColumnName("bookmark_id");
            modelBuilder.Entity<Person_Bookmarks>().Property(x => x.List_Id).HasColumnName("list_id");
            modelBuilder.Entity<Person_Bookmarks>().Property(x => x.Person_Id).HasColumnName("person_id");

            modelBuilder.Entity<Person_Bookmark_list>().ToTable("person_bookmark_list");
            modelBuilder.Entity<Person_Bookmark_list>().Property(x => x.Id).HasColumnName("list_id");
            modelBuilder.Entity<Person_Bookmark_list>().Property(x => x.User_Id).HasColumnName("user_id");
            modelBuilder.Entity<Person_Bookmark_list>().Property(x => x.List_Name).HasColumnName("list_name");

            modelBuilder.Entity<Search_History>().ToTable("search_history");
            modelBuilder.Entity<Search_History>().Property(x => x.Id).HasColumnName("search_id");
            modelBuilder.Entity<Search_History>().Property(x => x.User_Id).HasColumnName("user_id");
            modelBuilder.Entity<Search_History>().Property(x => x.Search_Name).HasColumnName("search_name");
            modelBuilder.Entity<Search_History>().Property(x => x.Timestamp).HasColumnName("timestamp");
            
            modelBuilder.Entity<Akas_Type>().ToTable("akas_type");
            modelBuilder.Entity<Akas_Type>().Property(x => x.Id).HasColumnName("type_id");
            modelBuilder.Entity<Akas_Type>().Property(x => x.Name).HasColumnName("type_name");

            modelBuilder.Entity<Akas_Akas_Type>().ToTable("akas_akas_type");
            modelBuilder.Entity<Akas_Akas_Type>().Property(x => x.Id).HasColumnName("akas_akas_type_id");
            modelBuilder.Entity<Akas_Akas_Type>().Property(x => x.AkasAkasId).HasColumnName("akas_akas_id");
            modelBuilder.Entity<Akas_Akas_Type>().Property(x => x.AkasTypeId).HasColumnName("akas_type_id");
            
            //Akas_Attribute
            modelBuilder.Entity<Akas_Attribute>().ToTable("akas_attribute");
            modelBuilder.Entity<Akas_Attribute>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Akas_Attribute>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Akas_Attribute>().Property(x => x.AttributeName).HasColumnName("attribute_name");
            
            
            //Person_title_id
            modelBuilder.Entity<Person_known_title>().ToTable("person_known_title");
            modelBuilder.Entity<Person_known_title>().Property(x => x.Id).HasColumnName("person_title_id");
            modelBuilder.Entity<Person_known_title>().Property(x => x.TitleName).HasColumnName("title_name");
            
            //Person_person_known_title
            modelBuilder.Entity<Person_Person_Known_Title>().ToTable("person_person_known_title");
            modelBuilder.Entity<Person_Person_Known_Title>().Property(x => x.Id).HasColumnName("person_person_title_id");
            modelBuilder.Entity<Person_Person_Known_Title>().Property(x => x.PersonId).HasColumnName("person_id");
            modelBuilder.Entity<Person_Person_Known_Title>().Property(x => x.PersonTitleId).HasColumnName("person_title_id");

            //Person_profession
            modelBuilder.Entity<Person_Profession>().ToTable("person_profession");
            modelBuilder.Entity<Person_Profession>().Property(x => x.Id).HasColumnName("person_profession_id");
            modelBuilder.Entity<Person_Profession>().Property(x => x.PersonId).HasColumnName("person_id");
            modelBuilder.Entity<Person_Profession>().Property(x => x.ProfessionId).HasColumnName("profession_id");
            
            //Profession
            modelBuilder.Entity<Profession>().ToTable("profession");
            modelBuilder.Entity<Profession>().Property(x => x.Id).HasColumnName("profession_id");
            modelBuilder.Entity<Profession>().Property(x => x.ProfessionName).HasColumnName("profession_name");

            //Title_Rating
            modelBuilder.Entity<Title_Rating>().ToTable("title_rating");
            modelBuilder.Entity<Title_Rating>().Property(x => x.Id).HasColumnName("title_rating_id");
            modelBuilder.Entity<Title_Rating>().Property(x => x.Title_Id).HasColumnName("title_id");
            modelBuilder.Entity<Title_Rating>().Property(x => x.Average_Rating).HasColumnName("average_rating");
            modelBuilder.Entity<Title_Rating>().Property(x => x.Num_Votes).HasColumnName("num_votes");
            
           
            
            base.OnModelCreating(modelBuilder);
        }
    }
}