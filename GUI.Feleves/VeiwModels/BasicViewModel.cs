using Microsoft.Toolkit.Mvvm.ComponentModel;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Feleves.VeiwModels
{
    internal class BasicViewModel : ObservableRecipient
    {
        protected static Player actualPlayer;
        protected static Team actualTeam;
        protected static Coach actualCoach;
        public static RestCollection<Team> Teams { get; set; } = new RestCollection<Team>("http://localhost:5417/", "Team");
        public static RestCollection<Player> Players { get; set; } = new RestCollection<Player>("http://localhost:5417/", "Player", "hub");
        public static RestCollection<Coach> Coaches { get; set; } = new RestCollection<Coach>("http://localhost:5417/", "Coach", "hub");
        public BasicViewModel()
        {
           // Teams = new RestCollection<Team>("http://localhost:5417/", "Team","hub");
          
            //Coaches = new RestCollection<Coach>("http://localhost:5417/", "Coach");
        }
    }
}
