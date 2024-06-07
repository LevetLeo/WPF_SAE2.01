﻿using System;
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
    /// Logique d'interaction pour Coureur.xaml
    /// </summary>
    public partial class Coureur : Window
    {
       
        
        public Coureur()
        {
            
            InitializeComponent();
            ObservableCollection<CoureurClasse>  lesCoureurs = CoureurClasse.Read();
            DataGridCoureur.ItemsSource = lesCoureurs;



            
        }

        private void TBSelNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(DataGridCoureur.ItemsSource).Refresh();

        }

        private void TBSelVille_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(DataGridCoureur.ItemsSource).Refresh();

        }
    }
}
