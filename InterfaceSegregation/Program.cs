namespace InterfaceSegregation;

// Bad example

//interface ISmartDevice
//{
//    void Print();
//    void Fax();
//    void Scan();
//}

//class AllInOnePrinter : ISmartDevice
//{
//    public void Print() => Console.WriteLine("AllInOnePrinter prints");
//    public void Fax() => Console.WriteLine("Beep booop biiiiip");
//    public void Scan() => Console.WriteLine("Scanning...");
//}

//// Economic-in ici bos qalmalidi yaxud exception atilmalidir

//class EconomicPrinter : ISmartDevice
//{
//    public void Print() => Console.WriteLine("EconomicPrinter prints");
//    public void Fax() => throw new NotSupportedException();
//    public void Scan() => throw new NotSupportedException();
//}


// good example

interface IPrinter
{
    void Print();
}

interface IFax
{
    void Fax();
}

interface IScanner
{
    void Scan();
}

class EconomicPrinter : IPrinter
{
    public void Print() => Console.WriteLine("EconomicPrinter prints");
}

class AllInOnePrinter : IPrinter, IFax, IScanner
{
    public void Print() => Console.WriteLine("AllInOnePrinter prints");

    public void Fax() => Console.WriteLine("Beep booop biiiiip");

    public void Scan() => Console.WriteLine("Scanning...");

}

class Program
{
    static void Main(string[] args)
    {

    }
}