using System.Diagnostics;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Text.Encodings.Web;

string imagesFolderPath = $"C:\\Users\\{Environment.UserName}\\Desktop\\Images";
List<string> filenames = new List<string>();

string[] allSSnames = Directory.GetFiles(imagesFolderPath);

// Read file names from path
for (int i = 0; i < allSSnames.Length; i++)
{

    filenames.Add(allSSnames[i]);
}




// File yoxdusa yaratsin
if (!Directory.Exists(imagesFolderPath))
{
    Directory.CreateDirectory(imagesFolderPath);
    Console.WriteLine("Folder created !!");
}

else
{
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("File already exist");
    Console.BackgroundColor = ConsoleColor.Black;
}


dynamic key;
while (true)
{
    Console.Clear();
    Console.Write("\n\n\n\n\n\n\n\n\n\n");
    Console.Write("\t\t\t");
    Console.Write("Press enter take a screenshot and press Tab for list of all screen shotsss : ");

    key = Console.ReadKey();

    if (key.Key == ConsoleKey.Enter)
    {

        using Bitmap screenshot = new(1920, 1080);

        using Graphics graphics = Graphics.FromImage(screenshot);

        graphics.CopyFromScreen(0, 0, 0, 0, new Size(1920, 1080));

        string saved_path = $"{imagesFolderPath}\\Screenshot {filenames.Count + 1}.png";
        screenshot.Save(saved_path);
        filenames.Add(saved_path);

    }
    

    // Show all ss and open ss with index!!!
    else if (key.Key == ConsoleKey.Tab)
    {
        Console.Clear();
        int index = 0;
        int index_input;
        foreach (var item in filenames)
        {
            Console.WriteLine($"{index}){item}");
            index++;
        }

        //Console.Write($"Enter screenshots index(0 - {filenames.Count-1}): ");
        //index_input = int.Parse(Console.ReadLine());


        //Console.WriteLine(filenames[index_input]);


        //// Paintde acmaq ucun 
        //Process.Start(filenames[index_input]);

        Console.WriteLine( "pRESS ANY KEY TO GO BACK");
        Console.ReadKey();

        


    }

    //exit program
    else if (key.Key == ConsoleKey.Escape)
    {
        break;
    }
}


