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
    /// Logique d'interaction pour MesArtistes.xaml
    /// </summary>
    public partial class MesArtistes : UserControl
    {
        private Artistetheque Artistetheque { get; set; }

        private Discotheque Discotheque { get; set; }
        public MesArtistes(Artistetheque a, Discotheque d)
        {
            InitializeComponent();
            Artistetheque = a;
            Discotheque = d;


            artistes.DataContext = Discotheque.DicoArtistes["ArtistesAimes"]; // On définit le DataContext

        }


        private void SelecChange(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new PageArtiste(Artistetheque,Discotheque,artistes.SelectedItem as Artiste); // Si on clique sur un artiste dans la liste on ouvre sa page dédié
        }
    }
}
