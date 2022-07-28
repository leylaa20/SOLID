namespace OpenClosed;

public class DeveloperReport
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Level { get; set; }
    public int WorkingHours { get; set; }
    public double HourlyRate { get; set; }
}

public abstract class BaseSalaryCalculator
{
    protected DeveloperReport DeveloperReport { get; private set; }

    public BaseSalaryCalculator(DeveloperReport developerReport)
    {
        DeveloperReport = developerReport;
    }

    public abstract double CalculateSalary();
}

public class SeniorDevSalaryCalculator : BaseSalaryCalculator
{
    public SeniorDevSalaryCalculator(DeveloperReport report)
        : base(report) { }

    public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
}

public class JuniorDevSalaryCalculator : BaseSalaryCalculator
{
    public JuniorDevSalaryCalculator(DeveloperReport developerReport)
        : base(developerReport) { }

    public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
}

public class SalaryCalculator
{
    private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;

    public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
    {
        _developerCalculation = developerCalculation;
    }

    public double CalculateTotalSalaries()
    {
        double totalSalaries = 0;

        foreach (var devCalc in _developerCalculation)
            totalSalaries += devCalc.CalculateSalary();

        return totalSalaries;
    }
}


class Program
{
    static void Main(string[] args)
    {
        var devCalculations = new List<BaseSalaryCalculator>
        {
            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
            new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
        };

        var calculator = new SalaryCalculator(devCalculations);
        Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");

    }
}