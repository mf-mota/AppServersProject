using AppServersProject.Shared;

namespace AppServersProject.Client.Services.PlayerService
{
    public interface InterfacePlayerService
    {
        List<FootballPlayer> Players { get; set; } 
        List<Team> Teams { get; set; }
        Task GetTeams(); //to get to choose a Team when creating a Player
        Task GetPlayers();
        Task<FootballPlayer> GetPlayer(int id);
        Task CreatePlayer(FootballPlayer player);
        Task DeletePlayer(int id);
        Task ChangePlayer(FootballPlayer player);

    }
}
