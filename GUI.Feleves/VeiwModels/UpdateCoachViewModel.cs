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
    internal class UpdateCoachViewModel:BasicViewModel
    {
       public Coach coach { get; set; }
       public ICommand UpdateCoach { get; set; }
        public UpdateCoachViewModel()
        {
            coach = actualCoach;
            UpdateCoach = new RelayCommand(() =>
            {

                if (coach.TeamID != actualCoach.TeamID)
                {
                    foreach (Coach play in Coaches.Where(x => x.TeamID.Equals(actualCoach.TeamID)).Select(x => x))
                    {
                        play.TeamID = 0;
                        // play.Position = player.Position;
                        try
                        {
                            Coaches.Update(play);
                        }
                        catch { }
                    }

                }
                else
                {
                    foreach (Coach play in Coaches.Where(x => x.CoachId.Equals(actualCoach.CoachId)).Select(x => x))
                    {
                        try
                        {
                            play.CoachName = coach.CoachName;
                            play.Salary = coach.Salary;
                            play.TeamID = coach.TeamID;
                            Coaches.Update(play);
                        }
                        catch { };
                        // play.Position = player.Position;
                    }
                }

            }
             );
        }
    }
}
