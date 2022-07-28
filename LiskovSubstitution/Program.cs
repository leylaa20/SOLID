namespace LiskovSubstitution;

// Bad example.

//public class BaseSubscriber
//{
//    public string? FullName { get; set; }
//    public string? Email { get; set; }
//    public string? Password { get; set; }

//    public virtual void GiveAccessToFamilyMembers() => Console.WriteLine("Access granted to family members");
//    public virtual void AccessToLimitedTitles() => Console.WriteLine("Access to limited titles");
//    public virtual void AccessToUnlimitedTitles() => Console.WriteLine("Access to unlimited titles");
//}

//public class StandardSubscriber : BaseSubscriber
//{
//    public override void AccessToLimitedTitles() => base.AccessToLimitedTitles();

//    public override void AccessToUnlimitedTitles()throw new InvalidOperationException("Method not allowed for Standard account");

//    public override void GiveAccessToFamilyMembers() => throw new InvalidOperationException("Method not allowed for Standard account");
//}

//public class PremiumSubscriber : BaseSubscriber
//{
//    public override void AccessToLimitedTitles() => base.AccessToLimitedTitles();

//    public override void AccessToUnlimitedTitles() => base.AccessToUnlimitedTitles();

//    public override void GiveAccessToFamilyMembers() => base.GiveAccessToFamilyMembers();
//}


// Good example

public class BaseSubscriber
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public void AccessToLimitedTitles() => Console.WriteLine("Access to limited titles");
}

public class StandardSubscriber : BaseSubscriber { }

public class PremiumSubscriber : BaseSubscriber
{
    public void AccessToUnlimitedTitles() => Console.WriteLine("Access to unlimited titles");
    public void GiveAccessToFamilyMembers() => Console.WriteLine("Access to give access to family members");
}


class Program
{
    static void Main(string[] args)
    {
        PremiumSubscriber premiumSubscriber = new();
        premiumSubscriber.AccessToUnlimitedTitles();

        StandardSubscriber standardSubscriber = new();
        standardSubscriber.AccessToLimitedTitles();
    }
}