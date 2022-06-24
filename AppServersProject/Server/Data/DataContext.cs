namespace AppServersProject.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
            new Team
            {
                Id = 1,
                Name = "Real Madrid",
                League = "La Liga",
                Coach = "Erik ten Hag"
            },
            new Team
            {
                Id = 2,
                Name = "Bayern Munich",
                League = "Bundesliga",
                Coach = "Julian Nagelsmann"
            },
            new Team
            {
                Id = 3,
                Name = "Paris Saint Germain",
                League = "Ligue 1",
                Coach = "Mauricio Pochettino"
            },
            new Team
            {
                Id = 4,
                Name = "FC Barcelona",
                League = "La Liga",
                Coach = "Xavi"
            }
            );
            modelBuilder.Entity<FootballPlayer>().HasData(
                new FootballPlayer { Id = 1, Name = "Toni", Surname = "Kroos", Position = "Midfielder", TeamId = 1 },
                new FootballPlayer { Id = 2, Name = "Karim", Surname = "Benzema", Position = "Striker", TeamId = 1 },
                new FootballPlayer { Id = 3, Name = "Robert", Surname = "Lewandowski", Position = "Striker", TeamId = 2 },
                new FootballPlayer { Id = 4, Name = "Jordi", Surname = "Alves", Position = "Left-back", TeamId = 4 }
            );
        }
    public DbSet<FootballPlayer> FootballPlayers { get; set; }
    public DbSet<Team> Teams { get; set; }

    }
}
                
            

