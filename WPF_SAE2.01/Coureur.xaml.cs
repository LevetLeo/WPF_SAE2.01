using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_SAE2._01
{
    /// <summary>
    /// Logique d'interaction pour Coureur.xaml
    /// </summary>
    public partial class Coureur : Window
    {
        public Coureur()
        {
            InitializeComponent();
            ObservableCollection<CoureurClasse>  LesCoureurs = CoureurClasse.Read();
            //Console.WriteLine("count " + LesCoureurs.Count);
            LabelCoureur1.Content = LesCoureurs[0].LienPhotoCoureur + " " + LesCoureurs[0].NomCoureur + " " + LesCoureurs[0].PrenomCoureur + " " +
                LesCoureurs[0].VilleCoureur + " " + LesCoureurs[0].SexeCoureur + " " + LesCoureurs[0].CodeClub + " " + LesCoureurs[0].Federation
                + " " + LesCoureurs[0].LicenceCoureur + " " + LesCoureurs[0].PortableCoureur;

            foreach(CoureurClasse coureur in LesCoureurs)
            {
                //data.dgLesCoureurs.Add(coureur);
            }
        }
    }
}
