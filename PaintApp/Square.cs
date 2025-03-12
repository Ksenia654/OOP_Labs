using System;

namespace ConsolePaintApp
{
    public class Square : Shape
    {
        public int Width { get; set; }

        public Square(int x, int y, int width, int height) : base(x, y, height)
        {
            Width = width;
        }

        public override void Draw(int canvasWidth, int canvasHeight)
        {
            int width = Width; 
            int height = Size; 

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int drawX = X + j;
                    int drawY = Y + i;
                    if (drawX >= 0 && drawX < canvasWidth && drawY >= 0 && drawY < canvasHeight)
                    {
                        Console.SetCursorPosition(drawX, drawY);
                        if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                            Console.Write(FillChar);
                        else
                            Console.Write(BackgroundChar);
                    }
                }
            }
        }

        public override Shape Clone()
        {
            return new Square(X, Y, Width, Size) { FillChar = FillChar, BackgroundChar = BackgroundChar };
        }
    }
}
