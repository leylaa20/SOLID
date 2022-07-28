namespace SingleResponsibility;

public class WorkReportEntry
{
    public string? ProjectCode { get; set; }
    public string? ProjectName { get; set; }
    public int SpentHours { get; set; }
}


// Bad Example
// bu class qeydiyyatlari add remove etmekden basqa file-da yazir 

//public class WorkReport
//{
//    private readonly List<WorkReportEntry> _entries;

//    public WorkReport()
//    {
//        _entries = new List<WorkReportEntry>();
//    }

//    public void AddEntry(WorkReportEntry entry) => _entries.Add(entry);
//    public void RemoveEntryAt(int index) => _entries.RemoveAt(index);

//    public void SaveToFile(string directoryPath, string fileName)
//    {
//        if (!Directory.Exists(directoryPath))
//            Directory.CreateDirectory(directoryPath);

//        File.WriteAllText(Path.Combine(directoryPath, fileName), ToString());
//    }

//    public override string ToString() =>
//        string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));
//}


// Asagidaki class-larda ise heresi ozune uygun is gorur

public class FileSaver
{
    public void SaveToFile(string directoryPath, string fileName, WorkReport report)
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);        

        File.WriteAllText(Path.Combine(directoryPath, fileName), report.ToString());
    }
}

public class WorkReport
{
    private readonly List<WorkReportEntry> _entries;

    public WorkReport()
    {
        _entries = new List<WorkReportEntry>();
    }

    public void AddEntry(WorkReportEntry entry) => _entries.Add(entry);
    public void RemoveEntryAt(int index) => _entries.RemoveAt(index);

    public override string ToString() =>
        string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));
}


class Program
{
    static void Main(string[] args)
    {
        var report = new WorkReport();

        report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
        report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });

        Console.WriteLine(report.ToString());

        var saver = new FileSaver();
        saver.SaveToFile(@"Reports", "WorkReport.txt", report);
    }
}