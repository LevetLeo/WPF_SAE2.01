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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var page = new Coureur();
            page.Show();
            this.Close();
        }

        private void butCourse_Click(object sender, RoutedEventArgs e)
        {
            var page = new ListeCourse();
            page.Show();
            this.Close();
        }

        private void butInscritCourse_Click(object sender, RoutedEventArgs e)
        {
            var page = new MainWindow();
            page.Show();
            this.Close();
        }

        private void butmenu_Click(object sender, RoutedEventArgs e)
        {
            if (butmenu.Content == ">>")
            {
            colone.Width = new System.Windows.GridLength(200);
            assobrir.Opacity = 10;
            butmenu.Content = "<<";
            }
            else
            {
                colone.Width = new System.Windows.GridLength(0);
                assobrir.Opacity = 0;
                butmenu.Content = ">>";
            }
        }
    }
}
