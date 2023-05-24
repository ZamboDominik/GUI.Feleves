using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Feleves
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      

        private void Lb_teams_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Lb_Players.Items.Refresh();
            btn_DeleteCoach.IsEnabled = true;
            //btn_DeletePlayer.IsEnabled = true;
            btn_DeleteTeam.IsEnabled = true;
            btn_UpdateCoach.IsEnabled = true;
            btn_UpdateTeam.IsEnabled = true;
          //  ((ListBox)Lb_teams).Items.Refresh();

        }

        private void Lb_Players_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_DeletePlayer.IsEnabled = true;  
            btn_UpdatePlayer.IsEnabled = true;
        }

        private void btn_CreatePlayer_Click(object sender, RoutedEventArgs e)
        {
            Window player = new PlayerCreator();
            player.Show();
        }

        private void btn_CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            Window team = new TeamCreate();
            team.Show();
        }

        private void Lb_teams_TargetUpdated(object sender, DataTransferEventArgs e)
        {
           // ((ListBox)Lb_teams).Items.Refresh();
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
           // ((ListBox)Lb_teams).Items.Refresh();
        }

        private void Lb_teams_SourceUpdated(object sender, DataTransferEventArgs e)
        {
          //  ((ListBox)Lb_teams).Items.Refresh();
        }
    }
}
