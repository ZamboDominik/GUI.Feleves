using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    internal class PlayerCreatorViewModel : BasicViewModel
    {
        private string salary;

        public string Salary
        {
            get { return salary; }
            set
            {
                if (value != null)
                {
                    salary = value;
                }
                OnPropertyChanged();
            }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set
            {
                if (value != null) position = value;
                OnPropertyChanged();

            }
        }
        private string nev;

        public string Nev
        {
            get { return nev; }
            set { if (value != null) nev = value; OnPropertyChanged(); }
        }
        private string teamID;

        public string TeamID
        {
            get { return teamID; }
            set { if (value != null) teamID = value; OnPropertyChanged(); }
        }
        public ICommand CreatePlayer { get; set; }

        public PlayerCreatorViewModel()
        {

            CreatePlayer = new RelayCommand(() =>
            {
                try
                {
                    createPlayer();
                    Players.Add(actualPlayer);
                }
                catch { }
            });
        }
        private void createPlayer()
        {
            
            OnPropertyChanged();
            if (nev != null)
            {
                try
                {
                    Player player = new Player()
                    {
                        Name = nev,
                        Position = Position,
                        TeamID = int.Parse(teamID),
                        Salary = int.Parse(salary)
                    };
                    actualPlayer = player;
                } catch { }
                
            }
        }
    }
}
