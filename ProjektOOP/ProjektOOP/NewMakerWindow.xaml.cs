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
using ProjektOOP.Model;
using System.Collections.ObjectModel;
using ProjektOOP.Services;

namespace ProjektOOP
{
    /// <summary>
    /// Logika interakcji dla klasy NewMakerWindow.xaml
    /// </summary>
    public partial class NewMakerWindow : Window
    {
        AddRemoveService AddRemove = new AddRemoveService();

        public NewMakerWindow()
        {
            InitializeComponent();
        }

        private void AddNewMakerToDb(object sender, RoutedEventArgs e)
        {
            CarMakers newMaker = new CarMakers() {MakerName = NewMakerName.Text};
            AddRemove.AddMaker(newMaker);
            ListOfMakers.Add(newMaker);
            NewMakerName.Text = "";
        }
    }
}
