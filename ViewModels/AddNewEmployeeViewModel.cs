using EmployeeInfoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows;

namespace EmployeeInfoApp.ViewModels
{
    public class AddNewEmployeeViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _fatherName;
        private string _cnic;
        private string _designation;
        private DateTime? _dob;
        private char _gender = ' ';
        private string _department;
        private bool _isManager;
        private List<string> _departments = new List<string>
        {
            "R&D", "QA", "Productions", "Accounts", "Admin"
        };

        public event PropertyChangedEventHandler PropertyChanged;

        // Properties with validation
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                ValidateName();
            }
        }

        public string FatherName
        {
            get => _fatherName;
            set
            {
                _fatherName = value;
                OnPropertyChanged(nameof(FatherName));
                ValidateFatherName();
            }
        }

        public string CNIC
        {
            get => _cnic;
            set
            {
                _cnic = value;
                OnPropertyChanged(nameof(CNIC));
                ValidateCNIC();
            }
        }

        public string Designation
        {
            get => _designation;
            set
            {
                _designation = value;
                OnPropertyChanged(nameof(Designation));
                ValidateDesignation();
            }
        }

        public DateTime? DOB
        {
            get => _dob;
            set
            {
                _dob = value;
                OnPropertyChanged(nameof(DOB));
                ValidateDOB();
            }
        }

        public char Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
                ValidateGender();
            }
        }

        public string Department
        {
            get => _department;
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
                ValidateDepartment();
            }
        }

        public bool IsManager
        {
            get => _isManager;
            set
            {
                _isManager = value;
                OnPropertyChanged(nameof(IsManager));
            }
        }

        public List<string> Departments => _departments;

        // Validation properties
        public string NameError { get; private set; }
        public string FatherNameError { get; private set; }
        public string CNICError { get; private set; }
        public string DesignationError { get; private set; }
        public string DOBError { get; private set; }
        public string GenderError { get; private set; }
        public string DepartmentError { get; private set; }

        public bool HasErrors =>
            !string.IsNullOrEmpty(NameError) ||
            !string.IsNullOrEmpty(FatherNameError) ||
            !string.IsNullOrEmpty(CNICError) ||
            !string.IsNullOrEmpty(DesignationError) ||
            !string.IsNullOrEmpty(DOBError) ||
            !string.IsNullOrEmpty(GenderError) ||
            !string.IsNullOrEmpty(DepartmentError);

        // Commands
        public ICommand SubmitCommand { get; }

        public AddNewEmployeeViewModel()
        {
            SubmitCommand = new RelayCommand(SubmitEmployee, CanSubmit);
        }

        private bool CanSubmit(object parameter) => !HasErrors;

        private void SubmitEmployee(object parameter)
        {
            if (HasErrors) return;

            var employee = new Employee
            {
                Name = Name,
                FatherName = FatherName,
                cnic = CNIC,
                Designation = Designation,
                DOB = DOB.Value,
                Gender = Gender,
                Department = Department,
                Manager = IsManager
            };

            SaveEmployeeToCsv(employee);
            MessageBox.Show("Employee added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            ResetForm();
        }

        private void SaveEmployeeToCsv(Employee employee)
        {
            string filePath = "listOfAllEmployees.csv";
            string header = "Name,FatherName,CNIC,Designation,DOB,Gender,Department,Manager";
            string data = $"{employee.Name},{employee.FatherName},{employee.cnic}," +
                          $"{employee.Designation},{employee.DOB:dd/MM/yyyy},{employee.Gender}," +
                          $"{employee.Department},{employee.Manager}";

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, header + Environment.NewLine);
            }

            File.AppendAllText(filePath, data + Environment.NewLine);
        }

        private void ResetForm()
        {
            Name = string.Empty;
            FatherName = string.Empty;
            CNIC = string.Empty;
            Designation = string.Empty;
            DOB = null;
            Gender = ' ';
            Department = string.Empty;
            IsManager = false;
        }

        // Validation methods
        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
                NameError = "Name is required";
            else if (Name.Length < 3)
                NameError = "Name must be at least 3 characters";
            else
                NameError = null;

            OnPropertyChanged(nameof(NameError));
        }

        private void ValidateFatherName()
        {
            if (string.IsNullOrWhiteSpace(FatherName))
                FatherNameError = "Father's name is required";
            else if (FatherName.Length < 3)
                FatherNameError = "Father's name must be at least 3 characters";
            else
                FatherNameError = null;

            OnPropertyChanged(nameof(FatherNameError));
        }

        private void ValidateCNIC()
        {
            if (string.IsNullOrWhiteSpace(CNIC))
                CNICError = "CNIC is required";
            else if (!System.Text.RegularExpressions.Regex.IsMatch(CNIC, @"^\d{5}-\d{7}-\d{1}$"))
                CNICError = "Invalid CNIC format (XXXXX-XXXXXXX-X)";
            else
                CNICError = null;

            OnPropertyChanged(nameof(CNICError));
        }

        private void ValidateDesignation()
        {
            if (string.IsNullOrWhiteSpace(Designation))
                DesignationError = "Designation is required";
            else
                DesignationError = null;

            OnPropertyChanged(nameof(DesignationError));
        }

        private void ValidateDOB()
        {
            if (DOB == null)
                DOBError = "Date of birth is required";
            else if (DOB > DateTime.Now)
                DOBError = "Date cannot be in the future";
            else if (DateTime.Now.Year - DOB.Value.Year < 18)
                DOBError = "Employee must be at least 18 years old";
            else
                DOBError = null;

            OnPropertyChanged(nameof(DOBError));
        }

        private void ValidateGender()
        {
            if (Gender != 'M' && Gender != 'F')
                GenderError = "Please select a gender";
            else
                GenderError = null;

            OnPropertyChanged(nameof(GenderError));
        }

        private void ValidateDepartment()
        {
            if (string.IsNullOrWhiteSpace(Department))
                DepartmentError = "Department is required";
            else if (!Departments.Contains(Department))
                DepartmentError = "Invalid department selection";
            else
                DepartmentError = null;

            OnPropertyChanged(nameof(DepartmentError));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}