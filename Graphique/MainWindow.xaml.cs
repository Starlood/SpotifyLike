using Graphique.converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
using Modele;

namespace Graphique
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



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //On regarde ce que à rentré l'utilisateur
            string login = id.Text;             //identifiant
            string motDePasse = mdp.Password;   //mot de passe

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse)) // Si l'un des 2 est null ya erreur
            {
                Erreur.Text = "L'identifiant ou le mot de passe ne correspond pas";
            }
            else
            {

                


                string sauvegarde = LoginToDonnees.Decrypt(login, motDePasse); // On décrypt le mot de passe et on retourne son lien de sauvegarde si les identifiants sont bons


                if (!string.IsNullOrEmpty(sauvegarde))// Si les identifiants on été bons 
                {
                    Erreur.Text=sauvegarde;
                    Window ecranAcceuil = new FenetrePrincipale(sauvegarde); // On ouvre la fenêtre principale 
                    this.Close();
                    ecranAcceuil.Show();
                }
                else
                {
                    Erreur.Text = "L'identifiant ou le mot de passe ne correspond pas"; // Ya une erreur dans les identifiants
                }

            }






        }

    }
}
