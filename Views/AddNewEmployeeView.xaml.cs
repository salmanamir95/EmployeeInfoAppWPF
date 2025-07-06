using EmployeeInfoApp.ViewModels;
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

namespace EmployeeInfoApp.Views
{
    /// <summary>
    /// Interaction logic for AddNewEmployeeView.xaml
    /// </summary>
    public partial class AddNewEmployeeView : UserControl
    {
        private MainWindow _mainWindow;

        public AddNewEmployeeView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            DataContext = new AddNewEmployeeViewModel();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new HomePageView(_mainWindow));
        }

        private void ViewEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new ViewAllEmployeesView(_mainWindow));
        }
    }
}
