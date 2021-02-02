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
    public partial class UnePlaylist: UserControl
    {
        private Artistetheque Artistetheque;

        private Discotheque Discotheque;
        public UnePlaylist(Artistetheque a, Discotheque d,Playlist p)
        {
            InitializeComponent();

            Artistetheque = a;
            Discotheque = d;

            //On ajoute la playlist dans la liste des playlists dernièrements écoutées
            Discotheque.AjouterObjetDernierementEcoute<Playlist>(p, Discotheque.DicoPlaylists["PlaylistsDernierementsEcoutes"]);

            Grille.DataContext = p;
        }

        /// <summary>
        /// Quand on clique sur une musique on ouvre sa page dédiée
        /// </summary>
        private void SelChange(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UneMusique(Artistetheque, Discotheque, playlists.SelectedItem as Musique);
        }
    
    }
}
