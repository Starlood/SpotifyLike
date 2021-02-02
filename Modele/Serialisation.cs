using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Modele
{
    public class Serialisation
    {
        /// <summary>
        ///  Sauvegarde en binaire des données
        /// </summary>
        /// <param name="data">données à sauvegarder</param>
        /// <param name="lienFichier"> chemin du fichier dans lequel on doit sauvegarder</param>
        public static  void SerialisationBin(object data,string lienFichier)
        {

            FileStream fs; // Création d'un FileStream
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(lienFichier)) File.Delete(lienFichier); // Si le fichier existe on le supprime
            fs = File.Create(lienFichier); // On recréer le fichier pour qu'il soit vide
            bf.Serialize(fs,data); // On sauvegarde les données dans le fichier
            fs.Close();
        }
        public static object DeserialisationBin(string lienFichier)
        {
            object data = new object(); // Objet qui va recevoir les données

            FileStream fs = null; // Création d'un FileStream
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(lienFichier)) // Si le fichier existe
            {
                fs = File.OpenRead(lienFichier); //On uvre le fichier
                data = bf.Deserialize(fs); // Désérialisation du fichier dans data
                
            }
            fs.Close();
            return data;
        }

        /// <summary>
        ///  Serialisation d'un objet en json 
        /// </summary>
        /// <param name="lienFichier"> Lien du fichir dans lequel enregistrer les données</param>
        /// <param name="data">données à sérialiser</param>
        public static void SerialisationJson(string lienFichier, object data )
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Les données sont indenté correctement  dans le fichier
            };
            File.WriteAllText(lienFichier, JsonSerializer.Serialize(data, options)); // On sauvegarde les données
            
        }

        /// <summary>
        ///  Déserialistaion de donnée à partir d'un fichier json
        /// </summary>
        /// <param name="lienFichier"> Lien du ficher à désérialiser</param>
        /// <returns> Données déserialisées </returns>
        public static object DeserialisationJson(string lienFichier)
        {

            var des = File.ReadAllText(lienFichier); // On lit l'entierté du fichier
            var marche = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(des); // On les désérialise au format Json
            
            return marche; // Return des données
        }


    }
}
