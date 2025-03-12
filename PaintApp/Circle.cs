using System;

namespace ConsolePaintApp
{
    public class Circle : Shape
    {
        private const double WidthCoefficient = 1;

        public Circle(int x, int y, int size) : base(x, y, size) { }

        public override void Draw(int canvasWidth, int canvasHeight)
        {
            int radius = Size;
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    double adjustedJ = j / WidthCoefficient;
                    double distance = Math.Sqrt(i * i + adjustedJ * adjustedJ);

                    if (Math.Abs(distance - radius) < 0.5)
                    {
                        int drawX = X + j;
                        int drawY = Y + i;
                        if (drawX >= 0 && drawX < canvasWidth && drawY >= 0 && drawY < canvasHeight)
                        {
                            Console.SetCursorPosition(drawX, drawY);
                            Console.Write(FillChar);
                        }
                    }
                    else if (distance < radius)
                    {
                        int drawX = X + j;
                        int drawY = Y + i;
                        if (drawX >= 0 && drawX < canvasWidth && drawY >= 0 && drawY < canvasHeight)
                        {
                            Console.SetCursorPosition(drawX, drawY);
                            Console.Write(BackgroundChar);
                        }
                    }
                }
            }
        }

        public override Shape Clone()
        {
            return new Circle(X, Y, Size) { FillChar = FillChar, BackgroundChar = BackgroundChar };
        }
    }
}