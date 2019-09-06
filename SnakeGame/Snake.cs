using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{

    public class Snake
    {
        public int[] yPosition = new int[50];
        public int[] xPosition = new int[50];
        private decimal gameSpeed { get; set; }
        public int applesEaten = 0;
        Eat apple = new Eat();


        public bool IsGameOn;
        public bool IsWallHit;
        public bool IsAppleEaten;




       

        public void Appear()
        {
            xPosition[0] = 35;
            yPosition[0] = 20;
            IsGameOn = true;
            IsWallHit = false;
            PaintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);
            apple.SpawnApple();//Set Apple when snake appear
           
            apple.PaintApple();
            
            Console.ReadLine();
        }
        public void Boundary()
        {
            Console.CursorVisible = false;
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(70, i);
                Console.Write("#");
            }
            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, 40);
                Console.Write("#");
            }
        }
        public void Move()
        {
            gameSpeed = 100;
            IsAppleEaten = false;
            ConsoleKey command = Console.ReadKey().Key;
            do
            {
                switch (command)
                {

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]++;
                        break;


                }

                PaintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

                IsWallHit = SnakeHitWall(xPosition[0], yPosition[0]);
                if (IsWallHit)
                {
                    IsGameOn = false;
                    Console.SetCursorPosition(28, 20);
                    Console.WriteLine("The snake hit the wall and died...");
                    Console.ReadLine();

                }
                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));
                IsAppleEaten = determineIfAppleIsEaten(xPosition[0], yPosition[0], apple.appleX, apple.appleY);
                if (IsAppleEaten)
                {
                    apple.SpawnApple();
                    apple.PaintApple();
                    applesEaten++;
                    gameSpeed *= .925m;
                }
               
            } while (IsGameOn);
           

        }

        

        private bool determineIfAppleIsEaten(int xPosition, int yPosition, int appleX, int appleY)
        {
            if (xPosition == appleX && yPosition == appleY) return true; return false;
        }

        private void PaintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)214);
            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(" ");

            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = xPositionIn[i - 1];
            }
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        }

        public bool SnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40) return true; return false;
        }

       

    }
}
