using System.Collections.Generic;

namespace WpfApp1
{
    internal static class EmployeeStorage
    {
        internal static List<Employee> EmployeesList { get; }

        static EmployeeStorage() 
        {
            EmployeesList = new List<Employee>();
        }

        internal static void Write(Employee emp)
        {
            EmployeesList.Add(emp);
        }

        internal static void Delete(Employee emp)
        {
            EmployeesList.Remove(emp);
        }
    }
}
