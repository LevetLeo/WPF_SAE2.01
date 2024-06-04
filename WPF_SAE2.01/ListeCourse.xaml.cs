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
            List<string> LesNoms = Course.ReadNom();

           foreach(string unNom in LesNoms)
           {
                Console.WriteLine(unNom);
            }
        }
    }
}
