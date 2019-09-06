using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    /*My tasks today
     * Get the snake to appear on screen
     * Get move
     * Battle 
     */
    public class Snake
    {
        private int yPosition { get; set; }
        private int xPosition { get; set; }
        public bool IsGameOn;
        public bool IsWallHit;
        

        


        public void Appear()
        {
             xPosition = 35;
             yPosition = 20;
             IsGameOn = true;
            Console.SetCursorPosition(xPosition, yPosition);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)2);
            Console.ReadLine();
        }
        public void Boundary()
        {
            for(int i=1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(70,i);
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
                Console.WriteLine((char)2);
                Console.ReadLine();

            } while (IsGameOn);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            snake.Boundary();
            snake.Appear();
        }
    }
}
