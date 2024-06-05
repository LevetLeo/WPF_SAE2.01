using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
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
using static WPF_SAE2._01.Club;

namespace WPF_SAE2._01
{
    /// <summary>
    /// Logique d'interaction pour inscription_coureur.xaml
    /// </summary>
    public partial class inscription_coureur : Window
    {
        private ObservableCollection<CoureurClasse> lesCoureurss = new ObservableCollection<CoureurClasse>();
        private ObservableCollection<Federation> lesFederationss = new ObservableCollection<Federation>();
        private ObservableCollection<Club> lesClubss = new ObservableCollection<Club>();


        public ObservableCollection<CoureurClasse> LesCoureurss { get => lesCoureurss; set => lesCoureurss = value; }
        public ObservableCollection<Federation> LesFederationss { get => lesFederationss; set => lesFederationss = value; }
        public ObservableCollection<Club> LesClubss { get => lesClubss; set => lesClubss = value; }


        public inscription_coureur()
        {
            InitializeComponent();
            LesCoureurss = CoureurClasse.Read();
            LesFederationss = Federation.Read();
            LesClubss = Club.Read();
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {

            char sexe;
            string federation;
            string codeClub;
            if(TBNom.Text.ToString() is not null && TBPreom.Text.ToString() is not null && TBVille.Text.ToString() is not null && (RDFemme.IsChecked == true || RDHomme.IsChecked == true) && TBNum.Text.ToString() is not null && (ComboBoxFFA.IsSelected == true || ComboBoxFFC.IsSelected == true || ComboBoxFFG.IsSelected == true || ComboBoxFFT.IsSelected == true) && (ComboBoxIUT.IsSelected == true || ComboBoxUSMB.IsSelected ==true || ComboBoxAnnecy.IsSelected==true || ComboBoxChambery.IsSelected == true || ComboBoxSoir.IsSelected == true))
            {
                foreach(CoureurClasse unCoureur in LesCoureurss)
                {
                    if(unCoureur.NomCoureur == TBNom.Text.ToString() && unCoureur.PrenomCoureur == TBPreom.Text.ToString())
                    {
                        // fairee update
                        MessageBox.Show("erreur coureur deja enrengistre");
                    }
                }
                if (RDFemme.IsChecked == true)
                {
                    sexe = 'F';
                }
                else
                    sexe = 'H';
                if (ComboBoxFFA.IsSelected == true)
                {
                    codeClub = "FFA";
                }
                else if (ComboBoxFFT.IsSelected == true)
                {
                    codeClub = "FFT";
                }
                else if (ComboBoxFFG.IsSelected == true)
                {
                    codeClub = "FFG";
                }
                else
                    codeClub = "FFC";


                if (ComboBoxIUT.IsSelected == true)
                    federation = "C1";
                else if (ComboBoxUSMB.IsSelected == true)
                    federation = "C2";
                else if (ComboBoxSoir.IsSelected == true)
                    federation = "C3";
                else if(ComboBoxAnnecy.IsSelected == true)
                    federation = "C4"; 
                else
                    federation = "C5";

                bool success = Enum.TryParse(federation, out Club.CodeClub club1);
                if (success)
                {
                    Console.WriteLine(club1.ToString());
                }
                else
                {
                    Console.WriteLine("Couldn't convert");
                }

                //CoureurClasse coureur = new CoureurClasse(TBNom.Text.ToString(),TBPreom.Text.ToString(),TBVille.Text.ToString(),sexe,int.Parse(TBNum.Text.ToString()),club1,federation1);
                //CoureurClasse.Create(coureur,DataAccess.Connexion);

                var page = new Coureur();
                page.Show();
                
                this.Close();

            }
            

        }
    }
}
