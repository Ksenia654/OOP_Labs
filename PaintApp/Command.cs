using System;

namespace ConsolePaintApp
{
    public class Command
    {
        private Canvas canvas;

        public Command(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                Console.WriteLine("Error: Command cannot be empty.");
                return;
            }

            string cmd = command.ToLower().Trim();
            switch (cmd)
            {
                case "add":
                    AddShape();
                    break;
                case "erase":
                    EraseShape();
                    break;
                case "move":
                    MoveShape();
                    break;
                case "bg":
                    SetBackground();
                    break;
                case "save":
                    SaveCanvas();
                    break;
                case "load":
                    LoadCanvas();
                    break;
                case "undo":
                    canvas.Undo();
                    break;
                case "redo":
                    canvas.Redo();
                    break;
                case "info":
                    canvas.DisplayShapes();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }

        private void AddShape()
        {
            Console.Write("Enter shape type (circle/rect/triangle): ");
            string? typeInput = Console.ReadLine();
            string type = typeInput?.ToLower() ?? string.Empty;
            if (type != "circle" && type != "rect" && type != "triangle")
            {
                Console.WriteLine("Error: Invalid shape type.");
                return;
            }

            Console.Write("Enter X: ");
            if (!int.TryParse(Console.ReadLine(), out int x) || x < 0)
            {
                Console.WriteLine("Error: X must be a non-negative integer.");
                return;
            }

            Console.Write("Enter Y: ");
            if (!int.TryParse(Console.ReadLine(), out int y) || y < 0)
            {
                Console.WriteLine("Error: Y must be a non-negative integer.");
                return;
            }

            Shape shape;

            // Обработка фигур в зависимости от типа
            switch (type)
            {
                case "circle":
                    Console.Write("Enter radius: ");
                    if (!int.TryParse(Console.ReadLine(), out int radius) || radius <= 0)
                    {
                        Console.WriteLine("Error: Radius must be a positive integer.");
                        return;
                    }
                    shape = new Circle(x, y, radius);
                    break;

                case "rect":
                    Console.Write("Enter width: ");
                    if (!int.TryParse(Console.ReadLine(), out int width) || width <= 0)
                    {
                        Console.WriteLine("Error: Width must be a positive integer.");
                        return;
                    }
                    Console.Write("Enter height: ");
                    if (!int.TryParse(Console.ReadLine(), out int height) || height <= 0)
                    {
                        Console.WriteLine("Error: Height must be a positive integer.");
                        return;
                    }
                    shape = new Square(x, y, width, height);
                    break;

                case "triangle":
                    Console.Write("Enter side A: ");
                    if (!int.TryParse(Console.ReadLine(), out int sideA) || sideA <= 0)
                    {
                        Console.WriteLine("Error: Side A must be a positive integer.");
                        return;
                    }
                    Console.Write("Enter side B: ");
                    if (!int.TryParse(Console.ReadLine(), out int sideB) || sideB <= 0)
                    {
                        Console.WriteLine("Error: Side B must be a positive integer.");
                        return;
                    }
                    Console.Write("Enter side C: ");
                    if (!int.TryParse(Console.ReadLine(), out int sideC) || sideC <= 0)
                    {
                        Console.WriteLine("Error: Side C must be a positive integer.");
                        return;
                    }

                    if (sideA < 4 || sideB < 4 || sideC < 4)
                    {
                        Console.WriteLine("Error: Triangle is too little to draw.");
                        return; 
                    } 

                    // Проверка валидности треугольника
                    if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                    {
                        Console.WriteLine("Error: The provided sides do not form a valid triangle.");
                        return;
                    }

                    shape = new Triangle(x, y, sideA, sideB, sideC);
                    break;

                default:
                    Console.WriteLine("Error: Unknown shape type.");
                    return;
            }

            canvas.AddShape(shape);
        }


        private void EraseShape()
        {
            Console.Write("Enter index to erase: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0)
            {
                Console.WriteLine("Error: Index must be a non-negative integer.");
                return;
            }
            canvas.EraseShape(index);
        }

        private void MoveShape()
        {
            Console.Write("Enter index to move: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0)
            {
                Console.WriteLine("Error: Index must be a non-negative integer.");
                return;
            }

            Console.Write("Enter new X: ");
            if (!int.TryParse(Console.ReadLine(), out int newX) || newX < 0)
            {
                Console.WriteLine("Error: New X must be a non-negative integer.");
                return;
            }

            Console.Write("Enter new Y: ");
            if (!int.TryParse(Console.ReadLine(), out int newY) || newY < 0)
            {
                Console.WriteLine("Error: New Y must be a non-negative integer.");
                return;
            }

            canvas.MoveShape(index, newX, newY);
        }

        private void SetBackground()
        {
            Console.Write("Enter index to set background: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0)
            {
                Console.WriteLine("Error: Index must be a non-negative integer.");
                return;
            }

            Console.Write("Enter background character: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: Background character cannot be empty.");
                return;
            }
            char bgChar = input[0];
            canvas.SetBackground(index, bgChar);
        }

        private void SaveCanvas()
        {
            Console.Write("Enter filename to save: ");
            string? filename = Console.ReadLine();
            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("Error: Filename cannot be empty.");
                return;
            }
            FileManager fileManager = new FileManager();
            fileManager.SaveCanvas(canvas, filename);
        }

        private void LoadCanvas()
        {
            Console.Write("Enter filename to load: ");
            string? filename = Console.ReadLine();
            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("Error: Filename cannot be empty.");
                return;
            }
            FileManager fileManager = new FileManager();
            fileManager.LoadCanvas(canvas, filename);
        }
    }
}