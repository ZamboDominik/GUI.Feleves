using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using OSAHN6_HFT_202231.Logic.Interfaces;
using OSAHN6_HFT_202231.Models;
using System.Collections.Generic;
using System.Linq;

namespace OSAHN6_HFT_202231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        ITeamLogic logic;
        readonly IHubContext<SignalRHub> hub;
        public TeamController(ITeamLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return this.logic.ReadAll();

        }

        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Team value)
        {
            this.logic.Create(value);
            hub.Clients.All.SendAsync("TeamCreated", value);
            hub.Clients.All.SendAsync("StatUpdated", value);
        }

        [HttpPut]
        public void Put([FromBody] Team value)
        {
            this.logic.Update(value);
            hub.Clients.All.SendAsync("TeamUpdated", value);
            hub.Clients.All.SendAsync("StatUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
            var toDelete = this.logic.Read(id);
            logic.Delete(id);
            hub.Clients.All.SendAsync("TeamDeleted", toDelete);
            hub.Clients.All.SendAsync("StatUpdated", toDelete);
        }
        /*[HttpGet]
        public void StarPlayers() 
        {
            this.logic.StarPlayers();
        }
        [HttpGet]
        public void PositionStats() { this.logic.PositionStats(); }
        [HttpGet("{name}")]
        public void ListPlayersCoachedBy(string name) { this.ListPlayersCoachedBy(name); }
        [HttpGet("{team}/{Pos}")]
        public void PlayerListByPos(string team, string Pos) { this.logic.PlayerListByPos(team, Pos); }
        [HttpGet("{team}")]
        public void HighestSalary(string team) { this.logic.HighestSalary(team); }*/
    }
}
