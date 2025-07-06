EmployeeInfoApp
A WPF desktop application for managing employee records, built with a cyberpunk-themed user interface. The application follows the Model-View-ViewModel (MVVM) architecture and implements a Single Page Application (SPA) navigation pattern within a WPF context. It allows users to add new employee records and view a list of all employees, with data persisted in a CSV file.
Features
1. Add Employee

Users can input employee details, including:
Name
Father's Name
CNIC (in format XXXXX-XXXXXXX-X)
Designation
Date of Birth (DOB)
Gender (Male/Female)
Department (R&D, QA, Productions, Accounts, Admin)
Manager status (checkbox)


Input validation ensures all fields meet requirements (e.g., valid CNIC format, DOB not in the future, minimum name length).
Successfully added employees are saved to listOfAllEmployees.csv in the application’s output directory.
A success message is displayed, and the form resets after submission.

2. List of Employees

Displays all employee records in a DataGrid with columns for Name, Father's Name, CNIC, Designation, DOB, Gender, Department, and Manager status.
Loads data from listOfAllEmployees.csv.
Shows an informative message if the CSV file is missing or empty.
Cyberpunk-themed UI with neon colors and glow effects for a futuristic look.

Architecture
Single Page Application (SPA) Pattern

The application uses a single MainWindow with a ContentControl to host different views (HomePageView, AddNewEmployeeView, ViewAllEmployeesView).
Navigation is handled via a NavigateTo method in MainWindow.xaml.cs, simulating SPA behavior by swapping views without opening new windows.
Users can navigate between the home page, add employee form, and employee list seamlessly.

Model-View-ViewModel (MVVM) Architecture

Model: The Employee class (Models/Employee.cs) defines the data structure for employee records.
View: XAML files (Views/HomePageView.xaml, AddNewEmployeeView.xaml, ViewAllEmployeesView.xaml) define the UI with cyberpunk styling.
ViewModel: 
AddNewEmployeeViewModel.cs handles input validation, form submission, and CSV writing.
ViewAllEmployeesViewModel.cs manages loading and displaying employee data from the CSV.


Data Binding: Views bind to ViewModel properties using WPF’s data binding, with converters (GenderConverter, StringToVisibilityConverter) for dynamic UI updates.
Commands: The RelayCommand class implements ICommand for handling the submit action in AddNewEmployeeViewModel.

Prerequisites

Visual Studio 2022 (or later) with .NET desktop development workload.
.NET Framework: Compatible with .NET Core 3.1 or later (e.g., .NET 6.0-windows).
NuGet Package:
MaterialDesignThemes.Wpf (version 5.2.1 or compatible) for cyberpunk UI styling.



Installation

Clone the repository:git clone https://github.com/your-username/EmployeeInfoApp.git


Open EmployeeInfoApp.sln in Visual Studio 2022.
Restore NuGet packages:
Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
Install MaterialDesignThemes.Wpf.


Build the solution (Ctrl+Shift+B).
Run the application (F5).

Usage

Launch the App:
The app starts at the HomePageView, displaying the "Employee Information Portal" with two buttons.


Add Employee:
Click "➕ Add New Employee" to navigate to the employee form.
Fill in all fields (e.g., Name: "Ali Khan", CNIC: "12345-6789012-3", DOB: "01/01/2000").
Click "SUBMIT DATA" to save the employee to listOfAllEmployees.csv.
Click "VIEW EMPLOYEES" to see the list.


List Employees:
Click "📋 List of All Employees" from the home page or "VIEW EMPLOYEES" from the add form.
View employee records in the DataGrid.
Click "BACK" to return to the home page.


Verify Data:
Check bin\Debug\netcoreapp3.1\listOfAllEmployees.csv (or equivalent, e.g., net6.0-windows) for saved employee data.



Project Structure
EmployeeInfoApp/
├── Converters/
│   ├── GenderConverter.cs             # Converts gender char to radio button state
│   └── StringToVisibilityConverter.cs # Converts error strings to visibility
├── Models/
│   └── Employee.cs                    # Employee data model
├── ViewModels/
│   ├── AddNewEmployeeViewModel.cs     # Logic for adding employees
│   └── ViewAllEmployeesViewModel.cs   # Logic for listing employees
├── Views/
│   ├── AddNewEmployeeView.xaml        # UI for adding employees
│   ├── AddNewEmployeeView.xaml.cs
│   ├── HomePageView.xaml              # Home page UI
│   ├── HomePageView.xaml.cs
│   ├── ViewAllEmployeesView.xaml       # UI for listing employees
│   └── ViewAllEmployeesView.xaml.cs
├── MainWindow.xaml                    # Main application window
└── MainWindow.xaml.cs

Screenshots
(Add screenshots here, e.g., HomePageView, AddNewEmployeeView, ViewAllEmployeesView, to showcase the cyberpunk UI.)
Contributing

Fork the repository.
Create a feature branch (git checkout -b feature/YourFeature).
Commit changes (git commit -m "Add YourFeature").
Push to the branch (git push origin feature/YourFeature).
Open a Pull Request.

License
This project is licensed under the MIT License - see the LICENSE file for details.
Contact
For questions or feedback, contact [your-email@example.com] or open an issue on GitHub.
