using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using WpfPedometer.Model;
using WpfPedometer.ViewModel;

namespace WpfPedometer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PersonsToDG personsToDG = new PersonsToDG();
        public MainWindow()
        {
            InitializeComponent();

            personsToDG.FillDG();
            dgUsers.ItemsSource = personsToDG.personsToDG;
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WpfPlot1.Plot.Clear();
            WpfPlot1.Plot.AddScatterLines(personsToDG.listDays[dgUsers.SelectedIndex].ToArray(), 
                personsToDG.steps[dgUsers.SelectedIndex].ToArray());
            WpfPlot1.Refresh();
        }
        
        private void CovertJSON_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                ConvertToJSON convertToJSON = new ConvertToJSON((PersonToDG)dgUsers.SelectedItem, dgUsers.SelectedIndex, personsToDG);
                convertToJSON.ToJSON();
                MessageBox.Show("JSON created","",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Select User", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void dgUsers_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            personsToDG.Paint(e);
        }
    }
}
