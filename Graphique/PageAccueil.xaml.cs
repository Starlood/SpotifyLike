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
using Modele;
namespace Graphique
{
 
    public partial class PageAccueil : UserControl
    {
        private Artistetheque Artistetheque { get; set; }

        private Discotheque Discotheque { get; set; }


        public PageAccueil(Artistetheque a, Discotheque d)
        {



            InitializeComponent();
            Artistetheque = a;
            Discotheque = d;


            //ON définit les dataContext
            musiques.DataContext = Discotheque.DicoMusiques["MusiquesDernierementsEcoutes"];
            playlists.DataContext = Discotheque.DicoPlaylists["PlaylistsDernierementsEcoutes"];
            artistes.DataContext = Discotheque.DicoArtistes["ArtistesDernierementsEcoutes"];

            if(Discotheque.EstArtiste == null)
            {
                BoutonAjouterMusique.IsEnabled = false;
                BoutonAjouterAlbum.IsEnabled = false;
            }



        }

        /// <summary>
        /// OUvre la page d'une musique quand on clique sur une musique dans la listbox associée
        /// </summary>
        private void SelChangeMusique(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UneMusique(Artistetheque, Discotheque, musiques.SelectedItem as Musique);
        }

        /// <summary>
        /// OUvre la page d'une playlist quand on clique sur une playlist dans la listbox associée
        /// </summary>
        private void SelChangePlaylist(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UnePlaylist(Artistetheque, Discotheque, playlists.SelectedItem as Playlist);            
        }

        /// <summary>
        /// OUvre la page d'un artiste quand on clique sur un artiste dans la listbox associée
        /// </summary>
        private void SelChangeArtiste(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new PageArtiste(Artistetheque, Discotheque, artistes.SelectedItem as Artiste);
        }


        /// <summary>
        /// Ouvre la page pour créer une musique
        /// </summary>
        private void ClickButAjouterMusique(object sender, RoutedEventArgs e)
        {
            this.Content = new AjouterMusique(Artistetheque, Discotheque);
        }

        /// <summary>
        /// Ouvre la page pour créer un album
        /// </summary>
        private void ClickButAjouterAlbum(object sender, RoutedEventArgs e)
        {
            this.Content = new AjouterAlbum(Artistetheque, Discotheque);
        }

        /// <summary>
        /// Ouvre la page pour créer une playlist
        /// </summary>
        private void ClickButAjouterPlaylist(object sender, RoutedEventArgs e)
        {
            this.Content = new AjouterPlaylist(Artistetheque, Discotheque);
        }

        /// <summary>
        /// Ouvre la page dédié à la recherche
        /// </summary>
        private void ClickRechercher(object sender, RoutedEventArgs e)
        {
            this.Content = new PageRecherche(BarreRecherche.Text,Artistetheque, Discotheque);
        }



        /// <summary>
        /// Ouvre la page dédié à la recherche
        /// </summary>
        private void ClickBarreRechercher(object sender, MouseButtonEventArgs e)
        {
            this.Content = new PageRecherche(BarreRecherche.Text, Artistetheque, Discotheque);
        }
    }
}
