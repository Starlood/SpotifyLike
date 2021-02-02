using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    [Serializable]
    public class Artiste : IEquatable<Artiste>
    {
        /// <summary>
        /// nom de l'artiste
        /// </summary>
        public string NomArtiste { get; private set; }

        /// <summary>
        /// Image de profil de l'artiste
        /// </summary>
        public string ImageArtiste { get; private set; }

        /// <summary>
        /// Description de l'artiste
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Liste des albums de l'artiste
        /// </summary>
        public List<Album> ListeAlbums { get; private set; }= new List<Album>();

        /// <summary>
        /// Liste des musique de l'artiste n'appartenant pas à un album
        /// </summary>
        public List<Musique> MusiquesArtiste { get; private set; } = new List<Musique>();

        /// <summary>
        /// Constructeur de l'artiste
        /// </summary>
        /// <param name="nom">Nom de l'artiste</param>
        /// <param name="desc">description de l'artiste</param>
        public Artiste(string nom,string desc,string image= "profil\\Default.png")
        {
            NomArtiste = nom;
            Description = desc;
            ImageArtiste = image;
            
        }



        /// <summary>
        /// Supprimer un album de ListeAlbum
        /// </summary>
        /// <param name="al">Album à supprimer</param>
        public void SupprimerAlbum(Album al)
        {
            foreach(Album a in ListeAlbums)
            {
                if (a == al)
                {
                    ListeAlbums.Remove(al);
                    return;
                }
            }
            
        }

        /// <summary>
        /// Créé un album et l'ajoute dans la ListeAlbum
        /// </summary>
        /// <param name="nom">nom de l'album</param>
         public void CreerAlbum(string nom)
        {
            ListeAlbums.Add(new Album(nom, this));
        }

        /// <summary>
        /// Créé un album et l'ajoute dans la ListeAlbum
        /// </summary>
        /// <param name="nom">nom de l'album</param>
        /// <param name="image">image de couverture de l'album</param>
        public void CreerAlbum(string nom, string image)
        {
            ListeAlbums.Add(new Album(nom, this,image));
        }

        /// <summary>
        /// Permet de retourner un artiste en y indiquant le nombre d'albums 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string albums = $"Artiste : {NomArtiste} avec {ListeAlbums.Count} album(s) : \n";
            
            foreach (Album al in ListeAlbums)
            {
                albums = albums + $"{al} \n";
            }
            return albums;
        }
        public bool Equals(Artiste other)
        {
            return NomArtiste.Equals(other.NomArtiste) && ImageArtiste.Equals(other.ImageArtiste) && Description.Equals(other.Description);
        }

    }
}
