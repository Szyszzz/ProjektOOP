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
using ProjektOOP.Context;
using System.Collections.ObjectModel;

namespace ProjektOOP
{
    /// <summary>
    /// Logika interakcji dla klasy NewMakerWindow.xaml
    /// </summary>
    public partial class NewMakerWindow : Window
    {
        private readonly ProjektContext context;

        public NewMakerWindow()
        {
            context = new ContextFactory().CreateDbContext();
            InitializeComponent();
        }

        private void AddNewMakerToDb(object sender, RoutedEventArgs e)
        {
            CarMakers newMaker = new CarMakers() {MakerName = NewMakerName.Text};
            context.CarMakers.Add(newMaker);
            NewMakerName.Text = "";
            context.SaveChanges();
        }
    }
}
