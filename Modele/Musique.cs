
using System;
using System.Collections.Generic;
using System.Text;


namespace Modele
{

    [Serializable]
    public class Musique : IEquatable<Musique>
    {



        /// <summary>
        /// Nom de la musique
        /// </summary>
        public string NomMusique { get; private set; }

        /// <summary>
        /// Image de la musique
        /// </summary>
        public string ImageMusique { get; private set; }

        /// <summary>
        /// Url youtube de la musique
        /// </summary>
        public string LienYoutube { get; private set; }

        /// <summary>
        /// Liste des créateurs de la musique
        /// </summary>
        public List<Artiste> Createurs { get; private set; } = new List<Artiste>();

        /// <summary>
        /// Date de création de la musique
        /// </summary>
        public DateTime DateCreation { get; private set; }

        /// <summary>
        /// Type de la musique
        /// </summary>
        public TypeMusicaux TypeMusique { get; private set; } 

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="nom">NOm de la musique</param>
        /// <param name="lien">url youtube de la musique</param>
        /// <param name="artiste">liste des Createurs de la musique</param>
        public Musique(string nom, string lien, List<Artiste> artiste, TypeMusicaux type, string image = "pochettes\\Default.png")
        {
            DateCreation = DateTime.Now; // Si il n'y a pas de date on considère qu'elle vient d'être créée
            TypeMusique = type;
            ImageMusique = image;
            NomMusique = nom;
            LienYoutube = lien;
            Createurs = artiste;
        }
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="nom">NOm de la musique</param>
        /// <param name="lien">url youtube de la musique</param>
        /// <param name="artiste">liste des Createurs de la musique</param>
        /// <param name="dateTime"> Date de la création de la musique</param>
        public Musique(string nom, string lien, List<Artiste> artiste, TypeMusicaux type, DateTime dateTime, string image = "pochettes\\Default.png") : this(nom,lien,artiste,type,image)
        {
            DateCreation = dateTime;
            TypeMusique = type;
            ImageMusique = image;
            NomMusique = nom;
            LienYoutube = lien;
            Createurs = artiste;
        }



   


        /// <summary>
        /// Affiche le nom de la musique, son type ainsi que l'artiste 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retour = $"Nom: {NomMusique} ,Type: {TypeMusique}   ,Date de création: {DateCreation.ToShortDateString()}       ,Artistes: ";
            foreach(Artiste a in Createurs)
            {
                retour = retour + $"{a.NomArtiste}, ";
            }

            return retour;
        }
        public bool Equals(Musique other)
        {
            return NomMusique.Equals(other.NomMusique) && ImageMusique.Equals(other.ImageMusique) && LienYoutube.Equals(other.LienYoutube) && TypeMusique.Equals(other.TypeMusique);
        }
        

    }
}
