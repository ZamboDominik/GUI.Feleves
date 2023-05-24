using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OSAHN6_HFT_202231.Logic.Interfaces;
using OSAHN6_HFT_202231.Models;
using System.Linq;

namespace OSAHN6_HFT_202231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ITeamLogic logic;
        IHubContext<SignalRHub> hub;
        public StatController(ITeamLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        [HttpGet]
        public IQueryable StarPlayers()
        {
            return logic.StarPlayers();
        }
        [HttpGet]
        public IQueryable PositionStats() { return logic.PositionStats(); }
        [HttpGet/*("{name}")*/]
        public IQueryable ListPlayersCoachedBy([FromQuery] string name) { return logic.ListPlayersCoachedBy(name); }
        [HttpGet/*("{team}/{Pos}")*/]
        public IQueryable PlayerListByPos([FromQuery] string team, [FromQuery] string Pos) { return logic.PlayerListByPos(team, Pos); }
        [HttpGet/*("{team}")*/]
        public Player HighestSalary([FromQuery] string team) { return logic.HighestSalary(team); }
    }
}
