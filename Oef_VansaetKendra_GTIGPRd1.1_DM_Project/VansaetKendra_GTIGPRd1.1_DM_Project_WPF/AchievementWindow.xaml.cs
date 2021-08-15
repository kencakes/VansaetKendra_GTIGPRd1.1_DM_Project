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
    /// Interaction logic for AchievementWindow.xaml
    /// </summary>
    public partial class AchievementWindow : Window
    {
        public AchievementWindow()
        {
            InitializeComponent();
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Achievement");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Achievement achievement = datagridAchievements.SelectedItem as Achievement;

                #region verwijder + update velden
                int ok = DatabaseOperations.VerwijderenAchievement(achievement);

                if(ok > 0)
                {
                    datagridAchievements.ItemsSource = DatabaseOperations.OphalenAchievements();
                    Wissen();
                }
                else
                {
                    MessageBox.Show("Achievement is niet verwijderd!");
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
            string foutmelding = Valideer("cmbCategorie");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                #region Aanmaken Achievement-object
                // AchievementID (PK, int not null) -- auto
                // Naam (varchar(50), not null)
                // Omschrijving (varchar(200), not null)
                // CategorieId(FK, int, not null)

                Categorie categorie = cmbCategorie.SelectedItem as Categorie;
                Achievement achievement = new Achievement();

                achievement.Naam = txtNaam.Text;
                achievement.Omschrijving = txtBeschrijving.Text;
                achievement.CategorieId = categorie.CategorieId;

                #endregion

                if (achievement.IsGeldig())
                {
                    #region toevoegen achievement
                    int ok = DatabaseOperations.ToevoegenAchievement(achievement);

                    if (ok > 0)
                    {
                        datagridAchievements.ItemsSource = DatabaseOperations.OphalenAchievements();
                    }
                    else
                    {
                        MessageBox.Show("Orderlijn is niet toegevoegd!");
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show(achievement.Error);
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Achievement");
            foutmeldingen += Valideer("cmbCategorie");

            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                #region aanpassen Achievement-object
                Achievement achievement = datagridAchievements.SelectedItem as Achievement;
                Categorie categorie = cmbCategorie.SelectedItem as Categorie;

                achievement.Naam = txtNaam.Text;
                achievement.Omschrijving = txtBeschrijving.Text;
                achievement.CategorieId = categorie.CategorieId;
                achievement.Categorie = categorie;
                
                if (achievement.IsGeldig())
                {
                    #region aanpassen achievement
                    int ok = DatabaseOperations.AanpassenAchievement(achievement);
                    if (ok > 0)
                    {
                        datagridAchievements.ItemsSource = DatabaseOperations.OphalenAchievements();
                        Wissen();
                    }
                    else
                    {
                        MessageBox.Show("Achievement is niet aangepast!");
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show(achievement.Error);
                }
                #endregion
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            Wissen();
        }

        private void datagridAchievements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Indien een nieuwe record geselecteerd wordt, update de tekstvelden
            if(datagridAchievements.SelectedItem is Achievement achievement)
            {
                txtBeschrijving.Text = achievement.Omschrijving;
                txtNaam.Text = achievement.Naam;
                cmbCategorie.SelectedItem = achievement.Categorie;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Opvullen van datagrid met achievements
            datagridAchievements.ItemsSource = DatabaseOperations.OphalenAchievements();

            // Opvullen combobox met categoriën
            cmbCategorie.ItemsSource = DatabaseOperations.OphalenCategorie();
            cmbCategorie.DisplayMemberPath = "Naam";
        }

        private void Wissen()
        {
            // Leegmaken van ingevulde tekstvelden
            txtBeschrijving.Text = string.Empty;
            txtNaam.Text = string.Empty;
            cmbCategorie.SelectedIndex = -1;
        }

        private string Valideer(string columnName)
        {
            if (columnName == "Achievement" && datagridAchievements.SelectedItem == null)
            {
                return "Selecteer een achievement!" + Environment.NewLine;
            }
            if (columnName == "cmbCategorie" && cmbCategorie.SelectedItem == null)
            {
                return "Selecteer een categorie!" + Environment.NewLine;
            }
            return "";
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            // Teruggaan naar vorige window
            MainWindow mWindow = new MainWindow();
            mWindow.Show();
            this.Close();
        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {
            datagridAchievements.ItemsSource = DatabaseOperations.OphalenAchievementsViaNaam(txtZoeken.Text);
        }
    }
}
