using System;
using System.Collections.Generic;
using System.IO;

namespace ConsolePaintApp
{
    public class FileManager
    {
        public void SaveCanvas(Canvas canvas, string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine($"{Canvas.Width},{Canvas.Height}");
                    foreach (var shape in canvas.GetShapes())
                    {
                        string type = shape.GetType().Name;
                        if (shape is Square square)
                        {
                            writer.WriteLine($"{type},{shape.X},{shape.Y},{square.Width},{square.Size},{shape.FillChar},{shape.BackgroundChar}");
                        }
                        else if (shape is Triangle triangle)
                        {
                            
                            writer.WriteLine($"{type},{shape.X},{shape.Y},{triangle.SideA},{triangle.SideB},{triangle.Size},{shape.FillChar},{shape.BackgroundChar}");
                        }
                        else
                        {
                            writer.WriteLine($"{type},{shape.X},{shape.Y},{shape.Size},{shape.FillChar},{shape.BackgroundChar}");
                        }
                    }

                }
                Console.WriteLine("Canvas saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving canvas: {ex.Message}");
            }
        }

        public void LoadCanvas(Canvas canvas, string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("Error: File not found.");
                    return;
                }

                using (StreamReader reader = new StreamReader(filename))
                {
                    string? firstLine = reader.ReadLine();
                    if (firstLine == null)
                    {
                        Console.WriteLine("Error: File is empty or corrupt.");
                        return;
                    }
                    string[] dimensions = firstLine.Split(',');
                    if (dimensions.Length != 2 || !int.TryParse(dimensions[0], out int width) || !int.TryParse(dimensions[1], out int height))
                    {
                        Console.WriteLine("Error: Invalid canvas dimensions.");
                        return;
                    }
                    if (width != Canvas.Width || height != Canvas.Height)
                    {
                        Console.WriteLine("Error: Canvas dimensions do not match.");
                        return;
                    }

                    canvas.GetShapes().Clear();
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Error: Invalid shape data.");
                            return;
                        }
                        Shape shape = parts[0] switch
                        {
                            "Circle" => parts.Length == 6 && int.TryParse(parts[1], out int x1) && int.TryParse(parts[2], out int y1) && int.TryParse(parts[3], out int size1) ?
                                new Circle(x1, y1, size1) { FillChar = parts[4][0], BackgroundChar = parts[5][0] } :
                                throw new Exception("Invalid Circle data."),

                            "Rect" => parts.Length == 7 && int.TryParse(parts[1], out int x2) && int.TryParse(parts[2], out int y2) && int.TryParse(parts[3], out int rectWidth) && int.TryParse(parts[4], out int rectHeight) ?
                new Square(
                            x2 < 0 ? 0 : x2, 
                            y2 < 0 ? 0 : y2, 
                            x2 + rectWidth > Canvas.Width ? Canvas.Width - x2 : rectWidth, 
                            y2 + rectHeight > Canvas.Height ? Canvas.Height - y2 : rectHeight 
                          )
                           { FillChar = parts[5][0], BackgroundChar = parts[6][0] } :
                           throw new Exception("Invalid Square data."),

                            "Triangle" => parts.Length == 8 && int.TryParse(parts[1], out int x3) && int.TryParse(parts[2], out int y3) && int.TryParse(parts[3], out int sideA) && int.TryParse(parts[4], out int sideB) && int.TryParse(parts[5], out int size) ?
                                new Triangle(x3, y3, sideA, sideB, size) { FillChar = parts[6][0], BackgroundChar = parts[7][0] } :
                                throw new Exception("Invalid Triangle data."),

                            _ => throw new Exception("Unknown shape type.")
                        };


                        canvas.AddShape(shape);
                    }
                }
                Console.WriteLine("Canvas loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading canvas: {ex.Message}");
            }
        }

    }
}
