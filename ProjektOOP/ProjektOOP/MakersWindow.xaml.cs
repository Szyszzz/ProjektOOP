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
using ProjektOOP.Context;
using ProjektOOP.Model;
using System.Collections;
using System.Collections.ObjectModel;

namespace ProjektOOP
{
    // first() 
    // remove()
    // update()
    // add()

    /// <summary>
    /// Logika interakcji dla klasy Makers.xaml
    /// </summary>

    public partial class MakersWindow : Window
    {
        public MakersWindow()
        {
            InitializeComponent();
        }

        public void StartWindowOnTheLeft(Window win)
        {
            win.WindowStartupLocation = WindowStartupLocation.Manual;
            win.Left = this.Left + this.Width - 10;
            win.Top = this.Top + this.Height - win.Height;
            win.Show();
        }

        private void NewMaker_Click(object sender, RoutedEventArgs e)
        {
            NewMakerWindow newMaker = new NewMakerWindow();
            StartWindowOnTheLeft(newMaker);
        }
    }

    public class ListOfMakers
    {
        public static ObservableCollection<CarMakers> MakersList { get; set; } = GetMakers();

        public static ObservableCollection<CarMakers> GetMakers()
        {
            ProjektContext context = new ContextFactory().CreateDbContext();
            return new ObservableCollection<CarMakers>(context.CarMakers);
        }

        public static void Add(CarMakers maker)
        {
            MakersList.Add(maker);
        }
    }
}
