using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using MySql.Data.MySqlClient;
using System.Windows.Input;

namespace Payroll_Appplication
{
    /// <summary>
    /// Interaction logic for EmployeeEdit.xaml
    /// </summary>
    public partial class EmployeeEdit : Window, INotifyPropertyChanged
    {
        private bool _isRetracted;
        public bool IsRetracted
        {
            get { return _isRetracted; }
            set
            {
                _isRetracted = value;
                OnPropertyChanged();
            }
        }

        public int clickCount = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand OpenLoginCommand { get; }
        public ICommand OpenEmployeesCommand { get; }
        public ICommand OpenEditCommand { get; }
        public ICommand OpenRegisterCommand { get; }
        public ICommand OpenStatisticsCommand { get; }
        public ICommand OpenProfileCommand { get; }
        public ICommand OpenDashboardCommand { get; }
        public ICommand OpenPayrollHandlingCommand { get; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string connectionString = App.ConnectionString;

        public EmployeeEdit()
        {
            InitializeComponent();
            DataContext = this;
            OpenLoginCommand = new RelayCommand(OpenLoginWindow);
            OpenEmployeesCommand = new RelayCommand(OpenEmployeesWindow);
            OpenEditCommand = new RelayCommand(OpenEmployeeEditWindow);
            OpenRegisterCommand = new RelayCommand(OpenRegisterEditWindow);
            OpenStatisticsCommand = new RelayCommand(OpenStatisticsWindow);
            OpenProfileCommand = new RelayCommand(OpenProfileWindow);
            OpenDashboardCommand = new RelayCommand(OpenDashboardWindow);
            OpenPayrollHandlingCommand = new RelayCommand(OpenPayrollHandlingWindow);

            PopulateEmployeeNumbers();
        }

        private void RetractButton_Click(object sender, RoutedEventArgs e)
        {
            clickCount++;

            if (clickCount % 2 == 0)
            {
                var retractStoryboard = (Storyboard)FindResource("RetractNavigationStoryboard");
                retractStoryboard.Begin();
            }
            else
            {
                var restoreStoryboard = (Storyboard)FindResource("RestoreNavigationStoryboard");
                restoreStoryboard.Begin();
            }

        }

        private void OpenLoginWindow()
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Hide();
        }

        private void OpenEmployeesWindow()
        {
            Employees employeeWindow = new Employees();
            employeeWindow.Show();
            this.Hide();
        }

        private void OpenEmployeeEditWindow()
        {
            
        }

        private void OpenDashboardWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void OpenPayrollHandlingWindow()
        {
            PayrollHandling payrollWindow = new PayrollHandling();
            payrollWindow.Show();
            this.Hide();
        }

        private void OpenStatisticsWindow()
        {
            Statistics statisticsWindow = new Statistics();
            statisticsWindow.Show();
            this.Hide();
        }

        private void OpenRegisterEditWindow()
        {
            RegisterPage registerWindow = new RegisterPage();
            registerWindow.Show();
            this.Hide();
        }

        private void OpenProfileWindow()
        {
            Profile profileWindow = new Profile();
            profileWindow.Show();
            this.Hide();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Verify that all required fields are filled
            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtMaritalStatus.Text) || string.IsNullOrWhiteSpace(txtHourly.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Add the employee to the database
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Employees (EmployeeName, PhoneNumber, EmailAddress, MaritalStatus, HourlyRate) VALUES (@EmployeeName, @PhoneNumber, @EmailAddress, @MaritalStatus, @HourlyRate)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    command.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                    command.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                    command.Parameters.AddWithValue("@HourlyRate", Convert.ToDouble(txtHourly.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee added successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Verify that the employee number is provided
            if (string.IsNullOrWhiteSpace(cmbEmployeeNumberDel.Text))
            {
                MessageBox.Show("Please provide the Employee Number.");
                return;
            }

            // Delete the employee from the database
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Employees WHERE EmployeeNo = @EmployeeNo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeNo", Convert.ToInt32(cmbEmployeeNumberDel.Text));
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Verify that all required fields are filled
            if (string.IsNullOrWhiteSpace(cmbEmployeeNum.Text) || string.IsNullOrWhiteSpace(txtEmployeeName1.Text) || string.IsNullOrWhiteSpace(txtPhone1.Text) || string.IsNullOrWhiteSpace(txtEmail1.Text) || string.IsNullOrWhiteSpace(txtMaritalStatus1.Text) || string.IsNullOrWhiteSpace(txtHourlyEdit.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Edit the employee in the database
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Employees SET EmployeeName = @EmployeeName, PhoneNumber = @PhoneNumber, EmailAddress = @EmailAddress, MaritalStatus = @MaritalStatus, HourlyRate = @HourlyRate WHERE EmployeeNo = @EmployeeNo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeNo", Convert.ToInt32(cmbEmployeeNum.Text));
                    command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName1.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", txtPhone1.Text);
                    command.Parameters.AddWithValue("@EmailAddress", txtEmail1.Text);
                    command.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus1.Text);
                    command.Parameters.AddWithValue("@HourlyRate", Convert.ToDouble(txtHourlyEdit.Text));
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        

        private void PopulateEmployeeNumbers()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT EmployeeNo FROM Employees";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    cmbEmployeeNumberDel.Items.Clear();
                    cmbEmployeeNum.Items.Clear();

                    // Add employee numbers to ComboBoxes
                    while (reader.Read())
                    {
                        cmbEmployeeNumberDel.Items.Add(reader["EmployeeNo"].ToString());
                        cmbEmployeeNum.Items.Add(reader["EmployeeNo"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void cmbEmployeeNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEmployeeNum.SelectedItem != null)
            {
                // Fetch and display employee data based on selected employee number
                FetchAndDisplayEmployeeData(Convert.ToInt32(cmbEmployeeNum.SelectedItem));
            }
        }

        private void cmbEmployeeNumberDel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void FetchAndDisplayEmployeeData(int employeeNumber)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Employees WHERE EmployeeNo = @EmployeeNo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeNo", employeeNumber);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtEmployeeName1.Text = reader["EmployeeName"].ToString();
                        txtPhone1.Text = reader["PhoneNumber"].ToString();
                        txtEmail1.Text = reader["EmailAddress"].ToString();
                        txtMaritalStatus1.Text = reader["MaritalStatus"].ToString();
                        txtHourlyEdit.Text = reader["HourlyRate"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }





    }
}
