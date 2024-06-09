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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_SAE2._01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationData data;
        ObservableCollection<Course> ListeOBJETCourse;

        public int NumeroCourseRecup()
        {
            int NumeroCourse;
            if (radioChoisir0.IsChecked == true)
            {
                NumeroCourse = 0;
            }
            else if (radioChoisir1.IsChecked == true)
            {
                NumeroCourse = 1;
            }
            else if (radioChoisir2.IsChecked == true)
            {
                NumeroCourse = 2;
            }
            else if (radioChoisir3.IsChecked == true)
            {
                NumeroCourse = 3;
            }
            else
            {
                NumeroCourse = 4;
            }
            return NumeroCourse;
        }
        public static int numCourse;

        public MainWindow()
        {
            data = new ApplicationData();
            this.DataContext = data;
            InitializeComponent();
            int i = 0;
            ObservableCollection<CoureurClasse> lesCoureurs = CoureurClasse.Read();
            DataGridCoureur.ItemsSource = lesCoureurs;



            ListeOBJETCourse = Course.Read();
            Console.WriteLine(ListeOBJETCourse.Count);
            LabelCourse.Content = ListeOBJETCourse[0 + i].NomCourse;
            DistanceCourse.Content = "\n Distance : \n" + ListeOBJETCourse[0 + i].Distance;
            DateCourse.Content = "\n Date de départ : \n" + ListeOBJETCourse[0 + i].DateDepart.Day +
            "/" + ListeOBJETCourse[0 + i].DateDepart.Month + "/" + ListeOBJETCourse[0 + i].DateDepart.Year;
            HeureCourse.Content = "\n Heure depart : \n " + ListeOBJETCourse[0 + i].HeureDepartCourse.Hour + ":"
            + ListeOBJETCourse[0 + i].HeureDepartCourse.Minute;
            PrixCourse.Content = "\n Prix: \n" +
            ListeOBJETCourse[0 + i].PrixInscriptionCourse;

            LabelCourse2.Content = ListeOBJETCourse[0 + i].NomCourse;
            DistanceCourse2.Content = "\n Distance : \n" + ListeOBJETCourse[0 + i].Distance;
            DateCourse2.Content = "\n Date de départ : \n" + ListeOBJETCourse[0 + i].DateDepart.Day +
            "/" + ListeOBJETCourse[0 + i].DateDepart.Month + "/" + ListeOBJETCourse[0 + i].DateDepart.Year;
            HeureCourse2.Content = "\n Heure depart : \n " + ListeOBJETCourse[0 + i].HeureDepartCourse.Hour + ":"
            + ListeOBJETCourse[0 + i].HeureDepartCourse.Minute;
            PrixCourse2.Content = "\n Prix: \n" +
            ListeOBJETCourse[0 + i].PrixInscriptionCourse;

            LabelCourse3.Content = ListeOBJETCourse[0 + i].NomCourse;
            DistanceCourse3.Content = "\n Distance : \n" + ListeOBJETCourse[0 + i].Distance;
            DateCourse3.Content = "\n Date de départ : \n" + ListeOBJETCourse[0 + i].DateDepart.Day +
            "/" + ListeOBJETCourse[0 + i].DateDepart.Month + "/" + ListeOBJETCourse[0 + i].DateDepart.Year;
            HeureCourse3.Content = "\n Heure depart : \n " + ListeOBJETCourse[0 + i].HeureDepartCourse.Hour + ":"
            + ListeOBJETCourse[0 + i].HeureDepartCourse.Minute;
            PrixCourse3.Content = "\n Prix: \n" +
            ListeOBJETCourse[0 + i].PrixInscriptionCourse;

            LabelCourse4.Content = ListeOBJETCourse[0 + i].NomCourse;
            DistanceCourse4.Content = "\n Distance : \n" + ListeOBJETCourse[0 + i].Distance;
            DateCourse4.Content = "\n Date de départ : \n" + ListeOBJETCourse[0 + i].DateDepart.Day +
            "/" + ListeOBJETCourse[0 + i].DateDepart.Month + "/" + ListeOBJETCourse[0 + i].DateDepart.Year;
            HeureCourse4.Content = "\n Heure depart : \n " + ListeOBJETCourse[0 + i].HeureDepartCourse.Hour + ":"
            + ListeOBJETCourse[0 + i].HeureDepartCourse.Minute;
            PrixCourse4.Content = "\n Prix: \n" +
            ListeOBJETCourse[0 + i].PrixInscriptionCourse;

            LabelCourse5.Content = ListeOBJETCourse[0 + i].NomCourse;
            DistanceCourse5.Content = "\n Distance : \n" + ListeOBJETCourse[0 + i].Distance;
            DateCourse5.Content = "\n Date de départ : \n" + ListeOBJETCourse[0 + i].DateDepart.Day +
            "/" + ListeOBJETCourse[0 + i].DateDepart.Month + "/" + ListeOBJETCourse[0 + i].DateDepart.Year;
            HeureCourse5.Content = "\n Heure depart : \n " + ListeOBJETCourse[0 + i].HeureDepartCourse.Hour + ":"
            + ListeOBJETCourse[0 + i].HeureDepartCourse.Minute;
            PrixCourse5.Content = "\n Prix: \n" +
            ListeOBJETCourse[0 + i].PrixInscriptionCourse;

            LabelListeCourse.Content = ListeOBJETCourse[0 + i].NomCourse;

            LabelListeCourse1.Content = ListeOBJETCourse[1 + i].NomCourse;

            LabelListeCourse2.Content = ListeOBJETCourse[2 + i].NomCourse;

            LabelListeCourse3.Content = ListeOBJETCourse[3 + i].NomCourse;

            LabelListeCourse4.Content = ListeOBJETCourse[4 + i].NomCourse;
        }
        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            var page = new inscription_coureur();
            if (radioChoisir0.IsChecked == true || radioChoisir1.IsChecked == true || radioChoisir2.IsChecked == true || radioChoisir3.IsChecked == true || radioChoisir4.IsChecked == true)
            {
                numCourse = NumeroCourseRecup();
                page.Show();
            }
                

        }

        private void radioChoisir0_Checked(object sender, RoutedEventArgs e)
        {
            radioChoisir1.IsChecked = false; 
            radioChoisir2.IsChecked = false;
            radioChoisir3.IsChecked = false;
            radioChoisir4.IsChecked = false;
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

        public bool ContientMotCleFederation(object obj)
        {
            CoureurClasse unCoureur = obj as CoureurClasse;
            if (String.IsNullOrEmpty(ComboBoxFederation.Text))
                return true;
            else
                return (unCoureur.Federation.Equals(int.Parse(ComboBoxFederation.Text)));

        }
        private void ComboBoxFederation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            DataGridCoureur.Items.Filter = ContientMotCleFederation;
            CollectionViewSource.GetDefaultView(DataGridCoureur.ItemsSource).Refresh();

        }
    }
}
