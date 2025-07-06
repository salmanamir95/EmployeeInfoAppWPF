using EmployeeInfoApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeInfoApp.Views
{
    /// <summary>
    /// Interaction logic for ViewAllEmployeesView.xaml
    /// </summary>
    public partial class ViewAllEmployeesView : UserControl
    {
        private MainWindow _mainWindow;

        public ViewAllEmployeesView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            DataContext = new ViewAllEmployeesViewModel();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new HomePageView(_mainWindow));
        }
    }
}