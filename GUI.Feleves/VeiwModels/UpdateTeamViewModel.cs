using Microsoft.Toolkit.Mvvm.Input;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.Feleves.VeiwModels
{
    internal class UpdateTeamViewModel:BasicViewModel
    {
        public Team team { get; set; }
        public ICommand UpdateTeam { get; set; }
        public UpdateTeamViewModel()
        {
            team = actualTeam;
            UpdateTeam = new RelayCommand(() =>
            {
                foreach (Team play in Teams.Where(x => x.Id.Equals(actualTeam.Id)).Select(x => x))
                {
                    play.Name = team.Name;
                    play.LuxuryTax = team.LuxuryTax;
                    try
                    {
                        Teams.Update(play);
                    }
                    catch (Exception e) { };
                    
                }
            }
            );

        }

    }
}
