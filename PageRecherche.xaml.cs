using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Collections.ObjectModel;


namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour PageRecherche.xaml
    /// </summary>
    public partial class PageRecherche : UserControl
    {
        private Artistetheque Artistetheque { get; set; }

        private Discotheque Discotheque { get; set; }
        public PageRecherche(string recherche,Artistetheque a,Discotheque d)
        {
            //On créé des listes qui vont contenir les artistes/musiques/albums trouvés
            List<Artiste> RechArt = new List<Artiste>();
            List<Musique> RechMus = new List<Musique>();
            List<Album> RechAlb = new List<Album>();

            InitializeComponent();

            this.Artistetheque = a;
            this.Discotheque = d;

            Artistetheque.Rechercher(recherche, RechArt, RechAlb, RechMus); //On recherche

            musiques.ItemsSource = RechMus;     //On définit ce qu'on met dans les playlists
            albums.ItemsSource = RechAlb;
            artistes.ItemsSource = RechArt;

            BarreRecherche.Focus();

        }



        /// <summary>
        /// OUvre la page d'une musique quand on clique sur une musique dans la listbox associée
        /// </summary>
        private void SelChangeMusique(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UneMusique(Artistetheque, Discotheque, musiques.SelectedItem as Musique);
        }


        /// <summary>
        /// OUvre la page d'un album quand on clique sur un album dans la listbox associée
        /// </summary>
        private void SelChangeAlbum(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UnAlbum(Artistetheque, Discotheque, albums.SelectedItem as Album);
        }


        /// <summary>
        /// OUvre la page d'un artiste quand on clique sur un artiste dans la listbox associée
        /// </summary>
        private void SelChangeArtiste(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new PageArtiste(Artistetheque, Discotheque, artistes.SelectedItem as Artiste);
        }


        private void ClickRechercher(object sender, RoutedEventArgs e)
        {
            this.Content = new PageRecherche(BarreRecherche.Text, Artistetheque, Discotheque);
        }

        /// <summary>
        /// Quand le texte change on refait une recherche
        /// </summary>
        private void ChangementTexte(object sender, TextChangedEventArgs e)
        {           
            List<Artiste> RechArt = new List<Artiste>();
            List<Musique> RechMus = new List<Musique>();
            List<Album> RechAlb = new List<Album>();

            Artistetheque.Rechercher(BarreRecherche.Text, RechArt, RechAlb, RechMus);//Appel de la fonction recherche

            musiques.ItemsSource = RechMus;
            albums.ItemsSource = RechAlb;
            artistes.ItemsSource = RechArt;

            if (!RechArt.Any() && !RechAlb.Any() && !RechMus.Any()) // Si les 3 listes sont vides on affiche qu'il n'y a pas ed résultats
                
            {
                Test.Text = "Aucune correspondance avec les données";
                MusiqueT.Text = "";
                ArtisteT.Text = "";
                AlbumT.Text = "";
            }
            else
            {
                Test.Text = "";
                MusiqueT.Text = "Musiques trouvées :";
                ArtisteT.Text = "Artistes trouvés :";
                AlbumT.Text = "Albums trouvés :";
            }

        }
    }
}
