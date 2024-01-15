using Directory_Space_Calculation;
using System.Text;

public class Program
{
    private static string? SizeInfo;
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;

        var currentDir = Directory.GetCurrentDirectory();

        var sizeCounterThread = new Thread(CountSize);
        sizeCounterThread.Start(currentDir);

        Console.WriteLine("Выполняется");

        while(sizeCounterThread.IsAlive)
        {
            Console.WriteLine(".");
            Thread.Sleep(100);
        }

        Console.WriteLine("Выполнено");

        Console.WriteLine($"Папка {currentDir} занимает {SizeInfo} на диске");
        Console.Read();
    }   
    public static void CountSize(object? obj)
    {
        if (obj != null)
        {
            SizeInfo = SizeCounter.GetDirSize((string)obj);
        }
    }
}