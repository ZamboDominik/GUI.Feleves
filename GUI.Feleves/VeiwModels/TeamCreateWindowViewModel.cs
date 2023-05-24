using GUI.Feleves.VeiwModels;
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
    internal class TeamCreateWindowViewModel:BasicViewModel
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

        
        private string nev;

        public string Nev
        {
            get { return nev; }
            set { if (value != null) nev = value; OnPropertyChanged(); }
        }
      

        
        public ICommand CreateTeam { get; set; }


        public TeamCreateWindowViewModel()
        {

            CreateTeam = new RelayCommand(() =>
            {
                try
                {
                    createTeam();
                    Teams.Add(actualTeam);
                    OnPropertyChanged(nameof(Teams));
                }
                catch { }
            });
        }
        private void createTeam()
        {
          
            if (nev != null || int.Parse(salary) <= 0)
            {
                Team team = new Team()
                {
                    Name = nev, 
                    //TeamID = int.Parse(teamID),
                    LuxuryTax = int.Parse(salary)
                };
                actualTeam = team;
                
            }
        }
    }
}
