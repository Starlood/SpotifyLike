using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modele
{
    [Serializable]
    public class Playlist : IEquatable<Playlist>
    {
        /// <summary>
        /// Nom de la playlist
        /// </summary>
        public string NomPlaylist { get; set; }

        /// <summary>
        /// Image de la playlist
        /// </summary>
        public string ImagePlaylist { get; set; }

        /// <summary>
        /// Liste des musiques de la playlist
        /// </summary>
        public List<Musique> PlaylistMusique { get; set; }


        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="nom">Nom de la playlist</param>
        /// <param name="image">Image de la playlist, si pas renseigné alors l'image par défaut est associée</param>
        public Playlist(string nom ,string image= "playlist\\Default.png")
        {
            ImagePlaylist = image;
            NomPlaylist = nom;
            PlaylistMusique = new List<Musique>();
        }



        /// <summary>
        /// Ajouter une musique dans la playlist
        /// </summary>
        /// <param name="musique">musique à ajouter</param>
        public bool AjouterMusique(Musique musique)
        {
            foreach(Musique mu in PlaylistMusique)
            {
                if (mu == musique)
                {
                    PlaylistMusique.Remove(musique);
                    return false;
                }
            }

            PlaylistMusique.Add(musique);
            return true;

        }

        /// <summary>
        /// Supprimer une musique de la playlist
        /// </summary>
        /// <param name="musique">Musique à supprimer</param>
        public void SupprimerMusique(Musique musique)
        {
            PlaylistMusique.Remove(musique);
        }


        /// <summary>
        /// Retourne une playlist en indiquant le nombre de musiques ainsi que les musiques la composant
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string musiques = $"Playlist : {NomPlaylist} avec {PlaylistMusique.Count} musique(s) : \n";
            foreach(Musique mu in PlaylistMusique)
            {
                musiques = musiques + mu.ToString()+"\n";
            }
            return musiques;
        }
        public bool Equals(Playlist other)
        {
            return NomPlaylist.Equals(other.NomPlaylist) && ImagePlaylist.Equals(other.ImagePlaylist);
        }
    }
}
