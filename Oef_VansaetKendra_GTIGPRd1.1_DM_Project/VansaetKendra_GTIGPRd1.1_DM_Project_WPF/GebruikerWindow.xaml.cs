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
    /// Interaction logic for GebruikerWindow.xaml
    /// </summary>
    public partial class GebruikerWindow : Window
    {
        public GebruikerWindow()
        {
            InitializeComponent();
        }

        // Vult de datagrid op met gebruiker bij het laden van het formulier
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagridGebruikers.ItemsSource = DatabaseOperations.OphalenGebruikers();
        }

        // Als er een nieuwe record geselecteerd wordt updaten de tekstvakken met de bijhorende gegevens
        private void datagridGebruikers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(datagridGebruikers.SelectedItem is Gebruiker gebruiker)
            {
                txtAchternaam.Text = gebruiker.Achternaam;
                txtVoornaam.Text = gebruiker.Voornaam;
                txtEmail.Text = gebruiker.Email;
                txtGebruiksnaam.Text = gebruiker.Gebruiksnaam;
            }
        }

        // Verwijderd de geselecteerde gebruiker
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Gebruiker");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Gebruiker gebruiker = datagridGebruikers.SelectedItem as Gebruiker;

                #region verwijder + updaten velden
                int ok = DatabaseOperations.VerwijderenGebruiker(gebruiker);

                if(ok > 0){
                    datagridGebruikers.ItemsSource = DatabaseOperations.OphalenGebruikers();
                    Wissen();
                }
                else
                {
                    MessageBox.Show("Gebruiker is niet verwijderd!");
                }
                #endregion
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        // Toevoegen van een gebruiker
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            #region aanmaken gebruiker obj
            Gebruiker gebruiker = new Gebruiker();

            gebruiker.Achternaam = txtVoornaam.Text;
            gebruiker.Voornaam = txtVoornaam.Text;
            gebruiker.Email = txtEmail.Text;
            gebruiker.Gebruiksnaam = txtGebruiksnaam.Text;
            gebruiker.Toegetreden = DateTime.Now;
            #endregion

            if (gebruiker.IsGeldig())
            {
                #region toevoegen gebruiker
                int ok = DatabaseOperations.ToevoegenGebruiker(gebruiker);

                if (ok > 0)
                {
                    datagridGebruikers.ItemsSource = DatabaseOperations.OphalenGebruikers();
                    Wissen();
                }
                else
                {
                    MessageBox.Show("Gebruiker is niet toegevoegd!");
                }
            #endregion
            }
            else
            {
                MessageBox.Show(gebruiker.Error);
            }
        }

        // Aanpassen van de geselecteerde record
        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("gebruiker");

            if (string.IsNullOrWhiteSpace(foutmelding)) 
            {
                #region aanpassen gebruiker obj
                Gebruiker gebruiker = datagridGebruikers.SelectedItem as Gebruiker;

                gebruiker.Achternaam = txtVoornaam.Text;
                gebruiker.Voornaam = txtVoornaam.Text;
                gebruiker.Email = txtEmail.Text;
                gebruiker.Gebruiksnaam = txtGebruiksnaam.Text;
                #endregion

                if (gebruiker.IsGeldig())
                {
                    #region aanpassen gebruiker
                    int ok = DatabaseOperations.AanpassenGebruiker(gebruiker);
                    if(ok > 0)
                    {
                        datagridGebruikers.ItemsSource = DatabaseOperations.OphalenGebruikers();
                        Wissen();
                    }
                    else
                    {
                        MessageBox.Show("Gebruiker is niet aangepast!");
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show(gebruiker.Error);
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        // Maakt alle tekstvelden leeg
        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            Wissen();
        }

        // Button om terug te gaan naar het vorige scherm
        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwindow = new MainWindow();
            mwindow.Show();
            this.Close();
        }

        // Methode voor het leegmaken van tekstvelden
        private void Wissen()
        {
            txtVoornaam.Text = string.Empty;
            txtAchternaam.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtGebruiksnaam.Text = string.Empty;
        }

        // Methode voor validatie
        private string Valideer(string columnName)
        {
            if(columnName == "Gebruiker" && datagridGebruikers.SelectedItem == null)
            {
                return "Selecteer een gebruiker!" + Environment.NewLine;
            }
            return "";
        }
    }
}