using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI.Feleves.VeiwModels
{
    internal class MainWindowViewModel : BasicViewModel
    {

        //public ICommand CreateTeam { get; set; }
        public ICommand UpdateTeam { get; set; }
        public ICommand DeleteTeam { get; set; }

        //public ICommand CreatePlayer { get; set; }
        public ICommand UpdatePlayer { get; set; }
        public ICommand DeletePlayer { get; set; }

        public ICommand CreateCoach { get; set; }
        public ICommand UpdateCoach { get; set; }
        public ICommand DeleteCoach { get; set; }

        public ICommand Frissit { get; set; }

        private Team selectedTeam;
        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    selectedTeam = Teams.Where(x => x.Id.Equals(value.Id)).First();
                    players = Players.Where(x => x.TeamID.Equals(selectedTeam.Id)).ToList();
                    headCoach = Coaches.Where(c => c.TeamID.Equals(SelectedTeam.Id)).FirstOrDefault();
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedPlayers));
                    OnPropertyChanged(nameof(SelectedCoach));
                    //  (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != null)
                {
                    selectedPlayer = Players.Where(x => x.Name.Equals(value.Name)).First();
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedPlayer));      
                    OnPropertyChanged(nameof(SelectedPlayers));
                    OnPropertyChanged(nameof(SelectedCoach));
                    //  (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }





        private List<Player> players = new List<Player>();
        public List<Player> SelectedPlayers
        {
            get { return players; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(nameof(SelectedPlayer));
                    OnPropertyChanged(nameof(SelectedPlayers));
                    OnPropertyChanged(nameof(SelectedCoach));
                    OnPropertyChanged();
                    //  (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Coach headCoach = null;
        public Coach SelectedCoach
        {
            get { return headCoach; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged();
                    //  (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        //public RestCollection<Team> team { get; set; }
        public ICommand ShowStats { get; set; }
        public MainWindowViewModel()
        {
            /*team = Teams;
            Frissit = new RelayCommand(() =>
            {
                team = Teams;
                players = Players.Where(x => x.TeamID.Equals(selectedTeam.Id)).ToList();
                headCoach = Coaches.Where(c => c.TeamID.Equals(SelectedTeam.Id)).FirstOrDefault();
            }

            );*/
            ShowStats = new RelayCommand(() =>
            {
                //actualCoach = SelectedCoach;
                Window w = new StatWindow();
                w.Show();
            });
            CreateCoach = new RelayCommand(() =>
            {
                actualCoach = SelectedCoach;
                Window w = new CreateCoachWindow();
                w.Show();
            });
            UpdateTeam = new RelayCommand(() =>
            {
                actualTeam = SelectedTeam;
                Window w = new UpdateTeamWindow();
                w.Show();
            });
            UpdatePlayer = new RelayCommand(() =>
            {
                actualPlayer = SelectedPlayer;
                Window w = new UpdatePlayerWindow();
                w.Show();
            });
            UpdateCoach = new RelayCommand(() =>
            {
                actualCoach = SelectedCoach;
                Window w = new UpdateCoach();
                w.Show();
            });
            DeleteTeam = new RelayCommand(() =>
            {
                Teams.Delete(SelectedTeam.Id);
            }
            );
            DeletePlayer = new RelayCommand(() =>
            {
                Players.Delete(SelectedPlayer.PlayerId);
                
            }
            );
            DeleteCoach = new RelayCommand(() =>
            {
                Coaches.Delete(SelectedCoach.CoachId);
            }
           );

        }
    }
}
