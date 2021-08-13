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
using VansaetKendra_Gd1._1_DM_Project_DAL;
using VansaetKendra_Gd1._1_DM_Project_Models;

namespace VansaetKendra_GTIGPRd1._1_DM_Project_WPF
{
    /// <summary>
    /// Interaction logic for ReputatieWindow.xaml
    /// </summary>
    public partial class ReputatieWindow : Window
    {
        public ReputatieWindow()
        {
            InitializeComponent();
        }

        private void datagridGebruikers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(datagridReputatie.SelectedItem is Reputatie reputatie)
            {
                txtNaam.Text = reputatie.Naam;
                txtPunten.Text = reputatie.Punten.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwindow = new MainWindow();
            mwindow.Show();
            this.Close();
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Reputatie");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Reputatie reputatie = datagridReputatie.SelectedItem as Reputatie;

                #region verwijder + update velden
                int ok = DatabaseOperations.VerwijderenReputatie(reputatie);

                if(ok > 0)
                {
                    datagridReputatie.ItemsSource = DatabaseOperations.OphalenReputatie();
                    Wissen();
                }
                else
                {
                    MessageBox.Show("Reputatie is niet verwijderd!");
                }
                #endregion
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            // Aanmaken object
            Reputatie reputatie = new Reputatie();
            reputatie.Naam = txtNaam.Text;
            reputatie.Punten = int.Parse(txtPunten.Text);

            if (reputatie.IsGeldig())
            {
                #region toevoegen reputatie
                int ok = DatabaseOperations.ToevoegenReputatie(reputatie);

                if (ok > 0)
                {
                    datagridReputatie.ItemsSource = DatabaseOperations.OphalenReputatie();
                    Wissen();
                }
                else
                {
                    MessageBox.Show("Reputatie is niet toegevoegd!");
                }
                #endregion
            }
            else
            {
                MessageBox.Show(reputatie.Error);
            }
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Reputatie");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                #region aanpassen object Reputatie
                Reputatie reputatie = datagridReputatie.SelectedItem as Reputatie;
                reputatie.Naam = txtNaam.Text;
                reputatie.Punten = int.Parse(txtPunten.Text);

                if (reputatie.IsGeldig())
                {
                    #region aanpassen reputatie
                    int ok = DatabaseOperations.AanpassenReputatie(reputatie);

                    if(ok > 0)
                    {
                        datagridReputatie.ItemsSource = DatabaseOperations.OphalenReputatie();
                        Wissen();
                    }
                    else
                    {
                        MessageBox.Show("Reputatie is niet aangepast!");
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show(reputatie.Error);
                }
                #endregion
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            Wissen();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagridReputatie.ItemsSource = DatabaseOperations.OphalenReputatie();
        }

        private void Wissen()
        {
            txtNaam.Text = string.Empty;
            txtPunten.Text = "";
        }

        public string Valideer(string columnName)
        {
            if(columnName == "Reputatie" && datagridReputatie.SelectedItem == null)
            {
                return "Selecteer een reputatie!";
            }
            return "";
        }
    }
}
