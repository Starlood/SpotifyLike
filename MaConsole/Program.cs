using System;
using Modele;
using Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Security.Cryptography;


namespace MaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Stub.SauvegardeDonneesStub();

            Artistetheque a = Stub.CreerArtistetheque();
            Discotheque d = Stub.CreerDisco(a);

        }



        /// <summary>
        /// Test de la sérialisation et de la désérialisation binaire
        /// </summary>
        public static void TestSerialDeserial()
        {
            Artistetheque a = Stub.CreerArtistetheque();
            Discotheque d = Stub.CreerDisco(a);


            Serialisation.SerialisationBin(d, "..\\save\\disco.bin");

            Discotheque d2 = null;
            d2 = Serialisation.DeserialisationBin("..\\save\\disco.bin") as Discotheque;


            Console.WriteLine("fin");

            foreach (Musique mu in d.DicoMusiques["MusiquesAimees"])
            {
                Console.WriteLine(mu);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Musique m = a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[2];

            
            d.AimerObj(m, d.DicoMusiques["MusiquesAimees"]);
            Serialisation.SerialisationBin(d2, "..\\save\\disco.bin");
            Discotheque d3 = null;
            d3 = Serialisation.DeserialisationBin("..\\save\\disco.bin") as Discotheque;


            foreach (Musique mu in d.DicoMusiques["MusiquesAimees"])
            {
                Console.WriteLine(mu);
            }

        }

        /// <summary>
        /// Test pour aimer une musique (marche aussi pour un artiste)
        /// </summary>
        private static void TestAimerMusique()
        {
            Artistetheque a = Stub.CreerArtistetheque();
            Discotheque d = Stub.CreerDisco(a);


            foreach (Musique mu in d.DicoMusiques["MusiquesAimees"])
            {
                Console.WriteLine(mu);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Musique m = a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[2];

            d.AimerObj(m, d.DicoMusiques["MusiquesAimees"]);
            foreach (Musique mu in d.DicoMusiques["MusiquesAimees"])
            {
                Console.WriteLine(mu);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            d.AimerObj(m, d.DicoMusiques["MusiquesAimees"]);
            foreach (Musique mu in d.DicoMusiques["MusiquesAimees"])
            {
                Console.WriteLine(mu);
            }
            Console.WriteLine("fin...");
        }
        private void TestMusiqueDernierementEcoute()
        {

            Artistetheque a = Stub.CreerArtistetheque();
            Discotheque d = Stub.CreerDisco(a);
            foreach (Musique m in d.DicoMusiques["MusiquesDernierementsEcoutes"]) Console.WriteLine(m);
            
            Console.WriteLine();

            Console.WriteLine();

            d.AjouterObjetDernierementEcoute(a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[2], d.DicoMusiques["MusiquesDernierementsEcoutes"]);
            foreach (Musique m in d.DicoMusiques["MusiquesDernierementsEcoutes"]) Console.WriteLine(m);

            d.AjouterObjetDernierementEcoute(a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[3], d.DicoMusiques["MusiquesDernierementsEcoutes"]);
            d.AjouterObjetDernierementEcoute(a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[4], d.DicoMusiques["MusiquesDernierementsEcoutes"]);
            d.AjouterObjetDernierementEcoute(a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[5], d.DicoMusiques["MusiquesDernierementsEcoutes"]);
            d.AjouterObjetDernierementEcoute(a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[6], d.DicoMusiques["MusiquesDernierementsEcoutes"]);
            d.AjouterObjetDernierementEcoute(a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[7], d.DicoMusiques["MusiquesDernierementsEcoutes"]);
            d.AjouterObjetDernierementEcoute(a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[8], d.DicoMusiques["MusiquesDernierementsEcoutes"]);


            foreach (Musique m in d.DicoMusiques["MusiquesDernierementsEcoutes"]) Console.WriteLine(m);
            Console.WriteLine();
            Console.WriteLine();
            d.AjouterObjetDernierementEcoute(a.LesArtistes[0].ListeAlbums[1].MusiquesAlbum[3], d.DicoMusiques["MusiquesDernierementsEcoutes"]);

            foreach (Musique m in d.DicoMusiques["MusiquesDernierementsEcoutes"]) Console.WriteLine(m);

            Console.WriteLine();
        }


        /// <summary>
        /// Test de recherche 
        /// </summary>
        private static void TestRecherche()
        {
            Artistetheque Artistetheque = Stub.CreerArtistetheque();

            List<Artiste> RechArt = new List<Artiste>();
            List<Musique> RechMus = new List<Musique>();
            List<Album> RechAlb = new List<Album>();

            Artistetheque.Rechercher("Epilogue", RechArt, RechAlb, RechMus);

            foreach (Artiste a in RechArt) Console.WriteLine(a);
            foreach (Album a in RechAlb) Console.WriteLine(a);
            foreach (Musique a in RechMus) Console.WriteLine(a);

        }

        /// <summary>
        /// Test pour ajouter une musique dans une playlists
        /// </summary>
        private static void TestAjouterMusiqueDansPLaylist()
        {
            Artistetheque a = Stub.CreerArtistetheque();
            Discotheque d = Stub.CreerDisco(a);


            foreach (Musique m in d.DicoPlaylists["MesPlaylists"][0].PlaylistMusique) Console.WriteLine(m);
            Console.WriteLine();
            Console.WriteLine();

            Musique mu = a.LesArtistes[1].ListeAlbums[0].MusiquesAlbum[0];

            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(mu);


            foreach (Musique m in d.DicoPlaylists["MesPlaylists"][0].PlaylistMusique) Console.WriteLine(m);
            Console.WriteLine();
            Console.WriteLine();

            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(mu);

            foreach (Musique m in d.DicoPlaylists["MesPlaylists"][0].PlaylistMusique) Console.WriteLine(m);
        }


        

    }
}
