using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    [Serializable]
    public class Artistetheque // Oui je sais le nom est pas ouf mais bon j'ai trouvé que ça
    {
        /// <summary>
        /// Liste contenant tous les artistes éxistants
        /// </summary>
        public List<Artiste> LesArtistes { get; private set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="listeArtiste"> Liste contenant tous les artistes</param>
        public Artistetheque(List<Artiste> listeArtiste)
        {
            LesArtistes = listeArtiste;
        }


        public void Rechercher(string recherches,List<Artiste> ArtisteRecherche, List<Album> AlbumRecherche, List<Musique> MusiquesRecherche)
        {
            if (string.IsNullOrEmpty(recherches)) return;
            ///Parcours de l'artistetheque 
            foreach (Artiste ar in LesArtistes)
            {
                // Si le nom de l'artiste correspond à la recherche on l'ajoute à la liste ArtisteRecherche
                if (ar.NomArtiste.ToLower().StartsWith(recherches.ToLower()))
                {
                    ArtisteRecherche.Add(ar); //

                }
                ///Parcours des Albums d'un artiste
                foreach (Album al in ar.ListeAlbums)
                {
                    // Si le nom de l'album correspond à la recherche on l'ajoute à la liste AlbumRecherche
                    if (al.NomAlbum.ToLower().StartsWith(recherches.ToLower()))
                    {
                        AlbumRecherche.Add(al);
                    }
                    /// Parcours des Musiques d'un album 
                    foreach (Musique mu in al.MusiquesAlbum)
                    {
                        // Si le nom de la musique correspond à la recherche on l'ajoute à la liste MusiqueRecherche
                        if (mu.NomMusique.ToLower().StartsWith(recherches.ToLower()))
                        {
                            MusiquesRecherche.Add(mu);
                        }
                    }
                }
                /// Parcours des Musiques dans la liste des musiques n'étant pas associées à un album
                foreach (Musique mu in ar.MusiquesArtiste)
                {
                    // Si le nom de la musique correspond à la recherche on l'ajoute à la liste MusiqueRecherche
                    if (mu.NomMusique.ToLower().StartsWith(recherches.ToLower()))
                    {
                        MusiquesRecherche.Add(mu);
                    }
                }
            }
        }

        /// <summary>
        /// Ajouter un Artiste dans la liste LesArtistes
        /// </summary>
        /// <param name="a"></param>
        public void AjouterArtiste(Artiste a)
        {
            //Parcours de la liste
            foreach (Artiste art in LesArtistes)
            {
                if (art == a)
                {
                    LesArtistes.Remove(a);
                    return; // Si l'artiste existe déjà on ne l'ajoute pas
                }
            }

            LesArtistes.Add(a);// On ajoute l'artiste si il n'existe pas dans la liste
        }


    }
}
