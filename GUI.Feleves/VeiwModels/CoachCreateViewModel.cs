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
    internal class CoachCreateViewModel:BasicViewModel
    {
        public Coach coach { get; set; }
        public ICommand CreateCoach { get; set; }
        public CoachCreateViewModel()
        {
            coach = new Coach();
            CreateCoach = new RelayCommand(() =>
            {
                try
                {
                    foreach (Coach c in Coaches.Where(x => x.TeamID.Equals(coach.TeamID)))
                    {
                        c.TeamID = 0;
                        Coaches.Update(c);
                    };

                    createCoach();
                    Coaches.Add(actualCoach);

                }
                catch { }

            }
             );
        }
        private void createCoach()
        {
            OnPropertyChanged();
            try
            {
                if (coach.CoachName != null)
                {
                    Coach nCoach = new Coach()
                    {
                        CoachName = coach.CoachName,
                        TeamID = coach.TeamID,
                        Salary = coach.Salary,

                    };
                    actualCoach = nCoach;
                }
            }
            catch { }
        }
    }
}
