using Modele;
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
using System.Windows.Shapes;

namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class FenetrePrincipale : Window
    {
        private Artistetheque Artistetheque=null;//Déclaration de la variable Artistetheque de type Artistetheque

        private Discotheque Discotheque=null;//Déclaration de la variable Discotheque de type Discotheque


        public FenetrePrincipale(string sauvegarde)
        {
            InitializeComponent();

            Artistetheque = Serialisation.DeserialisationBin("..\\save\\artistetheque.bin") as Artistetheque; //Artistehèque Deserialise et serialise Artistethèque
            Discotheque = Serialisation.DeserialisationBin(sauvegarde) as Discotheque;//Discotheque Deserialise et serialise Discotheque

            // PArtie qui permet de rétablir les références des objets lors de la désérialisation
            Discotheque.EstArtiste = Artistetheque.LesArtistes[Artistetheque.LesArtistes.IndexOf(Discotheque.EstArtiste)];


            List<Artiste> temp = new List<Artiste>();
            foreach (Artiste a in Discotheque.DicoArtistes["ArtistesDernierementsEcoutes"])//Pour chaque Artiste présent dans le dictionnaire DicoArtiste avec la clé ArtistesDernierementsEcoutes
            {
                foreach (Artiste b in Artistetheque.LesArtistes)//Pour chaque Artiste dans la liste Artistethèque
                {
                    if (a.Equals(b)) temp.Add(b);//Si il sont égaux, on ajoute
                }
            }
            Discotheque.DicoArtistes["ArtistesDernierementsEcoutes"] = temp;
            temp = new List<Artiste>();
            foreach (Artiste a in Discotheque.DicoArtistes["ArtistesAimes"])
            {
                foreach (Artiste b in Artistetheque.LesArtistes)
                {
                    if (a.Equals(b)) temp.Add(b);
                }
            }
            Discotheque.DicoArtistes["ArtistesAimes"] = temp;

            List<Musique> temp2 = new List<Musique>();
            foreach (Musique a in Discotheque.DicoMusiques["MusiquesAimees"])
            {
                foreach (Artiste b in Artistetheque.LesArtistes)
                {
                    foreach (Album al in b.ListeAlbums)
                    {
                        foreach (Musique mu in al.MusiquesAlbum) if (a.Equals(b)) temp2.Add(mu);
                    }
                    foreach (Musique mu in b.MusiquesArtiste) if (a.Equals(b)) temp2.Add(mu);
                }
            }
            Discotheque.DicoMusiques["MusiquesAimees"] = temp2;

            temp2 = new List<Musique>();
            foreach (Musique a in Discotheque.DicoMusiques["MusiquesDernierementsEcoutes"])
            {
                foreach (Artiste b in Artistetheque.LesArtistes)
                {
                    foreach (Album al in b.ListeAlbums)
                    {
                        foreach (Musique mu in al.MusiquesAlbum) if (a.Equals(mu)) temp2.Add(mu);
                    }
                    foreach (Musique mu in b.MusiquesArtiste) if (a.Equals(mu)) temp2.Add(mu);
                }
            }
            Discotheque.DicoMusiques["MusiquesDernierementsEcoutes"] = temp2;

            List<Musique> temp3 = new List<Musique>();
            foreach (Playlist a in Discotheque.DicoPlaylists["MesPlaylists"])
            {
                foreach (Musique b in a.PlaylistMusique)
                {
                    foreach (Artiste ar in Artistetheque.LesArtistes)
                    {
                        foreach (Album al in ar.ListeAlbums)
                        {
                            foreach (Musique mu in al.MusiquesAlbum) if (a.Equals(mu)) temp3.Add(mu);
                        }
                        foreach (Musique mu in ar.MusiquesArtiste) if (a.Equals(mu)) temp3.Add(mu);
                    }
                }
                a.PlaylistMusique = temp3;
                temp3 = new List<Musique>();
            }

            temp3 = new List<Musique>();
            foreach (Playlist a in Discotheque.DicoPlaylists["PlaylistsDernierementsEcoutes"])
            {
                foreach (Playlist b in Discotheque.DicoPlaylists["PlaylistsDernierementsEcoutes"])
                {
                    if (a.Equals(b)) a.PlaylistMusique = b.PlaylistMusique;
                }

            }

            contentControl.Content = new PageAccueil(Artistetheque, Discotheque);

            grille.DataContext = Discotheque.EstArtiste;
        }

        private void AccueilButton_Click(object sender, RoutedEventArgs e)
        {
            PageAccueil a = new PageAccueil(Artistetheque, Discotheque);
            contentControl.Content = a;


        }

        private void PlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new MesPlaylists(Artistetheque, Discotheque);//Lancement de la fenetre MesPlaylists
        }

        private void ArtisteButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new MesArtistes(Artistetheque, Discotheque);//Lancement de la fenetre MesArtistes
        }

        private void MusiqueButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new MesMusiques(Artistetheque, Discotheque);//Lancement de la fenetre MesMusiques
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Serialisation.SerialisationBin(Artistetheque,"..\\save\\artistetheque.bin"); //Quand la fenetre se ferme on enrgistre Artistetheque et Discotheque
            Serialisation.SerialisationBin(Discotheque,Discotheque.Save);

        }

        private void AccederProfil(object sender, MouseButtonEventArgs e)
        {
            contentControl.Content = new ProfilUtilisateur(Artistetheque, Discotheque);//Lancement de la fenetre ProfilUtilisateur
        }
    }
}
