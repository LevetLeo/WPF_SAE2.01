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
            /*for(int i = 0; i < LesCoureurs.Count; i++)
            {
                LabelCoureur1.Content = LesCoureurs[i].LienPhotoCoureur + " " + LesCoureurs[i].NomCoureur + " " + LesCoureurs[i].PrenomCoureur + " " +
                LesCoureurs[i].VilleCoureur + " " + LesCoureurs[i].SexeCoureur + " " + LesCoureurs[i].CodeClub + " " + LesCoureurs[i].Federation
                + " " + LesCoureurs[i].LicenceCoureur + " " + LesCoureurs[i].PortableCoureur;
            }*/
            

            foreach(CoureurClasse coureur in LesCoureurs)
            {
                //data.dgLesCoureurs.Add(coureur);
            }
        }
    }
}
