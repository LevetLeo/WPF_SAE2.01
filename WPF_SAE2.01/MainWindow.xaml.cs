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
        
            
            public MainWindow()
        {
            data = new ApplicationData();
            this.DataContext = data;
            InitializeComponent();
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            var page = new inscription_coureur();
            page.Show();
        }
    }
}
