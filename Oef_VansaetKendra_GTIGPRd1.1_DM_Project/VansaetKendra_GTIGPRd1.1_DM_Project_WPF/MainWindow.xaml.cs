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

namespace VansaetKendra_GTIGPRd1._1_DM_Project_WPF
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

        private void btnGebruikers_Click(object sender, RoutedEventArgs e)
        {
            GebruikerWindow gWindow = new GebruikerWindow();
            gWindow.Show();
            this.Close();
        }

        private void btnReputatie_Click(object sender, RoutedEventArgs e)
        {
            ReputatieWindow repWindow = new ReputatieWindow();
            repWindow.Show();
            this.Close();
        }

        private void btnAchievements_Click(object sender, RoutedEventArgs e)
        {
            AchievementWindow achievWindow = new AchievementWindow();
            achievWindow.Show();
            this.Close();
        }
    }
}
