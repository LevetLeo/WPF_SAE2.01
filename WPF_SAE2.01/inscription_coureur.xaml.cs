﻿using System;
using System.Collections.Generic;
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
            char sexe;
            string federation;
            string codeClub;
            if(TBNom.Text.ToString() is not null && TBPreom.Text.ToString() is not null && TBVille.Text.ToString() is not null && (RDFemme.IsChecked == true || RDHomme.IsChecked == true) && TBNum.Text.ToString() is not null && (ComboBoxFFA.IsSelected == true || ComboBoxFFC.IsSelected == true || ComboBoxFFG.IsSelected == true || ComboBoxFFT.IsSelected == true) && (ComboBoxIUT.IsSelected == true || ComboBoxUSMB.IsSelected ==true || ComboBoxAnnecy.IsSelected==true || ComboBoxChambery.IsSelected == true || ComboBoxSoir.IsSelected == true))
            {
                if (RDFemme.IsChecked == true)
                {
                    sexe = 'F';
                }
                else
                    sexe = 'H';
                if (ComboBoxFFA.IsSelected == true)
                {
                    federation = "1";
                }
                else if (ComboBoxFFT.IsSelected == true)
                {
                    federation = "2";
                }
                else if (ComboBoxFFG.IsSelected == true)
                {
                    federation = "3";
                }
                else
                    federation = "0";
                if (ComboBoxIUT.IsSelected == true)
                    codeClub = "C1";
                else if (ComboBoxUSMB.IsSelected == true)
                    codeClub = "C2";
                else if (ComboBoxSoir.IsSelected == true)
                    codeClub = "C3";
                else if(ComboBoxAnnecy.IsSelected == true)
                { codeClub = "C4"; }
                else
                    codeClub = "C5";
                /*Club club1 = new Club(federation);
                Federation federation1 = new Federation(federation);
                CoureurClasse coureur = new CoureurClasse(TBNom.Text.ToString,TBPreom.Text.ToString(),TBVille.Text.ToString(),sexe,int.Parse(TBNum.Text.ToString()),federation,federation);
                CoureurClasse.Create(coureur);*/

                var page = new Coureur();
                page.Show();
                
                this.Close();

            }
            

        }
    }
}
