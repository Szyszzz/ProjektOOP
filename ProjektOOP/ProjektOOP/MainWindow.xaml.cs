using ProjektOOP.Context;
using ProjektOOP.Model;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using ProjektOOP.Services;
using ProjektOOP.ObservableCollections;

namespace ProjektOOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       AddRemoveService AddRemove = new AddRemoveService();

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
                ? Application.Current.Windows.OfType<T>().Any()
                : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        public void StartWindowOnTheLeft(Window win)
        {
            win.WindowStartupLocation = WindowStartupLocation.Manual;
            win.Left = this.Left + this.Width - 10;
            win.Top = this.Top;
            win.Show();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EngineButton_Click(object sender, RoutedEventArgs e)
        {
            EnginesWindow enginesWindow = new EnginesWindow();

            if (!IsWindowOpen<EnginesWindow>())
                return;
            else
            {
                enginesWindow.ParentWindow = this;
                StartWindowOnTheLeft(enginesWindow);
            }
        }

        private void ChassisButton_Click(object sender, RoutedEventArgs e)
        {
            ChassisWindow chassisWindow = new ChassisWindow();

            if (!IsWindowOpen<ChassisWindow>())
                return;
            else
            {
                chassisWindow.ParentWindow = this;
                StartWindowOnTheLeft(chassisWindow);
            }
        }

        private void MakersButton_Click(object sender, RoutedEventArgs e)
        {
            MakersWindow makersWindow = new MakersWindow();

            if (!IsWindowOpen<MakersWindow>())
                return;
            else
                StartWindowOnTheLeft(makersWindow);
        }

        public Engine BuildCurrentEngine()
        {
            Engine e = new Engine();

            if (String.IsNullOrEmpty(E_Name.Text))
                e.EngineName = "NewEngine";
            else
                e.EngineName = E_Name.Text;

            try
            {
                e.Displacement = int.Parse(E_Disp.Text);
            }
            catch(FormatException)
            {
                e.Displacement = 1492;
            }

            try
            {
                e.Cylinders = int.Parse(E_Cyli.Text);
            }
            catch (FormatException)
            {
                e.Cylinders = 4;
            }

            try
            {
                e.PeakTorque = int.Parse(E_PeakTo.Text);
            }
            catch (FormatException)
            {
                e.PeakTorque = 130;
            }

            try
            {
                e.MaxRPM = int.Parse(E_MaxRPM.Text);
            }
            catch (FormatException)
            {
                e.MaxRPM = 7200;
            }

            try
            {
                e.IdleRPM = int.Parse(E_IdleRPM.Text);
            }
            catch (FormatException)
            {
                e.IdleRPM = 700;
            }

            return e;
        }

        public Chassis BuildCurrentChassis()
        {
            Chassis c = new Chassis();

            if (String.IsNullOrEmpty(C_Name.Text))
                c.ChassisName = "NewChassis";
            else
                c.ChassisName = C_Name.Text;

            try
            {
                c.Weight = int.Parse(C_Weight.Text);
            }
            catch(FormatException)
            {
                c.Weight = 1000;
            }

            try
            {
                c.Lenght = int.Parse(C_Lenght.Text);
            }
            catch(FormatException)
            {
                c.Lenght = 3000;
            }

            try
            {
                c.Width = int.Parse(C_Width.Text);
            }
            catch (FormatException)
            {
                c.Width = 1200;
            }

            try
            {
                c.Height = int.Parse(C_Height.Text);
            }
            catch (FormatException)
            {
                c.Height = 1500;
            }

            try
            {
                c.Doors = int.Parse(C_Doors.Text);
            }
            catch (FormatException)
            {
                c.Doors = 2;
            }

            return c;
        }

        private void PreviewTextInput_Numeric(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NewChassis_Click(object sender, RoutedEventArgs e)
        {
            Chassis chassis = BuildCurrentChassis();
            AddRemove.AddChassis(chassis);
            ListOfChassis.Add(chassis);
        }

        private void NewEngine_Click(object sender, RoutedEventArgs e)
        {
            Engine engine = BuildCurrentEngine();
            AddRemove.AddEngine(engine);
            ListOfEngines.Add(engine);
        }

        public void LoadChassis(Chassis c)
        {
            C_Name.Text = c.ChassisName;
            C_Weight.Text = c.Weight.ToString();
            C_Lenght.Text = c.Lenght.ToString();
            C_Height.Text = c.Height.ToString();
            C_Width.Text = c.Width.ToString();
            C_Doors.Text = c.Doors.ToString();
        }

        public void LoadEngine(Engine e)
        {
            E_Name.Text = e.EngineName;
            E_Cyli.Text = e.Cylinders.ToString();
            E_Disp.Text = e.Displacement.ToString();
            E_IdleRPM.Text = e.IdleRPM.ToString();
            E_MaxRPM.Text = e.MaxRPM.ToString();
            E_PeakTo.Text = e.PeakTorque.ToString();
        }

    }
}
