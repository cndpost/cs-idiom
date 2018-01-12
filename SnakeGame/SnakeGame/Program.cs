using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SnakeGameCSharp
{
  

    public class snakeGame
    {
        const int UP = 0;
        const int RIGHT= 1;
        const int DOWN = 2;
        const int LEFT = 3; 
        const int FREE = 0;
        const int APPLE = 1;
        const int MINE  = 2;
        const int BODY = 3;

        const int N  = 30;
        int [,]  cell = new int [N,N];

        int headX, headY;


        public struct position
        {
            public int x;
            public int y;
        };

        List<position> snake = new List<position>();

        public int initGame(int n, int x, int y)
        {
            cell = new int[n, n];
            headX = x;
            headY = y;
            position head = new position();
            head.x = x;
            head.y = y;
            snake.Add(head);
            return 0;

        }
        public bool MakeStep(int direction)
        {
            switch  (direction) {
                case UP:
                    if ( ( headY < N) && ( (cell[headX,headY+1] == FREE) || (cell[headX,headY+1] == APPLE) ) ) 
                    {
                        cell[headX,headY+1] = BODY;
                        position HeadPosition = new position();
                        HeadPosition.x = headX;
                        HeadPosition.y = headY++;

                        snake.Add(HeadPosition);
                        if (cell[headX,headY] == FREE)
                            snake.RemoveAt(snake.Count()-1);
                        return true;
                    } else
                        return false;
                    break;
               case RIGHT:
                    if ( ( headX < N) && ( (cell[headX+1,headY+1] == FREE) || (cell[headX+1,headY+1] == APPLE) ) ) 
                    {
                        cell[headX+1,headY] = BODY;
                        position HeadPosition = new position();
                        HeadPosition.x = headX++;
                        HeadPosition.y = headY;

                        snake.Add(HeadPosition);
                        if (cell[headX,headY] == FREE)
                            snake.RemoveAt(snake.Count()-1);
                        return true;
                    } else
                        return false;
                    break;
               case DOWN:
                    if ( ( headY > 0) && ( (cell[headX,headY-1] == FREE) || (cell[headX,headY-1] == APPLE) ) ) 
                    {
                        cell[headX,headY+1] = BODY;
                        position HeadPosition = new position();
                        HeadPosition.x = headX;
                        HeadPosition.y = headY--;

                        snake.Add(HeadPosition);
                        if (cell[headX,headY] == FREE)
                            snake.RemoveAt(snake.Count()-1);
                        return true;
                    } else
                        return false;
                    break;
               case LEFT:
                    if ( ( headX > 0) && ( (cell[headX-1,headY] == FREE) || (cell[headX-1,headY] == APPLE) ) ) 
                    {
                        cell[headX-1,headY+1] = BODY;
                        position HeadPosition = new position();
                        HeadPosition.x = headX--;
                        HeadPosition.y = headY;

                        snake.Add(HeadPosition);
                        if (cell[headX,headY+1] == FREE)
                            snake.RemoveAt(snake.Count()-1);
                        return true;
                    } else
                        return false;
                    break;
            }
                return false;
            
        }

        public int UpdateSnake(int x, int y, int cell)
        {
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
