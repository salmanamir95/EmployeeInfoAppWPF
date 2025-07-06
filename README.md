EmployeeInfoApp
A WPF desktop app for managing employee records with a cyberpunk-themed UI, using MVVM architecture and SPA navigation. It supports two main features: adding new employees and listing all employees, with data stored in a CSV file.
Features
Add Employee

Enter employee details: Name, Father's Name, CNIC (XXXXX-XXXXXXX-X), Designation, DOB (18+ years ago), Gender (M/F), Department (R&D, QA, Productions, Accounts, Admin), Manager status.
Real-time validation checks field requirements.
Saves data to listOfAllEmployees.csv in the output directory.
Shows a success message and resets the form after submission.

List of Employees

Displays employee records in a DataGrid (Name, Father's Name, CNIC, Designation, DOB, Gender, Department, Manager).
Loads data from listOfAllEmployees.csv.
Shows a message if the CSV is missing or empty.
Uses neon colors (green, pink, blue) and glow effects for a futuristic look.

Architecture
SPA Pattern

Uses a single MainWindow with a ContentControl to switch between views (HomePageView, AddNewEmployeeView, ViewAllEmployeesView).
Navigation via NavigateTo method ensures a seamless SPA-like experience in WPF.

MVVM Architecture

Model: Employee.cs defines the employee data structure.
View: XAML files (HomePageView.xaml, AddNewEmployeeView.xaml, ViewAllEmployeesView.xaml) provide the UI.
ViewModel:
AddNewEmployeeViewModel.cs: Handles form input, validation, and CSV saving.
ViewAllEmployeesViewModel.cs: Loads and displays CSV data.


Uses data binding, converters (GenderConverter, StringToVisibilityConverter), and RelayCommand for form submission.

Setup

Clone the repository:git clone https://github.com/your-username/EmployeeInfoApp.git


Open EmployeeInfoApp.sln in Visual Studio 2022.
Install MaterialDesignThemes.Wpf NuGet package:
Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
Search for MaterialDesignThemes, install version 5.2.1 or compatible.


Build (Ctrl+Shift+B) and run (F5).

Usage

Home Page: Opens with "Employee Information Portal" and two buttons.
Add Employee:
Click "➕ Add New Employee".
Fill fields (e.g., Name: "Ali Khan", CNIC: "12345-6789012-3", DOB: "01/01/2000").
Click "SUBMIT DATA" to save to CSV.
Click "VIEW EMPLOYEES" to see the list.


List Employees:
Click "📋 List of All Employees" or "VIEW EMPLOYEES".
View records in the DataGrid.
Click "BACK" to return to the home page.


Verify CSV: Check bin\Debug\netcoreapp3.1\listOfAllEmployees.csv (or net6.0-windows) for saved data.

Project Structure
EmployeeInfoApp/
├── Converters/
│   ├── GenderConverter.cs
│   └── StringToVisibilityConverter.cs
├── Models/
│   └── Employee.cs
├── ViewModels/
│   ├── AddNewEmployeeViewModel.cs
│   └── ViewAllEmployeesViewModel.cs
├── Views/
│   ├── AddNewEmployeeView.xaml
│   ├── AddNewEmployeeView.xaml.cs
│   ├── HomePageView.xaml
│   ├── HomePageView.xaml.cs
│   ├── ViewAllEmployeesView.xaml
│   └── ViewAllEmployeesView.xaml.cs
├── MainWindow.xaml
└── MainWindow.xaml.cs

Screenshots
(Add screenshots of Home Page, Add Employee form, and Employee List here.)
