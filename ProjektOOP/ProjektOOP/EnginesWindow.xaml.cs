using ProjektOOP.Model;
using ProjektOOP.ObservableCollections;
using ProjektOOP.Services;
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
    /// Logika interakcji dla klasy Engines.xaml
    /// </summary>
    public partial class EnginesWindow : Window
    {
        private AddRemoveService addRemove = new AddRemoveService();
        private EditService editChassis = new EditService();

        public EnginesWindow()
        {
            InitializeComponent();
        }

        private void DeleteEngine_Click(object sender, RoutedEventArgs e)
        {
            if(EngineListView.SelectedIndex <= -1)
            {
                //ToDo Dialog
                return;
            }

            //ToDo - Dialog

            addRemove.RemoveEngine((EngineListView.SelectedItem as Engine));
            ListOfEngines.Remove((EngineListView.SelectedItem as Engine));
            EngineListView.SelectedIndex = -1;
        }
    }
}
