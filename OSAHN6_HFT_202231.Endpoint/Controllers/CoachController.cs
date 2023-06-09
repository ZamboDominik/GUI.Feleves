using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OSAHN6_HFT_202231.Logic.Interfaces;
using OSAHN6_HFT_202231.Models;
using System.Collections.Generic;

namespace OSAHN6_HFT_202231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        ICoachLogic logic;
        readonly IHubContext<SignalRHub> hub;
        public CoachController(ICoachLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Coach> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Coach Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Coach value)
        {
            this.logic.Create(value);
            hub.Clients.All.SendAsync("CoachCreated", value);
            hub.Clients.All.SendAsync("StatUpdated", value);
        }

        [HttpPut]
        public void Put([FromBody] Coach value)
        {
            this.logic.Update(value);
            hub.Clients.All.SendAsync("CoachUpdated", value);
            hub.Clients.All.SendAsync("StatUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
            var toDelete = this.logic.Read(id);
            logic.Delete(id);
            hub.Clients.All.SendAsync("CoachDeleted", toDelete);
            hub.Clients.All.SendAsync("StatUpdated", toDelete);
        }
    }
}
