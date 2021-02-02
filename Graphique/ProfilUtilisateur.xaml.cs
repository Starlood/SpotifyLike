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
using System.Linq;

namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour ProfilUtilisateur.xaml
    /// </summary>
    public partial class ProfilUtilisateur : UserControl
    {
        private Discotheque Discotheque { get; set; }
        private Artistetheque Artistetheque { get; set; }

        
            public ProfilUtilisateur(Artistetheque a, Discotheque d)
            {
                InitializeComponent();
                Artistetheque = a;
                Discotheque = d;

                NomArtiste.Text = $"Nom : {d.EstArtiste.NomArtiste}";
                NbPlaylists.Text = $"Nombre de playlists : {Discotheque.DicoPlaylists["MesPlaylists"].Count().ToString()}"; //On affiche le nombre de playlists
                NbMus.Text = $"Nombre de musiques aimées : {Discotheque.DicoMusiques["MusiquesAimees"].Count().ToString()}";//On affiche le nombre de musiques aimées
                NbArt.Text = $"Nombre d'artistes aimés : {Discotheque.DicoArtistes["ArtistesAimes"].Count().ToString()}";//On affiche le nombre d'artistes aimés


        }


    }
}
