namespace School.Common;

public class Teacher : Person
{
    // Статичне поле - мінімальна зарплата
    public static readonly decimal MinimumSalary = 15000m;

    // Властивості
    public string Department { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    // Конструктор за замовчуванням
    public Teacher() : base()
    {
        Department = string.Empty;
        Position = string.Empty;
        Salary = MinimumSalary;
    }

    // Конструктор з параметрами
    public Teacher(string firstName, string lastName, DateTime dateOfBirth, string department, string position, decimal salary)
        : base(firstName, lastName, dateOfBirth)
    {
        Department = department;
        Position = position;
        Salary = salary < MinimumSalary ? MinimumSalary : salary;
    }

    // Метод
    public void IncreaseSalary(decimal percentage)
    {
        if (percentage > 0)
        {
            Salary += Salary * (percentage / 100);
            Console.WriteLine($"Зарплату викладача {GetFullName()} збільшено на {percentage}%");
        }
    }

    // Метод
    public bool IsSeniorTeacher()
    {
        return Position.Contains("професор", StringComparison.OrdinalIgnoreCase) ||
               Position.Contains("доцент", StringComparison.OrdinalIgnoreCase);
    }

    // Статичний метод
    public static decimal CalculateAnnualSalary(decimal monthlySalary)
    {
        return monthlySalary * 12;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Department: {Department}, Position: {Position}, Salary: {Salary:N2} ₴";
    }
}

