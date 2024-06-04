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
    /// Logique d'interaction pour ListeCourse.xaml
    /// </summary>
    public partial class ListeCourse : Window
    {
        ObservableCollection<Course> ListeOBJETCourse;
        public ListeCourse()
        {
            InitializeComponent();
            int i = 0;
            ListeOBJETCourse = Course.Read();
            Console.WriteLine(ListeOBJETCourse.Count);
            LabelCourse.Content = ListeOBJETCourse[0+i].NomCourse + "\n Distance \n"
            + ListeOBJETCourse[0+i].Distance + "\n DateHeure: \n" + ListeOBJETCourse[0 + i].DateDepart.Day + "/" + ListeOBJETCourse[0 + i].DateDepart.Month + "/" + ListeOBJETCourse[0+i].DateDepart.Year +
            "\n Heure depart: \n " + ListeOBJETCourse[0 + i].HeureDepartCourse.Hour +":"+ ListeOBJETCourse[0 + i].HeureDepartCourse.Minute + "\n Prix: \n" +
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
    }
}
