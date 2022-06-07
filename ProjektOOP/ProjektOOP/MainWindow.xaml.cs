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
        EditService editService = new EditService();

        private CarMakers TargetMaker = null;
        private Engine TargetEngine = null;
        private Chassis TargetChassis = null;
        
        public void UpdateTargetMaker(CarMakers m)
        {
            if (ReferenceEquals(m, null))
                return;

            M_Maker.Text = m.MakerName;
            TargetMaker = m;
        }

        public void UpdateTargetEngine(Engine e)
        {
            if (ReferenceEquals(e, null))
                return;

            M_Engine.Text = e.EngineName;
            TargetEngine = e;
        }

        public void UpdateTargetChassis(Chassis c)
        {
            if (ReferenceEquals(c, null))
                return;

            M_Chassis.Text = c.ChassisName;
            TargetChassis = c;
        }

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
            {
                makersWindow.ParentWindow = this;
                StartWindowOnTheLeft(makersWindow);
            }
        }

        public CarModels UpdateNotEmptyModel(CarModels m)
        {
            if((ModelsListView.SelectedItem as CarModels) == null)
            {
                //ToDo - Dialog
                return null;
            }

            CarModels valid = (ModelsListView.SelectedItem as CarModels);

            if (!string.IsNullOrEmpty(M_Name.Text))
                valid.ModelName = m.ModelName;

            if (!string.IsNullOrEmpty(M_Country.Text))
                valid.Country = m.Country;

            if (!string.IsNullOrEmpty(M_Year.Text))
                valid.ProductionYear = m.ProductionYear;

            if (!string.IsNullOrEmpty(M_Price.Text))
                valid.Price = m.Price;

            if (!string.IsNullOrEmpty(M_Class.Text))
                valid.CarClass = m.CarClass;

            if (!string.IsNullOrEmpty(M_Maker.Text))
            {
                valid.Maker = m.Maker;
                valid.MakerId = m.MakerId;
            }

            if(!string.IsNullOrEmpty(M_Engine.Text))
            {
                valid.Engine = m.Engine;
                valid.EngineId = m.EngineId;
            }

            if(!string.IsNullOrEmpty(M_Chassis.Text))
            {
                valid.Chassis = m.Chassis;
                valid.ChassisId = m.ChassisId;
            }

            return valid;
        }

        public CarModels BuildCurrentCarModel()
        {
            CarModels m = new CarModels();

            if (String.IsNullOrEmpty(M_Name.Text))
                m.ModelName = "NewModel";
            else
                m.ModelName = M_Name.Text;

            if (String.IsNullOrEmpty(M_Name.Text))
                m.Country = "";
            else
                m.Country = M_Country.Text;

            try
            {
                m.ProductionYear = int.Parse(M_Year.Text);
            }
            catch (FormatException)
            {
                m.ProductionYear = 1998;
            }

            try
            {
                m.Price = decimal.Parse(M_Price.Text);
            }
            catch (FormatException)
            {
                m.Price = 3000.00M;
            }

            if (string.IsNullOrEmpty(M_Class.Text))
                m.CarClass = "Hatchback";
            else
                m.CarClass = M_Class.Text;

            if (TargetMaker != null)
            {
                m.Maker = TargetMaker;
                m.MakerId = TargetMaker.Id;
            }


            if (TargetEngine != null) 
            { 
            m.Engine = TargetEngine;
            m.EngineId = TargetEngine.Id;
            }

            if (TargetChassis != null)
            {
                m.Chassis = TargetChassis;
                m.ChassisId = TargetChassis.Id;
            }

            return m;
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

        public void LoadModel(CarModels m)
        {
            M_Name.Text = m.ModelName;
            M_Country.Text = m.Country;
            M_Price.Text = m.Price.ToString();
            M_Year.Text = m.ProductionYear.ToString();
            M_Class.Text = m.CarClass.ToString();

            UpdateTargetChassis(m.Chassis);
            UpdateTargetEngine(m.Engine);
            UpdateTargetMaker(m.Maker);
        }

        private void LoadModel_Click(object sender, RoutedEventArgs e)
        {
            if (ModelsListView.SelectedIndex <= -1)
            {
                //ToDo - Dialog
                return;
            }

            LoadModel((ModelsListView.SelectedItem as CarModels));
        }

        private void UpdateModel_Click(object sender, RoutedEventArgs e)
        {
            if(ModelsListView.SelectedIndex <= -1)
            {
                //ToDo - Dialog
                return;
            }

            CarModels newModel = UpdateNotEmptyModel(BuildCurrentCarModel());
            ListOfModels.Edit((ModelsListView.SelectedItem as CarModels), newModel);
            editService.EditModel((ModelsListView.SelectedItem as CarModels), newModel);
        }

        private void NewModel_Click(object sender, RoutedEventArgs e)
        {
            CarModels model = BuildCurrentCarModel();
            AddRemove.AddModel(model);
            ListOfModels.Add(model);
        }

        private void RemoveModel_Click(object sender, RoutedEventArgs e)
        {
            if (ModelsListView.SelectedIndex <= -1)
            {
                //ToDo - Dialog
                return;
            }

            AddRemove.RemoveModel((ModelsListView.SelectedItem as CarModels));
            ListOfModels.Remove((ModelsListView.SelectedItem as CarModels));
            ModelsListView.SelectedIndex = -1;
        }
    }
}
