using System.Windows;
using System.Windows.Controls;

namespace EmployeeInfoApp.Views
{
    /// <summary>
    /// Interaction logic for HomePageView.xaml
    /// </summary>
    public partial class HomePageView : UserControl
    {
        private MainWindow _mainWindow;

        public HomePageView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        /// <summary>
        /// Handles click event for the "Add New Employee" button, navigates to AddNewEmployeeView.
        /// </summary>
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new AddNewEmployeeView(_mainWindow));
        }

        /// <summary>
        /// Handles click event for the "List of All Employees" button, navigates to ViewAllEmployeesView.
        /// </summary>
        private void ViewEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new ViewAllEmployeesView(_mainWindow));
        }
    }
}