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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektOOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
                ? Application.Current.Windows.OfType<T>().Any()
                : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void engineButton_Click(object sender, RoutedEventArgs e)
        {
            Engines enginesWindow = new Engines();

            if (!IsWindowOpen<Engines>())
                return;
            else
            {
                enginesWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                enginesWindow.Left = this.Left + this.Width - 10;
                enginesWindow.Top = this.Top;
                enginesWindow.Show();
            }
        }
    }
}
