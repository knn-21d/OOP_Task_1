using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            empDataGrid.ItemsSource = EmployeeStorage.EmployeesList;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            bool check = Convert.ToBoolean(dateCheck.IsChecked);
            string name = nameBox.Text;
            int salary = Convert.ToInt32(salaryBox.Text);
            if (check)
            {
                DateTime date = dateInput.DisplayDate;
                new Employee(name, salary, date.Day, date.Month, date.Year);
            }
            else
            {
                new Employee(name, salary);
            }
            empDataGrid.Items.Refresh();
        }

        // далее методы контекстного меню таблицы empDataGrid
        private Employee GetEmployeFromContextClick (object sender)
        {
            var menuItem = (MenuItem)sender;
            var contextMenu = (ContextMenu)menuItem.Parent;
            var item = (DataGrid)contextMenu.PlacementTarget;
            return (Employee)item.SelectedCells[0].Item;
        }

        private void EditClick(object sender, EventArgs e)
        {
            Employee emp = GetEmployeFromContextClick(sender);
            EditWindow edit = new EditWindow(emp);
            edit.ShowDialog();
            empDataGrid.Items.Refresh();
        }

        private void ChangeSalary(object sender, EventArgs e)
        {
            Employee emp = GetEmployeFromContextClick(sender);
            ChangeSalaryWindow change = new ChangeSalaryWindow(emp);
            change.ShowDialog();
            empDataGrid.Items.Refresh();
        }

        private void ChangeSalaryGlobal(object sender, EventArgs e)
        {
            ChangeSalaryWindow change = new ChangeSalaryWindow();
            change.ShowDialog();
            empDataGrid.Items.Refresh();
        }
    }
}
