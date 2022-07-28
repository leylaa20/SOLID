namespace DependencyInversion;

// bad example

//public class Email
//{
//    public string? ToAddress { get; set; }
//    public string? Subject { get; set; }
//    public string? Content { get; set; }

//    public void SendEmail() => Console.WriteLine("Send email");
//}

//public class SMS
//{
//    public string? PhoneNumber { get; set; }
//    public string? Message { get; set; }
//    public void SendSMS() => Console.WriteLine("Send SMS");
//}

//public class Notification
//{
//    private Email _email;
//    private SMS _sms;

//    public Notification()
//    {
//        _email = new Email();
//        _sms = new SMS();
//    }

//    public void Send()
//    {
//        _email.SendEmail();
//        _sms.SendSMS();
//    }
//}


// good example

public interface IMessage
{
    void SendMessage();
}

public class Email : IMessage
{
    public string? ToAddress { get; set; }
    public string? Subject { get; set; }
    public string? Content { get; set; }

    public void SendMessage() => Console.WriteLine("Send email");
}

public class SMS : IMessage
{
    public string? PhoneNumber { get; set; }
    public string? Message { get; set; }

    public void SendMessage() => Console.WriteLine("Send SMS");
}

public class Notification
{
    private ICollection<IMessage> _messages;

    public Notification(ICollection<IMessage> messages)
    {
        _messages = messages;
    }

    public void Send()
    {
        foreach (var message in _messages)
            message.SendMessage();        
    }
}

class Program
{
    static void Main(string[] args)
    {

    }
}