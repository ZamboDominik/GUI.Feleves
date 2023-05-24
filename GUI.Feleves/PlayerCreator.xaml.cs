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
using OSAHN6_HFT_202231.Models;

namespace GUI.Feleves
{
    /// <summary>
    /// Interaction logic for PlayerCreator.xaml
    /// </summary>
    public partial class PlayerCreator : Window
    {
        
        public PlayerCreator()
        {
            InitializeComponent();
        }

        private void tb_Crate_Click(object sender, RoutedEventArgs e)
        {
                   
        }

        private void tb_Crate_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
