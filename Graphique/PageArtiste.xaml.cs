using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour PageArtiste.xaml
    /// </summary>
    public partial class PageArtiste : UserControl
    {
        private Artistetheque Artistetheque;

        private Discotheque Discotheque;

        private Artiste ArtisteCourant;

        public PageArtiste(Artistetheque a, Discotheque d, Artiste art)
        {
            InitializeComponent();

            ArtisteCourant = art;
            Artistetheque = a;
            Discotheque = d;

            Discotheque.AjouterObjetDernierementEcoute<Artiste>(art, Discotheque.DicoArtistes["ArtistesDernierementsEcoutes"]); //On ajoute l'artiste dna la liste dernierement écouté


            //On créé une liste qui contient toutes les musiques de l'artistes (celles dans les albums et les autres)
            List<Musique> listeM = new List<Musique>();
            foreach(Album album in art.ListeAlbums)
            {
                foreach(Musique m in album.MusiquesAlbum)
                {
                    listeM.Add(m);
                }
            }
            foreach(Musique m in art.MusiquesArtiste)
            {
                listeM.Add(m);
            }

          
            //On trie la liste précédemment triée par date de création 
            IEnumerable < Musique > listeTriee = listeM.OrderByDescending(m => m.DateCreation); 

            //On définit les dataContext
            Grille.DataContext = art;

            DernieresMusiques.ItemsSource = listeTriee;

            // On regarde si l'artiste fait partie de la liste des artistes aimés pour définir l'état du toggle button
            if (Discotheque.DicoArtistes["ArtistesAimes"].Contains(ArtisteCourant))
            {
                BoutonAime.IsChecked = true;
            }


        }

        /// <summary>
        /// Si on clique sur un album on ouvre la page dédiée
        /// </summary>
        private void SelChangeAlbum(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UnAlbum(Artistetheque,Discotheque,DerniersAlbum.SelectedItem as Album);
        }

        /// <summary>
        /// Si on clique sur une musique on ouvre la page dédiée
        /// </summary>
        private void SelChangeMusique(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UneMusique(Artistetheque, Discotheque, DernieresMusiques.SelectedItem as Musique);
        }

        /// <summary>
        /// Quand on clique sur le bouton de "like" on appelle la fonction aimerObjet 
        /// </summary>
        private void ClickLike(object sender, RoutedEventArgs e)
        {
            Discotheque.AimerObj<Artiste>(ArtisteCourant, Discotheque.DicoArtistes["ArtistesAimes"]);
        }
    }
}
