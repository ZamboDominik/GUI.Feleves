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
using System.Windows.Shapes;

namespace GUI.Feleves
{
    /// <summary>
    /// Interaction logic for UpdateTeamWindow.xaml
    /// </summary>
    public partial class UpdateTeamWindow : Window
    {
        public UpdateTeamWindow()
        {
            InitializeComponent();
        }

        private void tb_Crate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
