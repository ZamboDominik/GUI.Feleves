using Microsoft.AspNetCore.Mvc;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OSAHN6_HFT_202231.Client
{
    internal class NonCrudService
    {
        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }
        public void StarPlayers()
        {
            var items = rest.Get<Player>($"Stat/StarPlayers");
            foreach (var item in items) 
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void PosStats() 
        {
            var items = rest.Get<PositionStats>($"Stat/PositionStats");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void PlayersByPos()
        {
            Console.WriteLine("Position:");
            string pos = Console.ReadLine();
            Console.WriteLine("Team");
            string Team = Console.ReadLine();
            var items = rest.Get<Player>($"Stat/PlayerListByPos?team={Team}&Pos={pos}");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void ListCoachedBy() 
        {
            Console.WriteLine("Coach:");
            string coach = Console.ReadLine();
            var items = rest.Get<Player>($"Stat/ListPlayersCoachedBy?name={coach}");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void HighestSalary()
        {
            Console.WriteLine("Team:");
            string team = Console.ReadLine();
            var item = rest.GetSingle<Player>($"Stat/HighestSalary?team={team}");
            
                Console.WriteLine(item);
            
            Console.ReadLine();
        }
    }
}
