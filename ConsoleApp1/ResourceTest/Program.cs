// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;

Console.WriteLine("Welcome to localization testing tool! Do you want to test all the resx files in an entire solution?  Type Y/y for testing all resx files in a solution, press any other key for testing resx files in a particular folder.");

var choice = Console.ReadLine();
if (choice.ToLower() == "y")
{
    Console.WriteLine("Please input the solution's root path:");
    var rootPath = Console.ReadLine();

    Console.WriteLine("Are you sure to test all the resx files in the entire solution? Type Y/y to confirm, type any other key to quit.");
    var choice0 = Console.ReadLine();

    if (choice0.ToLower() == "y")
    {
        Console.WriteLine("Here are all the files changed:");
        string[] files = Directory
        .GetFiles(rootPath, "*.resx", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            Console.WriteLine(file);
            SwapFile(file);
        };
    }
    else return;
}
else
{
    Console.WriteLine("Please input resx file folder:");
    var folder = Console.ReadLine();

    Console.WriteLine("Do you want to test a particular resx file in the foler? Type Y/y for testing particular file, press any other key to test all resx files in the foler:");
    var choice1 = Console.ReadLine();

    if (choice1.ToLower() == "y")
    {
        Console.WriteLine("what is the file name?");
        var fileName = Console.ReadLine();
        var filePath = string.Concat(folder, "/", fileName, ".resx");
        SwapFile(filePath);
        AskAgain(folder);

    }
    else
    {
        Console.WriteLine("Are you sure to test all the resx files in the folder? Type Y/y to confirm, type any other key to quit.");
        var choice2 = Console.ReadLine();
        if (choice2.ToLower() == "y")
            SwapDirectory(folder);
        else return;
    }
}

static void SwapDirectory(string folder)
{
    string[] fileEntries = Directory.GetFiles(folder, "*.resx");
    //Console.WriteLine(fileEntries[0]);
    foreach (string file in fileEntries)
        SwapFile(file);
}

static void SwapFile(string filePath)
{

    XDocument doc = XDocument.Load(filePath);
    foreach (XElement e in doc.Root.Elements("data").Elements("value"))
    {
        e.Value = "XXXXX";
    }
    doc.Save(filePath);

}

static void AskAgain(string folder)
{
    Console.WriteLine("do you want to test another file? Type Y/y for testing particular file, press any other key to quit.");
    var choice3 = Console.ReadLine();
    if (choice3.ToLower() == "y")
    {
        Console.WriteLine("what is the file name?");
        var fileName = Console.ReadLine();
        var filePath = string.Concat(folder, "/", fileName, ".resx");
        SwapFile(filePath);
        AskAgain(folder);
    }
    else return;
}
