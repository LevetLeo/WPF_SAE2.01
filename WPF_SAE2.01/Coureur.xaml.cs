using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
            
            
            ObservableCollection<CoureurClasse>  lesCoureurs = CoureurClasse.Read();
            DataGridCoureur.ItemsSource = lesCoureurs;



            
        }
        public bool ContientMotCleNom(object obj)
        {
            CoureurClasse unCoureur = obj as CoureurClasse;
            if (String.IsNullOrEmpty(TBSelNom.Text))
                return true;
            else
                return (unCoureur.NomCoureur.StartsWith(TBSelNom.Text, StringComparison.OrdinalIgnoreCase));

        }
        public bool ContientMotCleVille(object obj)
        {
            CoureurClasse unCoureur = obj as CoureurClasse;
            if (String.IsNullOrEmpty(TBSelVille.Text))
                return true;
            else
                return (unCoureur.VilleCoureur.StartsWith(TBSelVille.Text, StringComparison.OrdinalIgnoreCase));

        }
        private void TBSelNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridCoureur.Items.Filter = ContientMotCleNom;
            CollectionViewSource.GetDefaultView(DataGridCoureur.ItemsSource).Refresh();

        }

        private void TBSelVille_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridCoureur.Items.Filter = ContientMotCleVille;
            CollectionViewSource.GetDefaultView(DataGridCoureur.ItemsSource).Refresh();

        }
        /*public bool ContientMotCleFederation(object obj)
        {
            CoureurClasse unCoureur = obj as CoureurClasse;
            if (String.IsNullOrEmpty(ComboBoxFederation.Text))
                return true;
            else
                return (unCoureur.Federation.StartsWith(ComboBoxFederation.Text, StringComparison.OrdinalIgnoreCase));

        }*/






            
            
        private void ComboBoxFederation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


            /*DataGridCoureur.Items.Filter = ContientMotCleFederation;
            CollectionViewSource.GetDefaultView(DataGridCoureur.ItemsSource).Refresh();
*/
        }
    }
}
