using Microsoft.Toolkit.Mvvm.ComponentModel;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIWPF.ViewModels
{
    public class BasicViewModel:ObservableRecipient
    {
        public static RestCollection<Team> Teams { get; set; } = new RestCollection<Team>("http://localhost:5417/", "Team", "hub");
        public static RestCollection<Player> Players { get; set; } = new RestCollection<Player>("http://localhost:5417/", "Player", "hub");
        public static RestCollection<Coach> Coaches { get; set; } = new RestCollection<Coach>("http://localhost:5417/", "Coach", "hub");
        public static RestService restService { get; set; } = new RestService("http://localhost:5417/");

    }
}
