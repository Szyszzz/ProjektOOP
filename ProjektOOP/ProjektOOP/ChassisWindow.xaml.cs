﻿using ProjektOOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektOOP
{
    /// <summary>
    /// Logika interakcji dla klasy Chassis.xaml
    /// </summary>
    public partial class ChassisWindow : Window
    {
        public MainWindow ParentWindow;

        public ChassisWindow()
        {
            InitializeComponent();
        }

        private void LoadChassis_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.LoadChassis((ChassisListView.SelectedItem as Chassis));
        }
    }
}
