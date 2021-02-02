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
    /// <summary>
    /// Logique d'interaction pour MesPlaylists.xaml
    /// </summary>
    public partial class MesPlaylists : UserControl
    {
        public Artistetheque Artistetheque { get; set; }

        public Discotheque Discotheque { get; set; }

        public MesPlaylists(Artistetheque a, Discotheque d)
        {
            InitializeComponent();
            Artistetheque = a;
            Discotheque = d;

            playlists.DataContext = Discotheque.DicoPlaylists["MesPlaylists"];
        }

 



        private void BoutonFermer(object sender, RoutedEventArgs e)
        {
            ChoisirPlaylist.IsOpen = false;
        }

        /// <summary>
        /// Quand on clique sur une playlist dans la popup de suppression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelChangePlaylist(object sender, MouseButtonEventArgs e)
        {
            Playlist p = (Playlist)playlistChoisie.SelectedItem;
  
            TexteConfirmer.Text = $"La playlist {p.NomPlaylist} va être définitivement supprimée, voulez vous continuer ?";
            Msg.IsOpen = true;
            ChoisirPlaylist.IsOpen = false ;
        }


        /// <summary>
        /// Methode qui  affiche la popup avec la liste des playlists quand on veut en supprimer une
        /// </summary>
        private void BoutonAjouter_Click(object sender, RoutedEventArgs e)
        {
            ChoisirPlaylist.IsOpen = true;
            playlistChoisie.DataContext = Discotheque.DicoPlaylists["MesPlaylists"];
        }

        /// <summary>
        /// Confirmer la suppression d'une playlist 
        /// </summary>
        private void ConfirmerSuppression(object sender, RoutedEventArgs e)
        {
            Playlist p = (Playlist)playlistChoisie.SelectedItem;
            Discotheque.DicoPlaylists["MesPlaylists"].Remove(p); //On supprime la playlist
            this.Content = new MesPlaylists(Artistetheque, Discotheque);
            if (Discotheque.DicoPlaylists["PlaylistsDernierementsEcoutes"].Contains(p)) // Si la playlist est dans les playlists dernierements écoutés
            {
                Discotheque.DicoPlaylists["PlaylistsDernierementsEcoutes"].Remove(p); //On supprime la playlist dans  les plyalist dernièrement écouté
            }
        }

        /// <summary>
        /// Méthode qui permet de rennommer une playlsit
        /// </summary>
        private void RenomerPlaylist(object sender, MouseButtonEventArgs e)
        {
            Playlist p = (Playlist)playlists.SelectedItem;
            if(p != null) //Pour qu'il n'y ai pas d'erreur 
            {
                RenommerPlaylist.Text = $"Renommer la playlist {p.NomPlaylist}";
                Renommer.IsOpen = true; // On ouvre le dialogHost de material design
                TexteRenomer.Text = p.NomPlaylist;
            }


        }

        /// <summary>
        /// Permet de confirmer le rennommage d'une playlist
        /// </summary>
        private void ConfirmerRennomer(object sender, RoutedEventArgs e)
        {
            
            Playlist p = (Playlist)playlists.SelectedItem;
            //Verification qu'une playlist n'ai pas le même nom
            foreach (Playlist pl in Discotheque.DicoPlaylists["MesPlaylists"])
            {
                if (p != pl)
                {
                    if (pl.NomPlaylist.ToLower() == TexteRenomer.Text.ToLower())
                    {
                        MessageBox.Show("Une playlist avec ce nom existe déja");
                        return;
                    }
                }

            }
            p.NomPlaylist = TexteRenomer.Text; 
            this.Content = new MesPlaylists(Artistetheque, Discotheque); // On change le nom de la playlist



        }

        /// <summary>
        ///  Afficher la page d'une playlist quand on clique sur une dans la listbox proncipale de la page
        /// </summary>
        private void SelecChange(object sender, MouseButtonEventArgs e)
        {
            if (playlists.SelectedItem as Playlist != null) 
            { 
                this.Content = new UnePlaylist(Artistetheque, Discotheque, playlists.SelectedItem as Playlist); // Si on clique sur une playlist dans la listbox on ouvre sa page dédié
            }
        }
    }
}
