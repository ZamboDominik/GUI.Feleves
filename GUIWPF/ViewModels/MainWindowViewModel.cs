using Microsoft.Toolkit.Mvvm.Input;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUIWPF.ViewModels
{
    public class MainWindowViewModel:BasicViewModel
    {
        public ICommand UpdateTeam { get; set; }
        public ICommand CreateTeam { get; set; }
        public ICommand DeleteTeam { get; set; }

        public ICommand UpdatePlayer { get; set; }
        public ICommand CreatePlayer { get; set; }
        public ICommand DeletePlayer { get; set; }


        public ICommand UpdateCoach { get; set; }
        public ICommand CreateCoach { get; set; }
        public ICommand DeleteCoach { get; set; }

        public string CreateteamString { get; set; } = "";
        public string TaxString { get; set; } = "";


        public string NameString { get; set; } = "";
        public string PositionString { get; set; } = "";
        public string SalaryString { get; set; } = "";
        public string TeamIDString { get; set; } = "";

        public string CNameString { get; set; } = "";
        public string CSalaryString { get; set; } = "";
        public string CTeamIDString { get; set; } = "";




        private Team selectedTeam;
        public  ICollection<Player> players { get; set; }
        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                     selectedTeam = new Team() { Id = value.Id, Name = value.Name, LuxuryTax = value.LuxuryTax };
                        players = Players.Where(x => x.TeamID.Equals(selectedTeam.Id)).ToList();
                    try
                    {
                        selectedCoach = Coaches.Where(x => x.TeamID.Equals(selectedTeam.Id)).First();
                    }
                    catch (Exception e) { selectedCoach = new Coach(); }
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(SelectedCoach));
                        OnPropertyChanged(nameof(players));
                        (DeleteTeam as RelayCommand).NotifyCanExecuteChanged();
                   
                   
                }
            }
        }
        private Coach selectedCoach;
        public Coach SelectedCoach
        {
            get { return selectedCoach; }
            set
            {
                if (value != null)
                {
                    selectedCoach = new Coach() { CoachId = value.CoachId, CoachName = value.CoachName, Salary = value.Salary };
                    players = Players.Where(x => x.TeamID.Equals(selectedTeam.Id)).ToList();
                    OnPropertyChanged();
                    

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
                    selectedPlayer = new Player()
                    {
                        PlayerId = value.PlayerId,
                        TeamID = value.TeamID,
                        Name = value.Name,
                        Salary = value.Salary,
                        Position = value.Position
                    
                    };
                    OnPropertyChanged();
                     (DeletePlayer as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public MainWindowViewModel()
        {

            CreateTeam = new RelayCommand(() =>
            {
                try
                {
                    if (CreateteamString.Length >= 1 && TaxString.Length >= 1)
                        Teams.Add(new Team() { Name = CreateteamString,LuxuryTax=int.Parse(TaxString) });
                }
                catch (Exception e) { }

            }
            );
            CreatePlayer = new RelayCommand(() =>
            {
                try
                {
                    if (NameString.Length >=1 && SalaryString.Length>0 && PositionString.Length >=1 && TeamIDString.Length >0)
                        Players.Add(new Player() { Name = NameString, Salary=int.Parse(SalaryString),TeamID = int.Parse(TeamIDString),Position=PositionString});
                }
                catch (Exception e) { }

            }
            );
            CreateCoach = new RelayCommand(() =>
            {
                try
                {
                    if (CNameString.Length >= 1 && CSalaryString.Length > 0 && CTeamIDString.Length > 0)
                        Coaches.Add(new Coach() { CoachName = CNameString, Salary = int.Parse(CSalaryString), TeamID = int.Parse(CTeamIDString)});
                }
                catch (Exception e) { }

            }
            );


            UpdateTeam = new RelayCommand(() => { try {if(SelectedTeam.LuxuryTax > 0 && SelectedTeam.Name.Length >= 1) Teams.Update(SelectedTeam); } catch (Exception e) { } });
            UpdatePlayer = new RelayCommand(() =>
            {
                try
                {
                    if (selectedPlayer != null && SelectedPlayer.Name.Length >= 1 && SelectedPlayer.Salary > 0 && SelectedPlayer.Position.Length >= 1 && SelectedPlayer.TeamID > 0)
                        Players.Update(SelectedPlayer);
                        players = Players.Where(x => x.TeamID.Equals(selectedTeam.Id)).ToList();
                }
                catch (Exception e) { }

            }
           );
            UpdateCoach = new RelayCommand(() =>
            {
                try
                {
                    if (selectedCoach != null && SelectedCoach.CoachName.Length >= 1 && SelectedCoach.Salary > 0 && SelectedCoach.TeamID > 0)
                        Coaches.Update(SelectedCoach);
                    //players = Players.Where(x => x.TeamID.Equals(selectedTeam.Id)).ToList();
                }
                catch (Exception e) { }

            }
          );
            DeleteTeam = new RelayCommand(() => { try { if (selectedTeam != null && SelectedTeam.Id != 0) 
                    {         
                        Teams.Delete(SelectedTeam.Id);
                        SelectedPlayer = new Player();
                        SelectedCoach = new Coach();
                        OnPropertyChanged(nameof(Teams));
                        SelectedTeam.Id = 0; 
                    }
                } catch (Exception e) { } });
            DeletePlayer = new RelayCommand(() => {
                try
                {
                    if (SelectedPlayer.PlayerId != 0)
                    {
                        Players.Delete(SelectedPlayer.PlayerId);
                        OnPropertyChanged(nameof(players));
                        SelectedPlayer.PlayerId = 0;
                    }
                }
                catch (Exception e) { }
            });
            DeleteCoach = new RelayCommand(() => {
                try
                {
                    if (SelectedCoach.CoachId != 0)
                    {
                        Coaches.Delete(SelectedCoach.CoachId);
                        SelectedCoach.CoachId = 0;
                    }
                }
                catch (Exception e) { }
            });
            StatWindow = new RelayCommand(() => {
                Window stat = new StatWindow();
                stat.Show();
            });

        }
       public ICommand StatWindow { get; set; }
    }

    
    }

