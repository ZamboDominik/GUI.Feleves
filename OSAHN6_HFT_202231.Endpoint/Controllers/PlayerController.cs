﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OSAHN6_HFT_202231.Logic.Interfaces;
using OSAHN6_HFT_202231.Models;
using System.Collections.Generic;

namespace OSAHN6_HFT_202231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayerLogic logic;
        readonly IHubContext<SignalRHub> hub;
        public PlayerController(IPlayerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Player> ReadAll()
        {
            return this.logic.ReadAll();

        }

        [HttpGet("{id}")]
        public Player Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Player value)
        {
            this.logic.Create(value);
            hub.Clients.All.SendAsync("PlayerCreated", value);
            hub.Clients.All.SendAsync("StatUpdated", value);
        }

        [HttpPut]
        public void Put([FromBody] Player value)
        {
            this.logic.Update(value);
            hub.Clients.All.SendAsync("PlayerUpdated", value);
            hub.Clients.All.SendAsync("StatUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
            var toDelete = this.logic.Read(id);
            logic.Delete(id);
            hub.Clients.All.SendAsync("PlayerDeleted", toDelete);
            hub.Clients.All.SendAsync("StatUpdated", toDelete);
        }
    }
}
