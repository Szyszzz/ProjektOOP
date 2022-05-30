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
    /// Logika interakcji dla klasy Chassis.xaml
    /// </summary>
    public partial class ChassisWindow : Window
    {
        public MainWindow ParentWindow;

        private AddRemoveService addRemove = new AddRemoveService();
        private EditService editChassis = new EditService();

        public ChassisWindow()
        {
            InitializeComponent();
        }

        private void LoadChassis_Click(object sender, RoutedEventArgs e)
        {
            if(ChassisListView.SelectedIndex <= -1)
            {
                //ToDo - dialog
                return;
            }

            ParentWindow.LoadChassis((ChassisListView.SelectedItem as Chassis));
        }

        private Chassis UpdateNotEmptyProperties(Chassis c)
        {
            if ((ChassisListView.SelectedItem as Chassis) == null)
                return null;

            Chassis valid = (ChassisListView.SelectedItem as Chassis);
                
            if (!string.IsNullOrEmpty(ParentWindow.C_Name.Text))
            {
                valid.ChassisName = c.ChassisName;
            }
            if (!string.IsNullOrEmpty(ParentWindow.C_Weight.Text))
            {
                valid.Weight = c.Weight;
            }
            if (!string.IsNullOrEmpty(ParentWindow.C_Width.Text))
            {
                valid.Width = c.Width;
            }
            if (!string.IsNullOrEmpty(ParentWindow.C_Lenght.Text))
            {
                valid.Lenght = c.Lenght;
            }
            if (!string.IsNullOrEmpty(ParentWindow.C_Height.Text))
            {
                valid.Height = c.Height;
            }
            if (!string.IsNullOrEmpty(ParentWindow.C_Doors.Text))
            {
                valid.Doors = c.Doors;
            }

            return valid;
        }

        private void UpdateChassis_Click(object sender, RoutedEventArgs e)
        {
            if(ChassisListView.SelectedIndex <= -1)
            {
                //ToDo - dialog
                return;
            }

            Chassis newChassis = UpdateNotEmptyProperties(ParentWindow.BuildCurrentChassis());
            ListOfChassis.Edit((ChassisListView.SelectedItem as Chassis), newChassis);
            editChassis.EditChassis((ChassisListView.SelectedItem as Chassis), newChassis);

        }

        private void DeleteChassis_Click(object sender, RoutedEventArgs e)
        {
            if(ChassisListView.SelectedIndex <=-1)
            {
                //ToDo - dialog
                return;
            }

            //ToDo - dialog
            addRemove.RemoveChassis((ChassisListView.SelectedItem as Chassis));
            ListOfChassis.Remove((ChassisListView.SelectedItem as Chassis));
            ChassisListView.SelectedIndex = -1;
        }
    }
}
