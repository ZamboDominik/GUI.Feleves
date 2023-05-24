using Microsoft.Toolkit.Mvvm.Input;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.Feleves.VeiwModels
{
    internal class StatViewModel : BasicViewModel
    {
        public NonCrudCollection<Player> eredmeny { get; set; }
        public NonCrudCollection<PositionStats> positionstats { get; set; }
        public NonCrudCollection<Player> Coached { get; set; }
        public NonCrudCollection<Player> DallasPGs { get; set; }
       // public NonCrudCollection<Player> GSWStar { get; set; }
        private RestService restService { get; set; }
        public Player GSWStar { get; set; }

        public ICommand SearchPlayers { get; set; }
        public string Name { get; set; }
        public StatViewModel()
        {
            restService = new RestService("http://localhost:5417/");
            GSWStar = restService.GetSingle<Player>($"Stat/HighestSalary?team=Golden State Warriors");
            Coached = new NonCrudCollection<Player>("http://localhost:5417/", $"Stat/ListPlayersCoachedBy", $"?name=Steve Kerr", "hub");
            eredmeny = new NonCrudCollection<Player>("http://localhost:5417/", $"Stat/StarPlayers", "", "hub");
            positionstats = new NonCrudCollection<PositionStats>("http://localhost:5417/", $"Stat/PositionStats", "", "hub");
            DallasPGs = new NonCrudCollection<Player>("http://localhost:5417/", $"Stat/PlayerListByPos", "?team=Dallas Maverics&Pos=PG", "hub");
             //GSWStar = new NonCrudCollection<Player>("http://localhost:5417/", $"Stat/HighestSalary", "?team=Golden State Warriors", "hub");

        }
    }
}
