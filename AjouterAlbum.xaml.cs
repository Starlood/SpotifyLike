using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour AjouterAlbum.xaml
    /// </summary>
    public partial class AjouterAlbum : UserControl
    {
        /// <summary>
        /// Lien de la pochette de l'album
        /// </summary>
        private string ImageAl { get; set; }//Declaration de la variable ImageAl de type String

        private Discotheque Discotehque { get; set; }//Declaration de la variable Discotehque de type Discotehque
        private Artistetheque Artistetheque { get; set; }//Declaration de la variable Artistetheque de type Artistetheque


        public AjouterAlbum(Artistetheque a, Discotheque d)
        {
            InitializeComponent();
            Discotehque = d; //La varible Discotehque prend la valeur du parmètre d 
            Artistetheque = a;//La varible Artistetheque prend la valeur du parmètre a
        }

        /// <summary>
        /// Evenement pour choisir une image dans ses dossiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOuvreImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog(); //On ouvre l'explorateur de fichier
            op.Title = "Choisir une image";  //Titre de la fenêtre
            op.Filter = "Une Image|*.jpg;*.jpeg;*.png|" +  // Les filtres pour qu'on ne puisse choisir que des images
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)//Si l'ouverure de la fenetre à bien fonctionné
            {
                ImageAl = op.FileName; // On définit le lien de l'image
            }
        }


        /// <summary>
        /// Quand on appui sur le bouton de confirmation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirmer(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(ImageAl)) // Si on a choisi une image
            {

                //On change le nom de l'image pour qu'elle soit NomArtiste_NomAlbum
                string nomImage =$"{Discotehque.EstArtiste.NomArtiste}_{BoxNom.Text}";

                string[] l = ImageAl.Split('.');//Récupération de l'extension

                string brut = "..\\images\\pochettes\\";//Chemin 

                string dest = $"{brut}{nomImage}.{l[l.Length-1]}";//Chemin en enlvant 


                try
                {
                    System.IO.File.Copy(ImageAl, dest); // On copie l'image donnée dans le fichier contenant les images des albums
                }
                catch (Exception) { } // Normalement l'erreur arrive que si l'image existe déjà dans le fichier
                
                Discotehque.EstArtiste.CreerAlbum(BoxNom.Text, $"pochettes\\{nomImage}.{l[l.Length - 1]}"); // On créé l'album
            }
            else
            {
                Discotehque.EstArtiste.CreerAlbum(BoxNom.Text); // Si on a pas d'image on créé l'album et il prendra l'image par défaut
            }
            this.Content = new PageAccueil(Artistetheque, Discotehque); // On revient à la page d'accueil
        }
    }
}
