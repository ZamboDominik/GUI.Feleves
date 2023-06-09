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
using System.Windows.Shapes;

namespace GUIWPF
{
    /// <summary>
    /// Interaction logic for PlayersCoached.xaml
    /// </summary>
    public partial class PlayersCoached : Window
    {
        public PlayersCoached(ICollection<Player> players)
        {
            InitializeComponent();
            foreach(Player p in players)
            Players.Items.Add(p);
        }
    }
}
