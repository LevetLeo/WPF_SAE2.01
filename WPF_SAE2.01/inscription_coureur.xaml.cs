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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_SAE2._01
{
    /// <summary>
    /// Logique d'interaction pour inscription_coureur.xaml
    /// </summary>
    public partial class inscription_coureur : Window
    {
        public inscription_coureur()
        {
            InitializeComponent();
        }
        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            var page = new Coureur();
            page.Show();
            this.Close();
        }
    }
}
