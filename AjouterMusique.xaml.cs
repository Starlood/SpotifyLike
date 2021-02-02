using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
using Modele;


namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour Test.xaml
    /// </summary>
    public partial class AjouterMusique : UserControl
    {
        /// <summary>
        /// type de la musique à créer
        /// </summary>
        private TypeMusicaux Tm = new TypeMusicaux();


        private Discotheque Discotheque { get; set; }
        private Artistetheque Artistetheque { get; set; }

        /// <summary>
        /// Liste des Artistes participant à la musique
        /// </summary>
        private List<Artiste> Featuring { get; set; } = new List<Artiste>();

        public AjouterMusique(Artistetheque artistetheque, Discotheque discotheque)
        {
            InitializeComponent();
            Discotheque = discotheque;
            Artistetheque = artistetheque;

            ListAlbum.DataContext = discotheque.EstArtiste; // On change le datatContext pour afficher La liste des album de l'artiste
            ListArtistes.DataContext = artistetheque; // On définit le DataContexte pour la liste des artistes
        }

        /// <summary>
        /// Evenement quand on clique sur une des check box lié au style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckClickSty(object sender, RoutedEventArgs e)
        {
            CheckBox r = (CheckBox)sender; // On change le type pour qu'il corresponde à la checkbox
            Tm ^= (TypeMusicaux)r.Content; // Opérateur ou exclusif pour ajouter le le Type de la musique ou la retirer           
        }


        /// <summary>
        /// Evenement quand on clique sur sur un artiste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckClickArt(object sender, RoutedEventArgs e)
        {
            CheckBox r = sender as CheckBox;// On change le type pour qu'il corresponde à la checkbox


            foreach (Artiste a in Artistetheque.LesArtistes) //On parcours la liste des artistes
            {
                if (a.NomArtiste == r.Content as string) // Si l'artiste est égal au contenu de la checkbox
                {
                    Featuring.Add(a); //On ajoute l'artiste à la liste des featurings
                    break;
                }
            }
            
   
        }
        private void UnCheckClickArt(object sender, RoutedEventArgs e)
        {
            CheckBox r = sender as CheckBox;// On change le type pour qu'il corresponde à la checkbox


            foreach (Artiste a in Artistetheque.LesArtistes)//On parcours la liste des artistes
            {
                if (a.NomArtiste == r.Content as string)// Si l'artiste est égal au contenu de la checkbox
                {
                    Featuring.Remove(a);//On supprime l'artiste à la liste des featurings
                    break;
                }
            }
        }

        /// <summary>
        /// Evenement quand on clique sur le bouton Confirmer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickConfirmer(object sender, RoutedEventArgs e)
        {
            if (Tm == 0 || string.IsNullOrEmpty(BoxNom.Text) || string.IsNullOrEmpty(BoxLien.Text)) // Si on a pas définit de type ou renseigné le Nom /Lien de la musique
            {
                TextErreur.Text = "Un ou plusieurs éléments n'ont pas été remplis"; // On affiche une erreur
                
            }
            else
            {
                if (Featuring.Count == 0 || !Featuring.Contains(Discotheque.EstArtiste)) // Si l'artiste ne s'est pas ajouté à la liste des featuring 
                {
                    Featuring.Add(Discotheque.EstArtiste); // On ajoute l'artiste créateur dans la liste des featurings
                }

                if (ListAlbum.SelectedItem == null) // Si on à pas choisi d'album 
                {
                    DateTime date = ChoisirDate.SelectedDate ?? DateTime.Now;
                    Discotheque.EstArtiste.MusiquesArtiste.Add(new Musique(BoxNom.Text, BoxLien.Text, Featuring, Tm,date)); // On ajoute la musique dans la liste MusiqueArtiste de l'Artiste en question
                }
                else
                {
                    DateTime date = ChoisirDate.SelectedDate ?? DateTime.Now;
                    Album a = ListAlbum.SelectedItem as Album; // On récupère l'album choisi
                    int t = Discotheque.EstArtiste.ListeAlbums.IndexOf(a); //On récupère l'index de l'album

                    Artistetheque.LesArtistes[Artistetheque.LesArtistes.IndexOf(Discotheque.EstArtiste)].ListeAlbums[t].AjouterMusique(new Musique(BoxNom.Text, BoxLien.Text, Featuring, Tm, date, Discotheque.EstArtiste.ListeAlbums[t].ImageAlbum));
                }
                this.Content = new PageAccueil(Artistetheque, Discotheque); // On revient à la page d'accueil
            }

            
        }


    }
}
