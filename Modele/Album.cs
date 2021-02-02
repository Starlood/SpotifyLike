using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    [Serializable]
    public class Album : IEquatable<Album>
    {
        /// <summary>
        /// Nom de l'album
        /// </summary>
        public string NomAlbum { get; private set; }

        /// <summary>
        /// Image de couverture de l'album
        /// </summary>
        public string ImageAlbum { get; private set; }

        /// <summary>
        /// Liste des musiques appartenant à l'album
        /// </summary>
        public List<Musique> MusiquesAlbum { get; private set; } = new List<Musique>();

        /// <summary>
        /// Créateur de l'album
        /// </summary>
        public Artiste Createur { get; private set; }


        /// <summary>
        ///  Constructeur de la classe
        /// </summary>
        /// <param name="nom"> Nom de l'album</param>
        /// <param name="artiste">Createur de l'album</param>
        /// <param name="image"> Image de couverture de l'album</param>
        public Album(string nom,Artiste artiste , string image= "pochettes\\Default.png")
        {
            ImageAlbum = image;
            NomAlbum = nom;
            Createur = artiste;
        }



        /// <summary>
        /// Ajout d'une musique dans l'album
        /// </summary>
        /// <param name="musique">La musique à ajouter</param>
        public void AjouterMusique(Musique musique)
        {
            MusiquesAlbum.Add(musique);
        }




 
        /// <summary>
        /// Retourne un album en y indiquant le nombre de musiques ainsi que leur titres
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retour= $"Album: {NomAlbum}, Nombre de musique : {MusiquesAlbum.Count}\n    ";
            foreach(Musique m in MusiquesAlbum)
            {
                retour = retour +m + "\n    ";
            }
            return retour;
        }

        public bool Equals(Album other)
         {
             return NomAlbum.Equals(other.NomAlbum) && Createur.Equals(other.Createur) && ImageAlbum.Equals(other.ImageAlbum);
        } 
         
    }
}
