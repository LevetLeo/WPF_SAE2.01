using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Logique d'interaction pour ListeCourse.xaml
    /// </summary>
    public partial class ListeCourse : Window
    {
        ObservableCollection<Course> ListeOBJETCourse;
        public int NumeroCourse()
        {
            int j = 0;
            if (butChoisir.IsChecked == true)
            {
                j = 0;
            }
            else if (radioValider1.IsChecked == true)
            {
                j = 1;
            }
            else if (radioValider2.IsChecked == true)
            {
                j = 2;
            }
            else if (radioValider3.IsChecked == true)
            {
                j = 3;
            }
            else if (radioValider4.IsChecked == true)
            {
                j = 4;
            }
            return j;
        }
        public static int numeroCourse;
        public ListeCourse()
        {
            InitializeComponent();
            int i = 0;
            numeroCourse = NumeroCourse();
            

            ListeOBJETCourse = Course.Read();
            Console.WriteLine(ListeOBJETCourse.Count);
            LabelCourse.Content = ListeOBJETCourse[0+i].NomCourse + "\n Distance \n"
            + ListeOBJETCourse[0+i].Distance + "\n DateHeure: \n" + ListeOBJETCourse[0 + i].DateDepart.Day +
            "/" + ListeOBJETCourse[0 + i].DateDepart.Month + "/" + ListeOBJETCourse[0+i].DateDepart.Year +
            "\n Heure depart: \n " + ListeOBJETCourse[0 + i].HeureDepartCourse.Hour +":"
            + ListeOBJETCourse[0 + i].HeureDepartCourse.Minute + "\n Prix: \n" +
            ListeOBJETCourse[0 + i].PrixInscriptionCourse;

            LabelCourse2.Content = ListeOBJETCourse[1 + i].NomCourse + "\n Distance \n"
            + ListeOBJETCourse[1 + i].Distance + "\n DateHeure: \n" + ListeOBJETCourse[1 + i].DateDepart.Day + "/" + ListeOBJETCourse[1 + i].DateDepart.Month + "/" + ListeOBJETCourse[1 + i].DateDepart.Year +
            "\n Heure depart: \n " + ListeOBJETCourse[1 + i].HeureDepartCourse.Hour + ":" + ListeOBJETCourse[1 + i].HeureDepartCourse.Minute + "\n Prix: \n" +
            ListeOBJETCourse[1 + i].PrixInscriptionCourse;

            LabelCourse3.Content = ListeOBJETCourse[2 + i].NomCourse + "\n Distance \n"
            + ListeOBJETCourse[2 + i].Distance + "\n DateHeure: \n" + ListeOBJETCourse[2 + i].DateDepart.Day + "/" + ListeOBJETCourse[2 + i].DateDepart.Month + "/" + ListeOBJETCourse[2 + i].DateDepart.Year +
            "\n Heure depart: \n " + ListeOBJETCourse[2 + i].HeureDepartCourse.Hour + ":" + ListeOBJETCourse[2 + i].HeureDepartCourse.Minute + "\n Prix: \n" +
            ListeOBJETCourse[2 + i].PrixInscriptionCourse;

            LabelCourse4.Content = ListeOBJETCourse[3 + i].NomCourse + "\n Distance \n"
            + ListeOBJETCourse[3 + i].Distance + "\n DateHeure: \n" + ListeOBJETCourse[3 + i].DateDepart.Day + "/" + ListeOBJETCourse[3 + i].DateDepart.Month + "/" + ListeOBJETCourse[3 + i].DateDepart.Year +
            "\n Heure depart: \n " + ListeOBJETCourse[3 + i].HeureDepartCourse.Hour + ":" + ListeOBJETCourse[3 + i].HeureDepartCourse.Minute + "\n Prix: \n" +
            ListeOBJETCourse[3 + i].PrixInscriptionCourse;

            LabelCourse5.Content = ListeOBJETCourse[4 + i].NomCourse + "\n Distance \n"
            + ListeOBJETCourse[4 + i].Distance + "\n DateHeure: \n" + ListeOBJETCourse[4 + i].DateDepart.Day + "/" + ListeOBJETCourse[4 + i].DateDepart.Month + "/" + ListeOBJETCourse[4 + i].DateDepart.Year +
            "\n Heure depart: \n " + ListeOBJETCourse[4 + i].HeureDepartCourse.Hour + ":" + ListeOBJETCourse[4 + i].HeureDepartCourse.Minute + "\n Prix: \n" +
            ListeOBJETCourse[4 + i].PrixInscriptionCourse;
        }

        private void butChoisir_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void radioValider1_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void radioValider2_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void radioValider3_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void radioValider4_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
