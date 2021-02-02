using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Modele;

namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour AjouterPlaylist.xaml
    /// </summary>
    public partial class AjouterPlaylist : UserControl
    {
        /// <summary>
        /// Image de la playlist à créer
        /// </summary>
        public string ImagePl { get; set; } //Declaration de la variable ImagePl de type string

        public Discotheque Discotheque { get; set; } //Declaration de la variable Discotheque de type Discotheque
        public Artistetheque Artistetheque { get; set; } //Declaration de la variable Artistetheque de type Artistetheque


        public AjouterPlaylist(Artistetheque a, Discotheque d)
        {
            InitializeComponent();
            Discotheque = d; //La variable Discotheque prend en valeur du paramètre d
            Artistetheque = a; //La variable Artistetheque prend en valeur du paramètre a
        }

        private void ClickOuvreImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();//On ouvre l'explorateur de fichier
            op.Title = "Choisir une image";//Titre de la fenêtre
            op.Filter = "Une Image|*.jpg;*.jpeg;*.png|" +// Les filtres pour qu'on ne puisse choisir que des images
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImagePl = op.FileName;// On définit le lien de l'image
            }
        }


        /// <summary>
        /// Quand on appui sur le bouton de confirmation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirmer(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ImagePl))
            {
                //On change le nom de l'image pour qu'elle soit NomArtiste_NomPlaylist
                string nomImage = $"{Discotheque.EstArtiste.NomArtiste}_{BoxNom.Text}";

                string[] l = ImagePl.Split('.'); //On récupère le format de l'image

                string brut = "..\\images\\playlist\\";

                string dest = $"{brut}{nomImage}.{l[l.Length - 1]}";

                try
                {
                    System.IO.File.Copy(ImagePl, dest); // On copie l'image donnée dans le fichier contenant les images des albums
                }
                catch (Exception) { } // Normalement l'erreur arrive que si l'image existe déjà dans le fichier



                Discotheque.DicoPlaylists["MesPlaylists"].Add(new Playlist(BoxNom.Text, $"playlist\\{nomImage}.{l[l.Length - 1]}")); //On créé la playlist

            }

            else
            {
                Discotheque.DicoPlaylists["MesPlaylists"].Add(new Playlist(BoxNom.Text)); //On créé la playlist avec l'image par défaut
            }


            

            this.Content = new PageAccueil(Artistetheque, Discotheque);//On revient à la page d'accueil
        }
    }
}
