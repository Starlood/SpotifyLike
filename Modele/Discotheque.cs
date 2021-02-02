using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Security;
using System.Text;

namespace Modele
{
    [Serializable]
    public class Discotheque
    {

        // Dictionnaire contenant des collections d'artistes
        public Dictionary<string,List<Artiste>> DicoArtistes { get; set; } = new Dictionary<string, List<Artiste>>()
        {
            {"ArtistesAimes", new List<Artiste>() },  // Liste d'artistes aimés
            {"ArtistesDernierementsEcoutes", new List<Artiste>() } // Liste des artistes dernierements écoutés
        };

        // Dictionnaire contenant des collections de musiques
        public Dictionary<string, List<Musique>> DicoMusiques { get; set; } = new Dictionary<string, List<Musique>>()
        {
            {"MusiquesAimees", new List<Musique>() },  // Liste des musiques aimées
            {"MusiquesDernierementsEcoutes", new List<Musique>() } // Liste des artistes dernierements écoutées
        };

        // Dictionnaire contenant des collections de playlists
        public Dictionary<string, List<Playlist>> DicoPlaylists { get; set; } = new Dictionary<string, List<Playlist>>()
        {
            {"MesPlaylists", new List<Playlist>() },  // Liste des playlists
            {"PlaylistsDernierementsEcoutes", new List<Playlist>() } // Liste des artistes dernierements écoutés
        };

        /// <summary>
        /// Artiste associé à la discothèque
        /// </summary>
        public Artiste EstArtiste { get; set; }

        public string Save { get; set; }


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="estArtiste"> Artiste associé à la discothèque</param>
        public Discotheque(Artiste estArtiste)
        {
            EstArtiste = estArtiste;
        }
        public Discotheque()
        {

        }



        public void AimerObj<T>(T objet, List<T> list)
        {
            //PArcours de la liste Aimer du type correspondant
            foreach (T mu in list)
            {
                //Si l'objet éxiste dans la liste alors on l'enlève
                if (mu.Equals(objet))
                {
                    list.Remove(objet);
                    return;
                }
            }
            // On ajoute l'objet dans la liste
            list.Insert(0, objet);
        }

        public void AjouterObjetDernierementEcoute<T>(T objet, List<T> list)
        {
            foreach(T o in list)
            {
               
                if (objet != null)
                {
                    if (objet.Equals(o))
                    {
                        list.Remove(o);
                        AjouterObjetDernierementEcoute(objet, list);
                        return;
                    }
                }

            }
            if (objet != null) { list.Insert(0, objet); }
            
        }
    }
}
