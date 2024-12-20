﻿using System;
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
        public bool connect = false;
        private bool TBlogin_isDefaultText = true;
        private bool Lpassword_isShown = true;

        public Window1()
        {
            InitializeComponent();
        }

        private void butConnexion_Click(object sender, RoutedEventArgs e)
        {
            string strConnexion = "Server=srv-peda-new;" +
                            "port=5433;" +
                            "Database=SAE201Marathon;" +
                            "Search Path =SchemaSAE201;" +
                            $"uid={TBLogin.Text};" +
                            $"password={TBPassword.Password};";
            try
            {
                DataAccess.Instance.ConnexionBD(strConnexion);

                var page = new Coureur();
                page.Show();
                Visibility = Visibility.Hidden;
            }
            catch (Exception ex) { MessageBox.Show("erreur"); }

             connect = true;
            
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
