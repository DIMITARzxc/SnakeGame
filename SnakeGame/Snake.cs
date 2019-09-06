using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    
    public class Snake
    {
        public int yPosition;
        public int xPosition { get; set; }
        private int gameSpeed { get; set; }
        Eat apple = new Eat();
        
        
        public bool IsGameOn;
        public bool IsWallHit;
        public bool IsAppleEaten;
        public Random rnd = new Random();




        public void Appear()
        {
            xPosition = 35;
            yPosition = 20;
            IsGameOn = true;
            IsWallHit = false;
            Console.SetCursorPosition(xPosition, yPosition);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)214);
            apple.SpawnApple();//Set Apple when snake appear
            apple.PaintApple();
            Console.ReadLine();
        }
        public void Boundary()
        {
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
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        xPosition--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        yPosition--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        xPosition++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        yPosition++;
                        break;


                }
                Console.SetCursorPosition(xPosition, yPosition);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((char)214);

                IsWallHit = SnakeHitWall(xPosition, yPosition);
                if (IsWallHit)
                {
                    IsGameOn = false;
                    Console.SetCursorPosition(28, 20);
                    Console.WriteLine("The snake hit the wall and died...");
                    Console.ReadLine();
                   
                }
                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(gameSpeed);
                if (IsAppleEaten)
                {
                    apple.SpawnApple();
                    apple.PaintApple();
                }
            } while (IsGameOn);
            

        }
        public bool SnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40) return true; return false;
        }
       

       
    }
}
