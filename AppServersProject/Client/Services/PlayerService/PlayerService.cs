using AppServersProject.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AppServersProject.Client.Services.PlayerService
{
    public class PlayerService : InterfacePlayerService
    {
        private readonly HttpClient http;
        private readonly NavigationManager navigationManager;

        public PlayerService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
        }
        public List<FootballPlayer> Players { get; set; } = new List<FootballPlayer>();
        public List<Team> Teams { get; set; } = new List<Team>();

        public async Task<FootballPlayer> GetPlayer(int id)
        {
            var get_result = await http.GetFromJsonAsync<FootballPlayer>($"api/FootballPlayer/{id}"); //why is this making a problem????
            if (get_result is not null)
                return get_result;
            throw new Exception("No such player in the DB");
        }
        public async Task GetTeams()
        {
            var get_result = await http.GetFromJsonAsync<List<Team>>("api/FootballPlayer/Teams"); //why is this making a problem????
            if (get_result is not null)
                Teams = get_result;
        }
        public async Task GetPlayers()
        {
            var get_result = await http.GetFromJsonAsync<List<FootballPlayer>>("api/FootballPlayer"); //why is this making a problem????
            if (get_result is not null)
                Players = get_result;
        }

        public async Task CreatePlayer(FootballPlayer player)
        {
            var get_result = await http.PostAsJsonAsync($"api/FootballPlayer", player);
            await SetPlayers(get_result);
        }

        private async Task SetPlayers(HttpResponseMessage get_result)
        {
            var rpl = await get_result.Content.ReadFromJsonAsync<List<FootballPlayer>>();
            Players = rpl;
            navigationManager.NavigateTo("FootballPlayers");
        }
        public async Task ChangePlayer(FootballPlayer player)
        {
            var get_result = await http.PutAsJsonAsync($"api/footballplayer/{player.Id}", player);
            await SetPlayers(get_result);
        }

        public async Task DeletePlayer(int id)
        {
            var get_result = await http.DeleteAsync($"api/footballplayer/{id}");
            await SetPlayers(get_result);
        }
    }
}
