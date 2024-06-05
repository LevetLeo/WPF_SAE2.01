using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_SAE2._01
{
    /// <summary>
    /// Logique d'interaction pour inscription_coureur.xaml
    /// </summary>
    public partial class inscription_coureur : Window
    {
        public inscription_coureur()
        {
            InitializeComponent();
        }
        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<CoureurClasse> lesCoureurs = CoureurClasse.Read();

            char sexe;
            Club.CodeClub federation;
            Federation.codeFederation codeClub;
            if(TBNom.Text.ToString() is not null && TBPreom.Text.ToString() is not null && TBVille.Text.ToString() is not null && (RDFemme.IsChecked == true || RDHomme.IsChecked == true) && TBNum.Text.ToString() is not null && (ComboBoxFFA.IsSelected == true || ComboBoxFFC.IsSelected == true || ComboBoxFFG.IsSelected == true || ComboBoxFFT.IsSelected == true) && (ComboBoxIUT.IsSelected == true || ComboBoxUSMB.IsSelected ==true || ComboBoxAnnecy.IsSelected==true || ComboBoxChambery.IsSelected == true || ComboBoxSoir.IsSelected == true))
            {
                foreach(CoureurClasse unCoureur in lesCoureurs)
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
                    codeClub = Federation.codeFederation.FFA;
                }
                else if (ComboBoxFFT.IsSelected == true)
                {
                    codeClub = Federation.codeFederation.FFT;
                }
                else if (ComboBoxFFG.IsSelected == true)
                {
                    codeClub = Federation.codeFederation.FFG;
                }
                else
                    codeClub = Federation.codeFederation.FFC;


                if (ComboBoxIUT.IsSelected == true)
                    federation = Club.CodeClub.C1;
                else if (ComboBoxUSMB.IsSelected == true)
                    federation = Club.CodeClub.C2;
                else if (ComboBoxSoir.IsSelected == true)
                    federation = Club.CodeClub.C3;
                else if(ComboBoxAnnecy.IsSelected == true)
                    federation = Club.CodeClub.C4; 
                else
                    federation = Club.CodeClub.C5;

                Club club1 = new Club(federation);
                Federation federation1 = new Federation(codeClub);
                CoureurClasse coureur = new CoureurClasse(TBNom.Text.ToString(),TBPreom.Text.ToString(),TBVille.Text.ToString(),sexe,int.Parse(TBNum.Text.ToString()),club1,federation1);
                //CoureurClasse.Create(coureur);

                var page = new Coureur();
                page.Show();
                
                this.Close();

            }
            

        }
    }
}
