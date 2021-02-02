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
    /// Logique d'interaction pour UnAlbum.xaml
    /// </summary>
    public partial class UnAlbum : UserControl
    {
        public Artistetheque Artistetheque { get; set; }

        public Discotheque Discotheque { get; set; }

        public UnAlbum(Artistetheque a, Discotheque d, Album album)
        {
            InitializeComponent();

            Grille.DataContext = album;
            Artistetheque = a;
            Discotheque = d;
        }

        /// <summary>
        /// Quand on clique sur une musique dans la listbox on ouvre la page dédiée à celle-ci 
        /// </summary>
        private void SelChange(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UneMusique(Artistetheque, Discotheque, Musiques.SelectedItem as Musique);
        }
    }
}
