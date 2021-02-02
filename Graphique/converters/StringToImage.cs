using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace Graphique.converters
{
    class StringToImage : IValueConverter
    {

        private static string ImagesPath;

        static StringToImage()
        {
            ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\images\\"); // ON définit le chemin partiel de l'image
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string; // On récupère l'image en question

            if (string.IsNullOrWhiteSpace(imageName)) return null; //Si null on return

            string imagePath = Path.Combine(ImagesPath, imageName); // On combine le chemin partiel(constructeur) et le chemin de l'image en question

            return new Uri(imagePath,UriKind.RelativeOrAbsolute); // On retourne un Uri de l'image 

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // On a pas besoin de convertir dans l'autre sens
        }
    }
}
