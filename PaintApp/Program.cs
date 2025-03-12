using System;
namespace ConsolePaintApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ConsolePaintApp!");
            Canvas canvas = new Canvas();
            Command commandHandler = new Command(canvas);

            while (true)
            {
                canvas.Redraw();
                Console.WriteLine("\nAvailable commands: add, erase, move, bg, save, load, undo, redo, info, exit");
                Console.Write("Enter command: ");
                string? command = Console.ReadLine();

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine("Invalid command. Please enter a valid command.");
                    continue;
                }

                commandHandler.Execute(command);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}