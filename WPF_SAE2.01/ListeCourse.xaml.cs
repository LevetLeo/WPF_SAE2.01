using System;
using System.Collections.Generic;
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
        public ListeCourse()
        {
            InitializeComponent();
            Console.WriteLine(Course.Read());
            int i = 0;
            string unNom;
            List<string> LesNoms = Course.ReadNom();

            do
            {
                Console.WriteLine(LesNoms[0]);
                unNom = LesNoms[i];
                i++;
                Console.WriteLine(unNom);

            } while (i > LesNoms.Count);

            LabelNom1.Content = unNom;

        }
    }
}
