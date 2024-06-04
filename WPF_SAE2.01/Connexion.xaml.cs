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
using System.Windows.Input.Manipulations;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_SAE2._01
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private bool TBlogin_isDefaultText = true;
        private bool Lpassword_isShown = true;

        public Window1()
        {
            InitializeComponent();
        }

        private void butConnexion_Click(object sender, RoutedEventArgs e)
        {
            data.ConnexionBD();
            //data.TestDatabaseConnection();
            int i = 0;
            int j = 0;
            /*List<string> login = Agent.ReadLogin();
            List<string> mdp = Agent.ReadMdp();
            string unLogin = login[i];
            string unMdp = mdp[j];
            do
            {
                unLogin = login[i];
                i++;
                

            } while (unLogin != TBLogin.Text.ToString() || i > login.Count);

            do
            {
                unMdp = mdp[j];
                j++;


            } while (unMdp != TBPassword.Password.ToString() || j > mdp.Count);

            if(j > mdp.Count || i > login.Count)
            {
                Console.WriteLine("erreur identifiant ou mot de passe");
            }
            
                
            else if(j == i)
            {
                  
                 if (TBPassword.Password.ToString() == unMdp && TBLogin.Text.ToString() == unLogin)
                 {*/
                    var page = new Menu();
                    page.Show();
                    this.Close();/*
                 }

            }*/
                
            
        }
        public void Fermer()
        {
            //data.DeconnexionBD();
            this.Close();
        }
        private void TBlogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBlogin_isDefaultText)
            {
                TBLogin.Text = string.Empty;
                TBLogin.Foreground = new SolidColorBrush(Colors.Black);
                TBlogin_isDefaultText = false;
                TBLogin.FontWeight = FontWeights.Thin;
            }
        }

        private void TBlogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBLogin.Text))
            {
                TBLogin.Text = "login";
                TBLogin.Foreground = new SolidColorBrush(Colors.Black);
                TBLogin.Foreground.Opacity = 0.5;
                TBlogin_isDefaultText = true;
            }
        }

        private void TBpassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Lpassword_isShown)
            {
                Lpassword.Opacity = 0;
                Lpassword_isShown = false;
            }
        }

        private void TBpassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBPassword.Password))
            {
                Lpassword.Opacity = 1;
                Lpassword_isShown = true;
            }
        }

        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            Fermer();
        }
    }
}
