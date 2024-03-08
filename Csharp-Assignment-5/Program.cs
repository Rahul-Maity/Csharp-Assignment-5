using System;
using System.IO;
using System.Threading.Tasks;

public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000); // Simulate a blocking operation

        string filePath=Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp.txt");  
        Console.WriteLine(filePath);
        await File.WriteAllTextAsync(filePath, message);
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        BackgroundOperation backgroundOperation = new BackgroundOperation();

        while (true)
        {
            Console.WriteLine("Kiosk Menu:");
            Console.WriteLine("1. Write 'Hello World'");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice (1/2/3/4):");

            string choice = Console.ReadLine();
            string message = "";

            switch (choice)
            {
                case "1":
                    message = "Hello World";
                    break;
                case "2":
                    message = DateTime.Now.ToString();
                    break;
                case "3":
                    message = Environment.OSVersion.VersionString;
                    break;
                case "4":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please enter 1, 2, 3, or 4.");
                    continue;
            }

            Task task = backgroundOperation.WriteToFileAsync(message);

            Console.WriteLine("Writing to file in progress...");

            await task;

            Console.WriteLine("Writing to file completed successfully.");
        }
    }
}
