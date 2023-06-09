using Microsoft.Toolkit.Mvvm.Input;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUIWPF.ViewModels
{
    internal class StatViewModel:BasicViewModel
    {
        public ICollection<Player> Stars { get; set; }
        public ICollection<PositionStats> PosStats { get; set; }
        public string CoachName { get; set; }
        public ICommand SearchCoach { get; set; }   

        public string TeamString { get; set; }
        public string PosString { get; set; }
        public ICommand PlayerFind { get; set; }

        public string HighSal { get; set; }
        public ICommand SearchPlayer { get; set; }
        public StatViewModel()
        {
            Stars = restService.Get<Player>("/Stat/StarPlayers");
            PosStats = restService.Get<PositionStats>("/Stat/PositionStats");
            SearchCoach = new RelayCommand(() => 
            {
                try
                {
                    ICollection<Player> items = restService.Get<Player>($"/Stat/ListPlayersCoachedBy?name={CoachName}");
                    PlayersCoached w = new PlayersCoached(items);
                    w.Show();
                }
                catch (Exception e) { }
            });
            PlayerFind = new RelayCommand(() =>
            {
                try
                {
                    ICollection<Player> items = restService.Get<Player>($"/Stat/PlayerListByPos?team={TeamString}&Pos={PosString}");
                    PlayersCoached w = new PlayersCoached(items);
                    w.Show();
                }
                catch (Exception e) { }
            });
            SearchPlayer = new RelayCommand(() =>
            {
                try
                {
                    Player items = restService.GetSingle<Player>($"/Stat/HighestSalary?team={HighSal}");
                   MessageBox.Show(items.Name, $"Highest salary in {HighSal}", MessageBoxButton.OK);
                }
                catch (Exception e) { }
            });

        }
    }
}
