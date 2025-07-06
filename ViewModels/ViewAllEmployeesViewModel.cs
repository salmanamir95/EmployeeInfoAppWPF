using EmployeeInfoApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows;

namespace EmployeeInfoApp.ViewModels
{
    /// <summary>
    /// ViewModel for ViewAllEmployeesView, loads and displays employee data from listOfAllEmployees.csv.
    /// </summary>
    public class ViewAllEmployeesViewModel : INotifyPropertyChanged
    {
        // Collection of employees bound to the DataGrid
        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        // Event for property changes (MVVM requirement)
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor: Initializes the view model and loads employee data.
        /// </summary>
        public ViewAllEmployeesViewModel()
        {
            LoadEmployees();
        }

        /// <summary>
        /// Loads employee data from listOfAllEmployees.csv into the Employees collection.
        /// </summary>
        private void LoadEmployees()
        {
            Employees = new ObservableCollection<Employee>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "listOfAllEmployees.csv");

            try
            {
                // Check if the CSV file exists
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("No employee data found in listOfAllEmployees.csv.",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Read all lines from the CSV file
                var lines = File.ReadAllLines(filePath);
                if (lines.Length <= 1) // Only header or empty
                {
                    MessageBox.Show("The employee data file is empty.",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Parse each line (skip header)
                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Split the line by commas, expecting 8 columns
                    var parts = line.Split(',');
                    if (parts.Length >= 8)
                    {
                        try
                        {
                            // Try parsing DOB, allow null if invalid
                            DateTime? dob = null;
                            if (DateTime.TryParseExact(parts[4].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            {
                                dob = parsedDate;
                            }

                            Employees.Add(new Employee
                            {
                                Name = parts[0].Trim(), // No quotes, as per AddNewEmployeeViewModel
                                FatherName = parts[1].Trim(),
                                cnic = parts[2].Trim(),
                                Designation = parts[3].Trim(),
                                DOB = dob,
                                Gender = parts[5].Trim().Length > 0 ? parts[5].Trim()[0] : ' ',
                                Department = parts[6].Trim(),
                                Manager = bool.Parse(parts[7].Trim())
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error parsing row {i + 1}: {line}\nDetails: {ex.Message}",
                                "Parsing Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Invalid row format at line {i + 1}: {line}",
                            "Parsing Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee data: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event for MVVM binding.
        /// </summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}