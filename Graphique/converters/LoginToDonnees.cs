using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Graphique.converters
{
    class LoginToDonnees
    {
        public static string Decrypt(string nom, string mdp)
        {
            Dictionary<string, Dictionary<string, string>> identifiants = Modele.Serialisation.DeserialisationJson("..\\save\\login.json") as Dictionary<string, Dictionary<string, string>>;


            foreach (KeyValuePair<string,Dictionary<string,string>> keyValue in identifiants)
            {
                if(keyValue.Key== nom)
                {

                    /////////////////////////////////////////////////On décrypte le mot de passe

                    // Les deux clef permettant le cryptage et le décryptage du mot de passe
                    string ivString = "_ð½U4HG";
                    byte[] iv = Encoding.ASCII.GetBytes(ivString);
                    byte[] key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };


                    //On récupère le mot de passe
                    var mdpCrypt = keyValue.Value["mdp"];

                    //On transforme le string en tableau d'octet 
                    byte[] mdpTransformByte = Convert.FromBase64String(mdpCrypt);

                    //On instancie un triple DES (l'algorithme de chiffrement )
                    TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

                    TDES.Padding= PaddingMode.PKCS7;
                    var decryptor = TDES.CreateDecryptor(key, iv); //On créé un décrypteur a partir de nos clefs
                    byte[] decryptedTextAsByte = decryptor.TransformFinalBlock(mdpTransformByte, 0, mdpTransformByte.Length); //On décrypte le message



                    string mdpDepcrypt = Encoding.Default.GetString(decryptedTextAsByte); //On transforme le message décrypté en string 

                    if (mdpDepcrypt == mdp) // Si les deux mot de passe sont bon on retourne le chemin des odnnées de l'utilisateur
                    {
                        return keyValue.Value["save"];
                    }
                    return null;
                }
            }



            return null;
        }

    }
}
