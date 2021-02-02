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
using Graphique.converters;

namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour UneMusique.xaml
    /// </summary>
    public partial class UneMusique : UserControl
    {
        private Artistetheque Artistetheque { get; set; }

        private Discotheque Discotheque { get; set; }

        private Musique MusiqueCourante { get; set; }


        public UneMusique(Artistetheque a, Discotheque d, Musique m)
        {
            InitializeComponent();

            Artistetheque = a;
            Discotheque = d;
            MusiqueCourante = m;

            Grille.DataContext = m;
            playlist.DataContext = Discotheque.DicoPlaylists["MesPlaylists"];
            Date.DataContext = m.DateCreation.ToShortDateString(); //Affichage de la date au format JJ/MM/AAAA

            Discotheque.AjouterObjetDernierementEcoute<Musique>(m, Discotheque.DicoMusiques["MusiquesDernierementsEcoutes"]); //On ajoute la musique à la liste des musiques dernièrements écoutées


            Video.NavigateToString(StringToUrl.ConvertToUrl(MusiqueCourante.LienYoutube));

            // On regarde si la musique fait partie de la liste des musiques aimées pour définir l'état du toggle button
            if (Discotheque.DicoMusiques["MusiquesAimees"].Contains(MusiqueCourante))
            {
                BoutonAime.IsChecked = true;
            }
        }

        /// <summary>
        /// Quand on clique sur un des artistes on ouvre sa page dédiée
        /// </summary>
        private void ClickArtiste(object sender, MouseButtonEventArgs e)
        {
            this.Content = new PageArtiste(Artistetheque, Discotheque, ListeCreateurs.SelectedItem as Artiste);
        }

        /// <summary>
        /// Quand on clique sur le bouton de "like" on appelle la fonction aimerObjet 
        /// </summary>
        private void ClickLike(object sender, RoutedEventArgs e)
        {
            Discotheque.AimerObj<Musique>(MusiqueCourante, Discotheque.DicoMusiques["MusiquesAimees"]);
        }

        /// <summary>
        /// Quand on veut ajouter/supprimer la musique à une playlist
        /// </summary>
        private void BoutonAjouter_Click(object sender, RoutedEventArgs e)
        {
            ChoisirPlaylist.IsOpen = true; //On ouvre la fenetre popup pour choisir la playlist
        }


        /// <summary>
        /// Pour fermer la popup si on ne veut pas ajouter/supprimer la musique à une playlist
        /// </summary>
        private void BoutonFermer(object sender, RoutedEventArgs e)
        {
            ChoisirPlaylist.IsOpen = false; //On ferme la popup
        }

        /// <summary>
        /// Quand on choisi la playlist dans laquelle on doit ajouter/supprimer la musique courante
        /// </summary>
        private void SelChangePlaylist(object sender, MouseButtonEventArgs e)
        {
            bool aws;
            ChoisirPlaylist.IsOpen = false;
            Playlist p = (Playlist)playlist.SelectedItem;

            if(p != null)
            {
                aws = p.AjouterMusique(MusiqueCourante); //On ajoute la musique à la playlist choisie
                if (aws) //Si elle a été ajouté
                {
                    TexteConfirmer.Text = $"La musique {MusiqueCourante.NomMusique} a bien été ajoutée à la playlist {p.NomPlaylist} ";
                }
                else // Si elle a été retiré de la playlist
                {
                    TexteConfirmer.Text = $"La musique {MusiqueCourante.NomMusique} a bien été retirée de la playlist {p.NomPlaylist} ";
                }
                Msg.IsOpen = true; //On ouvre le message de confirmation
            }


        }
    }
}
