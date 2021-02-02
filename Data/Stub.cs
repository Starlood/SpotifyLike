using System;
using Modele;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections;

namespace Data
{
    public static class Stub
    {



        public static void SauvegardeDonneesStub()
        {

            string lien = "..\\save\\login.json";
            File.Delete(lien);
            StreamWriter fs = new StreamWriter(lien);
            fs.WriteLine("{}");

            fs.Close();

            Artistetheque a = Stub.CreerArtistetheque();
            Discotheque d = Stub.CreerDisco(a);
            Discotheque d1 = Stub.CreerDisco2(a);
            Discotheque d2 = Stub.CreerDisco3(a);


            Serialisation.SerialisationBin(a, "..\\save\\artistetheque.bin");
            Serialisation.SerialisationBin(d, d.Save);
            Serialisation.SerialisationBin(d1, d1.Save);
            Serialisation.SerialisationBin(d2, d2.Save);
        }
    

        public static void ChargerDonnees(Artistetheque a , Discotheque d)
        {
            
            a = Serialisation.DeserialisationBin("..\\save\\artistetheque.bin") as Artistetheque;
            d = Serialisation.DeserialisationBin("..\\save\\disco.bin") as Discotheque;
        }


        private static void AjouterUserAuLogin(Discotheque d, string mdp)
        {
            string lien = "..\\save\\login.json";

            Dictionary<string, Dictionary<string, string>> ancien = Serialisation.DeserialisationJson(lien)as Dictionary<string,Dictionary<string,string>>;
            if (ancien==null)
            {
                ancien = new Dictionary<string, Dictionary<string, string>>();
            }


            foreach(KeyValuePair<string, Dictionary<string, string>> keyValuePair in ancien)
            {
                if (d.EstArtiste.NomArtiste == keyValuePair.Key)
                {
                    return;
                }
            }


            /////////////////////////////////////////////////On crypte le mot de passe avant de sauvegarder les données

            // Les deux clef permettant le cryptage et le décryptage du mot de passe
            string ivString = "_ð½U4HG";
            byte[] iv = Encoding.ASCII.GetBytes(ivString);
            byte[] key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            //On instancie un triple DES (l'algorithme de chiffrement )
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            TDES.Padding = PaddingMode.PKCS7; // Le padding évite d'avoir des problèmes de taille dans la variable key

            byte[] mdpByte = Encoding.Default.GetBytes(mdp); //On transforme le mot de passe en tableau d'octet

            var encryptor = TDES.CreateEncryptor(key, iv); // On créé l'encrypteur à l'aide de nos clefs

            byte[] cryptedTextAsByte = encryptor.TransformFinalBlock(mdpByte, 0, mdpByte.Length); // On crypte notre mot de passe

            Dictionary<string, string> dico = new Dictionary<string,string> //On ajoute les données dans le dictionnaires de l'utilisateur
            {
                {"mdp",Convert.ToBase64String(cryptedTextAsByte)},
                {"save",d.Save }
            };

            
            ancien.Add(d.EstArtiste.NomArtiste,dico); // On ajoute le dictionnaire de l'utilisateur au dictionnaire contenant tous les identifiants

            Serialisation.SerialisationJson(lien, ancien); // On sauvegarde le dictionnaire dans le fichier login

        }



        public static Artistetheque CreerArtistetheque()
        {
            

            List<Artiste> l = new List<Artiste>();
            Artistetheque a = new Artistetheque(l);
            l.Add(new Artiste("Orelsan", "Je suis un vrai rappeur","profil\\Orelsan.jpg"));
            Artiste Orelsan = l[0];

            l.Add(new Artiste("Stromae", "Chanteur Belge", "profil\\Stromae.jpg"));
            Artiste Stromae = l[1];
            
            l.Add(new Artiste("Vald", "Je joue pas les rappeurs", "profil\\Vald.jpg"));
            Artiste Vald = l[2];

            l.Add(new Artiste("BigFlo et Oli","C'est du vrai rap même si tu dis que non", "profil\\BigfloEtOli.jpg"));
            Artiste BigFloEtOli = l[3];

            l.Add(new Artiste("Papa de Bigflo et Oli", "Je suis le papa de 2 grands rappeurs"));
            Artiste Papa = a.LesArtistes[4];

            l.Add(new Artiste("Baoui", "Mayotte en force", "profil\\Baoui.jpg"));
            Artiste Baoui = a.LesArtistes[5];

            l.Add(new Artiste("Indochine", "Groupe de pop rock français","profil\\Indochine.jpg"));
            Artiste Indochine = a.LesArtistes[6];

            l.Add(new Artiste("Drake", "Rappeur américain célèbre", "profil\\Drake.jpg"));
            Artiste Drake = a.LesArtistes[7];

            l.Add(new Artiste("Johnny Hallyday", "Chanteur français très apprécié", "profil\\Johnny.jpg"));
            Artiste JohnnyHaliday = a.LesArtistes[8];

            DateTime d = new DateTime(2017,10,20);
            DateTime d1 = new DateTime(2017, 10, 21);
            DateTime d2 = new DateTime(2018, 11, 1);

            string poch1 = "pochettes\\Orelsan-LaFeteEstFinie.jpg";
            string pochValdCemonde = "pochettes\\Vald-CeMondeEstCruel.jpg";
            string pochIndochineWax = "pochettes\\Indochine-Wax.jpg";
            string pochDrakeScropion = "pochettes\\Drake-Scorpion.jpg";
            string pocheJhonnyParcDesPRinces = "pochettes\\Johnny-Parc.jpg";
            string pocheValdXeu = "pochettes\\Vald-Xeu.jpg";
            string pocheJohnnyMonPays = "pochettes\\Johnny-MonPays.jpg";
            

            JohnnyHaliday.CreerAlbum("Parc de princes 2003", pocheJhonnyParcDesPRinces);
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Dans l'arène", "https://www.youtube.com/watch?v=awmOCSNmjTA", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Que je t'aime", "https://www.youtube.com/watch?v=7LgMsR-jI1k", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Fils de personne ", "https://www.youtube.com/watch?v=0OoD42P6NOU", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Gabrielle", "https://www.youtube.com/watch?v=CaIL-HhimyY", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Pense à moi", "https://www.youtube.com/results?search_query=pesne+a+moi", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Quelque chose de Tennessee", "https://www.youtube.com/watch?v=8Sc4Pb7d1Nk", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Que restera-t-il ?", "https://www.youtube.com/watch?v=9rocLXBJCCA", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("J'oublierai ton nom", "https://www.youtube.com/watch?v=BL6E8QSWfaM", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("O Carole", "https://www.youtube.com/watch?v=kcHNt2myP6U", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Je n'ai jamais pleuré", "https://www.youtube.com/watch?v=hZQeecjN0SU", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Ma gueule", "https://www.youtube.com/watch?v=9ULK7C6iZjs", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("L'instinct ", "https://www.youtube.com/watch?v=LkIVamdIyh0", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Diego libre dans sa tête", "https://youtu.be/P3mU5LgIBhU", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Marie", "https://www.youtube.com/watch?v=ArKC23sfhoA", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Vivre pour le meilleur", "https://www.youtube.com/watch?v=bjamwLTApog", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));
            JohnnyHaliday.ListeAlbums[0].AjouterMusique(new Musique("Ride for JH", "https://www.youtube.com/watch?v=K0a0A8_otmk", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJhonnyParcDesPRinces));

            JohnnyHaliday.CreerAlbum("Mon pays c'est l'amour", pocheJohnnyMonPays);
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("J'en parlerai au diable", "https://www.youtube.com/watch?v=CobeBZNlR8E", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("Mon pays, c'est l'amour", "https://www.youtube.com/watch?v=x1qagp70MEk", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("Made in Rock'n'Roll ", "https://www.youtube.com/watch?v=L-EC4GzyYD4", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("Pardonne-moi", "https://www.youtube.com/watch?v=XTzCVNn1OQk", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("Interlude ", "https://www.youtube.com/watch?v=oam3BBwDE4E", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("4 M²", "https://www.youtube.com/watch?v=Kxbjb0ZILiM", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("Back in LA", "https://www.youtube.com/watch?v=ANlyUF6Acw0", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("L'Amérique de William", "https://www.youtube.com/watch?v=Yn5I6U-Ap3g", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("Un enfant du siècle", "https://www.youtube.com/watch?v=r2Hq2HaAPeg", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("Tomber encore", "https://www.youtube.com/watch?v=cepAVgPXZ9cb3PRlRF1BG0", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));
            JohnnyHaliday.ListeAlbums[1].AjouterMusique(new Musique("Je ne suis qu'un homme", "https://www.youtube.com/watch?v=cepAVgPXZ9c", new List<Artiste> { JohnnyHaliday }, (TypeMusicaux)4, d, pocheJohnnyMonPays));

        

            Drake.CreerAlbum("Scorpion" , "pochettes\\Drake-Scorpion.jpg");
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Survival", "https://www.youtube.com/watch?v=rW0l8JVd3Qg", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Nonstop", "https://www.youtube.com/watch?v=007lWkD5NSE", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Elevate", "https://www.youtube.com/watch?v=1e4hVZYPsWI", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Emotionless", "https://www.youtube.com/watch?v=KGuLwJ26Ybs", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("God's Plan", "https://www.youtube.com/watch?v=t2eu7mZHZzA", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("I'm Upset", "https://www.youtube.com/watch?v=wS4ESheuHDY", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("8 Out of 10", "https://www.youtube.com/watch?v=-iQG1poRWjY", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Mob Ties", "https://www.youtube.com/watch?v=pzAIhjxEemw", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Can't Take a Joke", "https://www.youtube.com/watch?v=11LZl8GJjU4", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Sandra's Rose", "https://www.youtube.com/watch?v=8_MGIPSLi-U", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Talk Up ", "https://www.youtube.com/watch?v=9r7nMxAul3I", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));
            Drake.ListeAlbums[0].AjouterMusique(new Musique("Is There More", "https://www.youtube.com/watch?v=yrFlkJS10cI", new List<Artiste> { Drake }, (TypeMusicaux)3, d, pochDrakeScropion));


            Indochine.CreerAlbum("Wax", "pochettes\\Indochine-Wax.jpg");
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Unisexe", "https://www.youtube.com/watch?v=aeprxC-HrqI&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=1", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Révolution", "https://www.youtube.com/watch?v=fKKUrhT_Ap0&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=2", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Drug star", "https://www.youtube.com/watch?v=GIAyBi00kPE&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=3", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Je n'embrasse pas", "https://www.youtube.com/watch?v=IF7l2Oprtug&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=4", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Coma, coma ,coma", "https://www.youtube.com/watch?v=4Zu8gTtlGpk&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=5", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Echo-Ruby", "https://www.youtube.com/watch?v=5OnK-xCzKSo&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=6", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Satellite", "https://www.youtube.com/watch?v=fEeeF36D5XM&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=8", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Mire-Live", "https://www.youtube.com/watch?v=og3p7PMhdm8&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=9", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Ce Soir, le Ciel", "https://www.youtube.com/watch?v=QhtIOKLNPvY&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=10", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Kissing My Song", "https://www.youtube.com/watch?v=VTuSWpjorX8&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=11", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax)); 
            Indochine.ListeAlbums[0].AjouterMusique(new Musique("Peter Pan", "https://www.youtube.com/watch?v=6K8z9NgsM8U&list=PLlBr7ZGuaUroaaAAunGgHpbEZYNFJhQnJ&index=13", new List<Artiste> { Indochine }, (TypeMusicaux)6, d, pochIndochineWax));
            
            
            Vald.CreerAlbum("Ce monde est cruel", "pochettes\\Vald-CeMondeEstCruel.jpg");
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Poches pleines", "https://www.youtube.com/watch?v=WH_cbPu6GcA&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=1", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("NQNTMQMQMB", "https://www.youtube.com/watch?v=so7KCFMtVuM&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=2", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Journal perso II", "https://www.youtube.com/watch?v=TUEhJmjfC28", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Ce monde est cruel", "https://www.youtube.com/watch?v=SBZfaQubvvY", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Pensionman", "https://www.youtube.com/watch?v=gkHpInm3TUo&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=5", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Ma star", "https://www.youtube.com/watch?v=oDLWNo9sZDY&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=6", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Ignorant", "https://www.youtube.com/watch?v=qC2JUBDmAxg&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=71", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Halloween", "https://www.youtube.com/watch?v=LzMv40ABV1M&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=8", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Dernier retrait", "https://www.youtube.com/watch?v=9rfHd-2mkus&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=9", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Keskivonfer", "https://www.youtube.com/watch?v=z8H-2y6uNNY&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=10", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Pourquoi", "https://www.youtube.com/watch?v=yILpnJFjUOQ&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=11", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("J'pourrai", "https://www.youtube.com/watch?v=x-nZ2_yJBo8&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=12", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("No friends", "https://www.youtube.com/watch?v=78VAhae2VdI&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=13", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("ASB", "https://www.youtube.com/watch?v=5uQgPimX7vU&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=14", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Royal Bacon", "https://www.youtube.com/watch?v=fvnefOJ0Ow4&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=15", new List<Artiste> { Vald }, (TypeMusicaux)3, d, pochValdCemonde));
            Vald.ListeAlbums[0].AjouterMusique(new Musique("Rappel", "https://www.youtube.com/watch?v=R87v1I_7vsg&list=PLNhbn0ZL0L-wnfZx4gfGPxeCEr4c1cp8b&index=16", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pochValdCemonde));

            Vald.CreerAlbum("XEU", "pochettes\\Vald-Xeu.jpg");
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Primitif", "https://www.youtube.com/watch?v=ieQ0Bkjwfj8&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=1", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Seum", "https://www.youtube.com/watch?v=-Z8X8W1T79k&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=2", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("DQTP", "https://www.youtube.com/watch?v=GOa2eb217oo&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=3", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Possédé", "https://www.youtube.com/watch?v=OocA7KuEqco&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=4", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Chepakichui", "https://www.youtube.com/watch?v=eo3IRw7TJeY&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=5", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Résidus", "https://www.youtube.com/watch?v=Oawi7SltA5I&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=6", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("J'entertain", "https://www.youtube.com/watch?v=OIg4xNBkhpk&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=7", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Rituel ", "https://www.youtube.com/watch?v=pORBIsv7OAI&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=8", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Désaccordé", "https://www.youtube.com/watch?v=kutk2XHEZNU&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=9", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Gris", "https://www.youtube.com/watch?v=IfC-nXlgaNU&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=10", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Réflexions basses", "https://www.youtube.com/watch?v=4IwuGjm42hQ&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=11", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Offshore", "https://www.youtube.com/watch?v=7gcMUwS35n0", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Ne me déteste pas", "https://www.youtube.com/watch?v=LGdEWsg8QHw&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=12", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Rocking chair", "https://www.youtube.com/watch?v=wLOS1fN2b4M&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=13", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Dragon", "https://www.youtube.com/watch?v=jvHCrAntiAU&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=14", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Deviens génial", "https://www.youtube.com/watch?v=ZuMssIxmPT0&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=15", new List<Artiste> { Vald }, (TypeMusicaux)2, d, pocheValdXeu));
            Vald.ListeAlbums[1].AjouterMusique(new Musique("Trophée", "https://www.youtube.com/watch?v=TRDo-23JagY&list=PLLtnKr-dyLLkxaNIM_MzDE7_xv6hnxRlu&index=16", new List<Artiste> { Vald }, (TypeMusicaux)1, d, pocheValdXeu));



            Orelsan.CreerAlbum("La fête est finie", "pochettes\\Orelsan-LaFeteEstFinie.jpg");
       
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("San", "https://www.youtube.com/watch?v=qRhxdEvzHJY&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("La fête est finie", "https://www.youtube.com/watch?v=OxrRWJZbnes&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=2", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Basique", "https://www.youtube.com/watch?v=2bjk26RwjyU&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=3", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Tout va bien", "https://www.youtube.com/watch?v=dq6G2YWoRqA&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=4", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Défaite de famille", "https://www.youtube.com/watch?v=wRQEfN8PGYI&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=5", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("La lumière", "https://www.youtube.com/watch?v=xpHJWDvthnQ&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=6", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Bonne meuf", "https://www.youtube.com/watch?v=ZhSvy_lIGz8&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=7", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Quand est-ce que ça s'arrête", "https://www.youtube.com/watch?v=WiZgDUc20AA&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=8", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Cristophe", "https://www.youtube.com/watch?v=uqr1u_K6D5k&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=9", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Zone", "https://www.youtube.com/watch?v=x1UO8wFs2PI&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=10", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Dans ma ville on traîne", "https://www.youtube.com/watch?v=QaMol3Y3be8&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=11", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("La pluie", "https://www.youtube.com/watch?v=37StRy0LEbI&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=12", new List<Artiste> { Orelsan,Stromae }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Paradis", "https://www.youtube.com/watch?v=DxkSPr3CAHs&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=13", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));
            Orelsan.ListeAlbums[0].AjouterMusique(new Musique("Note pour trop tard", "https://www.youtube.com/watch?v=eUyxCuyxnqo&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=14", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d, poch1));

            Orelsan.MusiquesArtiste.Add(new Musique("Esst ce que ça marche", "https://www.youtube.com/watch?v=eUyxCuyxnqo&list=OLAK5uy_mZUng4rV-eXJCvaktivSXpju880lbmXjo&index=14", new List<Artiste> { Orelsan }, (TypeMusicaux)1, d1));

            string poch2 = "pochettes\\Orelsan-Epilogue.jpg";
            Orelsan.CreerAlbum("Epilogue", poch2);
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Fantômes", "https://www.youtube.com/watch?v=GtClykmqxXs&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA", new List<Artiste> { l[0] }, (TypeMusicaux)1,d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Tout ce que je sais", "https://www.youtube.com/watch?v=vzmItNhfZBA&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=2", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("La famille, la famille", "https://www.youtube.com/watch?v=2plxPVOI6lo&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=3", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Mes grands-parents", "https://www.youtube.com/watch?v=Q_Xbx7IxKqE&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=4", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Tout va bien(Remix)", "https://www.youtube.com/watch?v=mcEApbAAPJY&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=5", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Discipline", "https://www.youtube.com/watch?v=eHoA-W3F9hI&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=6", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Adieu les filles", "https://www.youtube.com/watch?v=og722xAD-EQ&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=7", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Excuses ou mensonges", "https://www.youtube.com/watch?v=WcFOQxitZHc&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=8", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Dis-moi", "https://www.youtube.com/watch?v=haPpLN2i-Wg&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=9", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Rêves bizarres", "https://www.youtube.com/watch?v=iXzBdNjpYw0&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=10", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));
            Orelsan.ListeAlbums[1].AjouterMusique(new Musique("Epilogue", "https://www.youtube.com/watch?v=04XNJqau9_c&list=OLAK5uy_kudHEDalBKIfEFBHrQkhYuAqLbsGjczWA&index=11", new List<Artiste> { l[0] }, (TypeMusicaux)1, d2, poch2));


            
            
            Stromae.CreerAlbum("racine carée");
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("Ta fête", "https://www.youtube.com/watch?v=ublchJYzhao&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY", new List<Artiste> { Stromae },(TypeMusicaux) 2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("Papaoutai", "https://www.youtube.com/watch?v=oiKj0Z_Xnjc&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=2", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("bâtard", "https://www.youtube.com/watch?v=fatfDUPiJ5U&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=3", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("ave cesaria", "https://www.youtube.com/watch?v=8kmzvE6su5I&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=4", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("tous les mêmes", "https://www.youtube.com/watch?v=CAMWdvo71ls&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=5", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("Formidable", "https://www.youtube.com/watch?v=S_xH7noaqTA&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=6", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("moules frites", "https://www.youtube.com/watch?v=2Z2fQjJIWMw&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=7", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("carmen", "https://www.youtube.com/watch?v=UKftOH54iNU&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=8", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("humain à l'eau", "https://www.youtube.com/watch?v=49qhh0o2QHw&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=9", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("quand c'est?", "https://www.youtube.com/watch?v=8aJw4chksqM&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=10", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("sommeil", "https://www.youtube.com/watch?v=5E0ogqe1w5U&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=11", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("merci", "https://www.youtube.com/watch?v=2qfm71JSaXA&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=12", new List<Artiste> { Stromae }, (TypeMusicaux)2));
            Stromae.ListeAlbums[0].AjouterMusique(new Musique("avf", "https://www.youtube.com/watch?v=q9hW4MLNp5E&list=OLAK5uy_lWr4RGOx1YgovCSqWzugcJEyG0HqIpxoY&index=13", new List<Artiste> { Stromae }, (TypeMusicaux)2));


            string poch3 = "pochettes\\BigFloetOli_LaVraieVie.jpg";
            DateTime d3 = new DateTime(2017,06,23);
            BigFloEtOli.CreerAlbum("La vraie vie",poch3);
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("La Vraie Vie", "https://www.youtube.com/watch?v=x0R_hPxBtnk&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4", new List<Artiste> { BigFloEtOli},(TypeMusicaux) 3,d3,poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Alors Alors", "https://www.youtube.com/watch?v=UMlLcjpzzjc&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=2", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Personne", "https://www.youtube.com/watch?v=ib_DmsyXBVA&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=3", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Salope!", "https://www.youtube.com/watch?v=-wGB2Pyrqkc&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=4", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Trop tard", "https://www.youtube.com/watch?v=H4GY3cpFpBk&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=5", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Papa", "https://www.youtube.com/watch?v=dMIPaab43Hw&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=6", new List<Artiste> { BigFloEtOli,Papa }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Répondez moi", "https://www.youtube.com/watch?v=DapXxtY4ed4&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=7", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Olivio", "https://www.youtube.com/watch?v=2dL22tBYWqA&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=8", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("La vie normale", "https://www.youtube.com/watch?v=5kf53YGy-aE&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=9", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Autre part", "https://www.youtube.com/watch?v=8rdOcNCDLVk&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=10", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Dommage", "https://www.youtube.com/watch?v=8AF-Sm8d8yk&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=11", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Ca va trop vite", "https://www.youtube.com/watch?v=MiYjOkvNmSo&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=12", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Sac à dos", "https://www.youtube.com/watch?v=eu9TKwYO7rE&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=13", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Dans mon lit", "https://www.youtube.com/watch?v=CNpn6NcDNxw&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=14", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Je suis", "https://www.youtube.com/watch?v=8EyoKfM2Bv4&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=15", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Cigarette", "https://www.youtube.com/watch?v=OojJuTDxiSc&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=16", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Dites rien à ma mère", "https://www.youtube.com/watch?v=YGgJqGO6y08&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=17", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Pour un pote", "https://www.youtube.com/watch?v=99AS1Rq5dIM&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=19", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("A mon retour", "https://www.youtube.com/watch?v=F4WmmpZIeO8&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=20", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3)); BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("", "", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Début d'empire", "https://www.youtube.com/watch?v=UloRo5Xspvc&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=21", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("La tempête", "https://www.youtube.com/watch?v=btBzrysCtcQ&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=22", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Du disque dur au disque d'or", "https://www.youtube.com/watch?v=5GS_AAxZeFc&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=23", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));
            BigFloEtOli.ListeAlbums[0].AjouterMusique(new Musique("Mytho", "https://www.youtube.com/watch?v=r8CIahMDfl0&list=OLAK5uy_nRvWYf9bJ3SkRBfnf_EaDPOR2go7rALt4&index=24", new List<Artiste> { BigFloEtOli }, (TypeMusicaux)3, d3, poch3));



            DateTime d4 = new DateTime(2020,06,02) ;
            Baoui.MusiquesArtiste.Add(new Musique("Guedro", "https://www.youtube.com/watch?v=TBWotg_b6rA", new List<Artiste> { Baoui }, (TypeMusicaux)1, d4));




            return a;
            
        }
 





        public static Discotheque CreerDisco(Artistetheque artistetheque)
        {
            Discotheque d = new Discotheque();
            List<Artiste> l = artistetheque.LesArtistes;

            d.EstArtiste = l[0];
            d.Save = $"..\\save\\{d.EstArtiste.NomArtiste}.bin";
            AjouterUserAuLogin(d,"MdpOrelsan");


            d.DicoMusiques["MusiquesAimees"].Add(l[0].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoMusiques["MusiquesAimees"].Add(l[0].ListeAlbums[0].MusiquesAlbum[1]);
            d.DicoMusiques["MusiquesAimees"].Add(l[0].ListeAlbums[0].MusiquesAlbum[2]);
            d.DicoMusiques["MusiquesAimees"].Add(l[0].ListeAlbums[0].MusiquesAlbum[11]);

            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Ma super Playlist"));

            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[0].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[1].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[0].ListeAlbums[0].MusiquesAlbum[1]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[0].ListeAlbums[0].MusiquesAlbum[2]);

            d.DicoPlaylists["PlaylistsDernierementsEcoutes"].Add(d.DicoPlaylists["MesPlaylists"][0]);

            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[1].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[0].MusiquesAlbum[3]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[1].MusiquesAlbum[0]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[0].MusiquesAlbum[8]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[1].MusiquesAlbum[2]);


            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Ma super Playlist2"));
            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Ma super Playlist3"));
            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Ma super Playlist4"));

            d.DicoArtistes["ArtistesAimes"].Add(l[0]);
            d.DicoArtistes["ArtistesAimes"].Add(l[1]);
            d.DicoArtistes["ArtistesAimes"].Add(l[2]);



            return d;
        }
        public static Discotheque CreerDisco2(Artistetheque artistetheque)
        {
            Discotheque d = new Discotheque();
            
            List<Artiste> l = artistetheque.LesArtistes;

            d.EstArtiste = l[1];
            d.Save = $"..\\save\\{d.EstArtiste.NomArtiste}.bin";
            AjouterUserAuLogin(d, "MdpStromae");



            d.DicoMusiques["MusiquesAimees"].Add(l[0].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoMusiques["MusiquesAimees"].Add(l[0].ListeAlbums[0].MusiquesAlbum[1]);
            d.DicoMusiques["MusiquesAimees"].Add(l[0].ListeAlbums[0].MusiquesAlbum[2]);
            d.DicoMusiques["MusiquesAimees"].Add(l[0].ListeAlbums[0].MusiquesAlbum[11]);

            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Ma super Playlist"));

            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[0].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[1].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[0].ListeAlbums[0].MusiquesAlbum[1]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[0].ListeAlbums[0].MusiquesAlbum[2]);

            d.DicoPlaylists["PlaylistsDernierementsEcoutes"].Add(d.DicoPlaylists["MesPlaylists"][0]);

            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[1].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[0].MusiquesAlbum[3]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[1].MusiquesAlbum[0]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[0].MusiquesAlbum[8]);
            d.DicoMusiques["MusiquesDernierementsEcoutes"].Add(l[0].ListeAlbums[1].MusiquesAlbum[2]);


            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Ma super Playlist2"));
            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Ma super Playlist3"));
            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Ma super Playlist4"));

            d.DicoArtistes["ArtistesAimes"].Add(l[0]);
            d.DicoArtistes["ArtistesAimes"].Add(l[1]);
            d.DicoArtistes["ArtistesAimes"].Add(l[2]);



            return d;
        }

        public static Discotheque CreerDisco3(Artistetheque artistetheque)
        {
            Discotheque d = new Discotheque();

            List<Artiste> l = artistetheque.LesArtistes;

            d.EstArtiste = l[5];

            d.Save = $"..\\save\\{d.EstArtiste.NomArtiste}.bin";
            AjouterUserAuLogin(d, "MdpBaoui");


            d.DicoArtistes["ArtistesAimes"].Add(l[5]);



            d.DicoPlaylists["MesPlaylists"].Add(new Playlist("Musiques que j'adore"));

            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[0].ListeAlbums[1].MusiquesAlbum[0]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[1].ListeAlbums[0].MusiquesAlbum[0]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[3].ListeAlbums[0].MusiquesAlbum[1]);
            d.DicoPlaylists["MesPlaylists"][0].AjouterMusique(l[0].ListeAlbums[0].MusiquesAlbum[2]);



            return d;
        }

    }
}
