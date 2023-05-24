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
    internal class UpdatePlayerViewModel:BasicViewModel
    {
        public Player player { get; set; }
        public ICommand UpdatePlayer { get; set; }
        public UpdatePlayerViewModel()
        {
            player = actualPlayer;
            UpdatePlayer = new RelayCommand(() =>
            {

                 foreach (Player play in Players.Where(x => x.PlayerId.Equals(actualPlayer.PlayerId)).Select(x => x)) 
                 {
                    try
                    {
                        play.Name = player.Name;
                        play.Salary = player.Salary;
                        play.TeamID = player.TeamID;
                        play.Position = player.Position;
                        Players.Update(play);
                    }
                    catch (Exception e) { }
                 }
            }
            );
        }
    }
}
