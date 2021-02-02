using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modele;
namespace Graphique
{
    /// <summary>
    /// Logique d'interaction pour MesMusiques.xaml
    /// </summary>
    public partial class MesMusiques : UserControl
    {
        public Artistetheque Artistetheque { get; set; }

        public Discotheque Discotheque { get; set; }
        public MesMusiques(Artistetheque a, Discotheque d)
        {
            InitializeComponent();
            Artistetheque = a;
            Discotheque = d;

            musiques.DataContext = Discotheque.DicoMusiques["MusiquesAimees"]; //On définit le dataContext


        }

        private void SelChange(object sender, SelectionChangedEventArgs e)
        {
            this.Content = new UneMusique(Artistetheque,Discotheque,musiques.SelectedItem as Musique);// Si on clique sur une musique dans la listbox on ouvre sa page dédié
        }
    }
}
