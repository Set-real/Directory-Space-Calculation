using Directory_Space_Calculation;
using System.Text;

public class Program
{
    private static string? SizeInfo;
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;

        // Получаю путь к текущей директории
        var currentDir = Directory.GetCurrentDirectory();

        // Создание потока и передача в него параметров через ParametherizedThreadStart
        var sizeCounterThread = new Thread(CountSize);
        sizeCounterThread.Start(currentDir);

        Console.WriteLine("Выполняется");

        // Создаю визульный рад, пока работает программа
        while(sizeCounterThread.IsAlive)
        {
            Console.WriteLine(".");
            Thread.Sleep(100);
        }

        Console.WriteLine("Выполнено");

        Console.WriteLine($"Папка {currentDir} занимает {SizeInfo} на диске");
        Console.Read();
    }  
    /// <summary>
    /// Вызов методя для подсчета размера директории с файлами
    /// </summary>
    /// <param name="obj"></param>
    public static void CountSize(object? obj)
    {
        if (obj != null)
        {
            SizeInfo = SizeCounter.GetDirSize((string)obj);
        }
    }
}