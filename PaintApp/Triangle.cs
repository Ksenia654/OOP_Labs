using System;

namespace ConsolePaintApp
{
    public class Triangle : Shape
    {
        public int SideA { get; }
        public int SideB { get; }

        public Triangle(int x, int y, int sideA, int sideB, int size) : base(x, y, size)
        {

            SideA = sideA;
            SideB = sideB;
        }

        public override void Draw(int canvasWidth, int canvasHeight)
        {
            
            double semiPerimeter = (SideA + SideB + Size) / 2.0;

            
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - Size));

         
            int height = (int)(2 * area / Size);

            // Рисование треугольника
            for (int i = 0; i < height; i++)
            {
                
                int startX = X - (i * Size / height);
                int endX = X + (i * Size / height);

                for (int j = startX; j <= endX; j++)
                {
                    int drawX = j;
                    int drawY = Y + i;

                    if (drawX >= 0 && drawX < canvasWidth && drawY >= 0 && drawY < canvasHeight)
                    {
                        Console.SetCursorPosition(drawX, drawY);

                        // Рисование границ треугольника
                        if (i == height - 1 || j == startX || j == endX)
                            Console.Write(FillChar);
                        else
                            Console.Write(BackgroundChar);
                    }
                }
            }
        }

        public override Shape Clone()
        {
            return new Triangle(X, Y, SideA, SideB, Size) { FillChar = FillChar, BackgroundChar = BackgroundChar };
        }
    }
}