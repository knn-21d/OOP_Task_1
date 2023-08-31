using System;
using WpfApp1;

public class Employee
{
    private string name;
	private int salary;
	private DateTime date;

	public Employee(string name, int salary, int day, int month, int year)
	{
		this.name = name;
		this.salary = salary;
		this.date = new DateTime(year, month, day);
		EmployeeStorage.Write(this);
	}

    public Employee(string name, int salary)
    {
        this.name = name;
        this.salary = salary;
        this.date = DateTime.Now;
        EmployeeStorage.Write(this);
    }

    public string Name
	{
		get => name;
		set { name = value; }
	}
	public int Salary
	{
		get => salary;
		set { salary = value; }
	}
    public int Experience
    {
        get => DateTime.Now.Year - this.date.Year;
    }

    public void ChangeSalary (int rate)
	{
		double _rate = rate;
		double _salary = Salary;
		Salary = Convert.ToInt32(_salary * (1.00 + _rate/100.00));
	}

	public static void ChangeSalaryGlobal (int rate)
	{
		EmployeeStorage.EmployeesList.ForEach(e =>
		{
			double _rate = rate;
			double _salary = e.Salary;
			e.Salary = Convert.ToInt32(_salary * (1.00 + _rate / 100.00));

		});
	}

	public override string ToString()
	{
		return $"Name: {name} Salary: {salary} Experience: {this.Experience}";
	}
}
