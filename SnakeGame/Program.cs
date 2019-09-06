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
    

    class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            snake.Boundary();
            snake.Appear();
            snake.Move();
            
        }
    }
}
