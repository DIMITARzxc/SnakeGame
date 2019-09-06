using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Eat
    {
        public int appleX = 10;
        public int appleY = 10;
      
        public bool IsAppleEaten = false;
        Random random = new Random();
        
        



        public void SpawnApple()
        {

            appleX = random.Next(2, 70-2);
            appleY = random.Next(0 + 2, 40 - 2);
        }
        public void PaintApple()
        {
            Console.SetCursorPosition(appleX, appleY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }
       


    }
}
