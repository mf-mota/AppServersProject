using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppServersProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private readonly DataContext thiscontext;
        public FootballPlayerController(DataContext context)
        {
            thiscontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballPlayer>>> GetPlayers()
        {
            var players = await thiscontext.FootballPlayers.Include(h => h.Team).ToListAsync();  //again, without include, doesnt return the players
            return Ok(players); //return status code 200

        }
        [HttpGet("{id}")]
        // or we could add the route attribute [Route("id")]
        public async Task<ActionResult<FootballPlayer>> GetPlayer(int id)
        {
            var player = await thiscontext.FootballPlayers
                .Include(player => player.Team)  //so that the team will not be null
                .FirstOrDefaultAsync(p => p.Id == id);
            if (player is null)
            {
                return NotFound("No such player in the DB");
            }
            return Ok(player);
        }
        [HttpGet("teams")]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            var teams = await thiscontext.Teams.ToListAsync();
            return Ok(teams); //return status code 200
        }
        [HttpPost]
        // or we could add the route attribute [Route("id")]
        public async Task<ActionResult<FootballPlayer>> CreatePlayer(FootballPlayer player)
        {
            player.Team = null;
            thiscontext.FootballPlayers.Add(player);
            await thiscontext.SaveChangesAsync();
            return Ok(await GetDbPlayers());
        }
        [HttpPut("{id}")] //update existing player
        public async Task<ActionResult<FootballPlayer>> ChangePlayer(FootballPlayer player, int id)
        {
            var dbPlayer = await thiscontext.FootballPlayers
                .Include(player => player.Team).FirstOrDefaultAsync(player => player.Id == id);
            if (dbPlayer is null)
                return NotFound("No such Player in the Database");

            dbPlayer.Name = player.Name;
            dbPlayer.Surname = player.Surname;
            dbPlayer.Position = player.Position;
            dbPlayer.TeamId = player.TeamId;
            
            await thiscontext.SaveChangesAsync();
            return Ok(await GetDbPlayers());
        }
        [HttpDelete("{id}")] //delete existing player
        public async Task<ActionResult<List<FootballPlayer>>> DeletePlayer(int id)
        {
            var dbPlayer = await thiscontext.FootballPlayers
                .Include(player => player.Team).FirstOrDefaultAsync(player => player.Id == id);
            if (dbPlayer is null)
                return NotFound("No such Player in the Database");

            thiscontext.FootballPlayers.Remove(dbPlayer);
            await thiscontext.SaveChangesAsync();
            return Ok(await GetDbPlayers());
        }
        private async Task<List<FootballPlayer>> GetDbPlayers()
        { 
            return await thiscontext.FootballPlayers.Include(player => player.Team).ToListAsync();
        }
    }
}
