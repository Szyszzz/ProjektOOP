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
using ProjektOOP.Services;
using ProjektOOP.ObservableCollections;

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
        AddRemoveService AddRemove = new AddRemoveService();
        EditService EditTables = new EditService();

        public MakersWindow()
        {
            InitializeComponent();
        }

        private void NewMaker_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MakersWindowInput.Text))
            {
                CarMakers newMaker = new CarMakers() { MakerName = MakersWindowInput.Text };
                AddRemove.AddMaker(newMaker);
                ListOfMakers.Add(newMaker);
                MakersWindowInput.Text = "";
            }
            else
            {
                MessageBox.Show("Maker name can't be empty. Please try again with proper name.", "Wrong Name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void DeleteMaker_Click(object sender, RoutedEventArgs e)
        {
            if (MakersListView.SelectedIndex <= -1)
            {
                MessageBox.Show("None of the makers was selected. Please select a maker first before trying to delete it.", "Maker Not Selected", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string removalText = "Are you sure you want to remove: " 
                + (MakersListView.SelectedItem as CarMakers).MakerName +
                " ID: "+ (MakersListView.SelectedItem as CarMakers).Id + Environment.NewLine +
                "Removal of this car maker will also delete all the car Models, Engines and Chassis made by this maker!";

            if(MessageBox.Show(removalText, "Removal Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                AddRemove.RemoveMaker(MakersListView.SelectedItem as CarMakers);
                ListOfMakers.Remove(MakersListView.SelectedItem as CarMakers);
                MakersListView.SelectedIndex = -1;
            }
        }

        private void EditMaker_Click(object sender, RoutedEventArgs e)
        {
            if (MakersListView.SelectedIndex <= -1)
            {
                MessageBox.Show("None of the makers was selected. Please select a maker first before trying to edit it.", "Maker Not Selected", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!string.IsNullOrEmpty(MakersWindowInput.Text))
            {
                EditTables.EditMakers((MakersListView.SelectedItem as CarMakers), MakersWindowInput.Text);
                ListOfMakers.Edit((MakersListView.SelectedItem as CarMakers), MakersWindowInput.Text);
                MakersWindowInput.Text = "";
            }
            else
            {
                MessageBox.Show("Maker name can't be empty. Please try again with proper name.", "Wrong Name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void MakersListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((MakersListView.SelectedItem as CarMakers) != null)
                MakersWindowInput.Text = (MakersListView.SelectedItem as CarMakers).MakerName;
            else
                MakersWindowInput.Text = "";
        }
    }
}
