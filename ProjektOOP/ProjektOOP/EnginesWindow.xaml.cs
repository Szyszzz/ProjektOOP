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
        public MainWindow ParentWindow;

        private AddRemoveService addRemove = new AddRemoveService();
        private EditService editEngine = new EditService();

        public EnginesWindow()
        {
            InitializeComponent();
        }

        private Engine UpdateNotEmptyProperties(Engine e)
        {
            if((EngineListView.SelectedItem as Engine) == null)
            {
                return null;
            }

            Engine valid = (EngineListView.SelectedItem as Engine);

            if (!string.IsNullOrEmpty(ParentWindow.E_Name.Text))
                valid.EngineName = e.EngineName;

            if (!string.IsNullOrEmpty(ParentWindow.E_Disp.Text))
                valid.Displacement = e.Displacement;

            if (!string.IsNullOrEmpty(ParentWindow.E_Cyli.Text))
                valid.Cylinders = e.Cylinders;

            if (!string.IsNullOrEmpty(ParentWindow.E_PeakTo.Text))
                valid.PeakTorque = e.PeakTorque;

            if (!string.IsNullOrEmpty(ParentWindow.E_MaxRPM.Text))
                valid.MaxRPM = e.MaxRPM;

            if (!string.IsNullOrEmpty(ParentWindow.E_IdleRPM.Text))
                valid.IdleRPM = e.MaxRPM;

            return valid;
        }

        private void LoadEngine_Click(object sender, RoutedEventArgs e)
        {
            if (EngineListView.SelectedIndex <= -1)
            {
                //ToDo Dialog
                return;
            }

            ParentWindow.LoadEngine((EngineListView.SelectedItem as Engine));
            ParentWindow.UpdateTargetEngine(EngineListView.SelectedItem as Engine);
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

        private void UpdateEngine_Click(object sender, RoutedEventArgs e)
        {
            if(EngineListView.SelectedIndex <= -1)
            {
                //ToDo dialog
                return;
            }

            Engine newEngine = UpdateNotEmptyProperties(ParentWindow.BuildCurrentEngine());
            ListOfEngines.Edit((EngineListView.SelectedItem as Engine), newEngine);
            editEngine.EditEngine((EngineListView.SelectedItem as Engine), newEngine);
        }
    }
}
