using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Graphique.converters
{
    class StringToUrl
    {


        public static string ConvertToUrl(string lien)
        {
            Regex YouTubeURLIDRegex = new Regex(@"[?&]v=(?<v>[^&]+)"); //Regex pour transformer le lien de base

            Match m = YouTubeURLIDRegex.Match(lien); //On passe le lien dans la REgex ce qui nous donne les correspondances
            String id = m.Groups["v"].Value; // On récupère l'id de la vidéo
            string url1 = "http://www.youtube.com/embed/" + id + "?rel=0&fs=1&modestbranding=1&version=3&loop=1&showinfo=0&cc_load_policy=1&amp"; //On combine l'id pour donnéer l'url complète
            string page = //On créer la page internet à afficher dans le webBrowser dans laquelle on créer un espace ou on affiche la vidéo
                 "<html>"
                + "<head><meta http-equiv='X-UA-Compatible' content='IE=11' />"
                + "<body>" + "\r\n"
                + "<iframe src=\"" + url1 + "\" width=\"300\" height=\"200\" frameborder=\"0\"  ></iframe>"
                + "</body></html>"; 
            
            return page;
        }
    }
}
