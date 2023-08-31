using System;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ChangeSalaryWindow : Window
    {
        Employee? currentObj;
        public ChangeSalaryWindow(Employee obj)
        {
            InitializeComponent();
            currentObj = obj;
        }
        public ChangeSalaryWindow()
        {
            InitializeComponent();
        }


        private void Confirm(object sender, RoutedEventArgs e)
        {
            if(currentObj is not null)
            {
                currentObj.ChangeSalary(Convert.ToInt32(rateBox.Text));
            }
            else
            {
                Employee.ChangeSalaryGlobal(Convert.ToInt32(rateBox.Text));
            }
            MessageBox.Show("Salary changed successfully");
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
