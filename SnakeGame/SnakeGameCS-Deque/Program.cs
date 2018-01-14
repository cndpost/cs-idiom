using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Used Queue to implement the snake body data structure. Since C# does not have a built-in equivalent of deque class like C++, so it cannot do insert(0,...)
// or push_front(), pop_back(), so the add front and remove back operation has to be done in a copy operation in a hacked way


namespace SnakeGameCSharp
{


    public class snakeGame
    {
        const int UP = 0;
        const int RIGHT = 1;
        const int DOWN = 2;
        const int LEFT = 3;
        const int FREE = 0;
        const int APPLE = 1;
        const int MINE = 2;
        const int BODY = 3;

        const int N = 30;
        int[,] cell = new int[N, N];

        int headX, headY;


        public struct position
        {
            public int x;
            public int y;
        };

        System.Collections.Generic.
        Queue<position> snake = new Queue<position>();

        public int initGame(int n, int x, int y)
        {
            cell = new int[n, n];
            headX = x;
            headY = y;
            position head = new position();
            head.x = x;
            head.y = y;
            snake.Enqueue(head);   //C#  Queue does not have a insert or Add method. Only have enque and deque which adds to the end and remove from front
            return 0;

        }
        public bool MakeStep(int direction)
        {
            switch (direction)
            {
                case UP:
                    if ((headY < N) && ((cell[headX, headY + 1] == FREE) || (cell[headX, headY + 1] == APPLE)))
                    {
                        cell[headX, headY + 1] = BODY;
                        position HeadPosition = new position();
                        HeadPosition.x = headX;
                        HeadPosition.y = headY++;

                        //C# does not have a insert(0,xxx) method or push_front method, so have to hack like this
                        if (cell[headX, headY] == APPLE) {
                            Queue<position> newSnake = new Queue<position>();
                            newSnake.Enqueue(HeadPosition);
                            foreach (position pos in snake) {
                                newSnake.Enqueue(pos);
                            }
                                snake = newSnake;
                        }
                        if (cell[headX, headY] == FREE) {
                            Queue<position> newSnake = new Queue<position>();
                            newSnake.Enqueue(HeadPosition);
                            int c = snake.Count();
                            foreach (position pos in snake) {
                                if (c-- > 1)  // add all but last one
                                newSnake.Enqueue(pos);
                            }
                                snake = newSnake;
                        }
                        return true;
                    }
                    else
                        return false;
                    break;
                case RIGHT:
                    if ((headX < N) && ((cell[headX + 1, headY + 1] == FREE) || (cell[headX + 1, headY + 1] == APPLE)))
                    {
                        cell[headX + 1, headY] = BODY;
                        position HeadPosition = new position();
                        HeadPosition.x = headX++;
                        HeadPosition.y = headY;

                            //C# does not have a insert(0,xxx) method or push_front method, so have to hack like this
                        if (cell[headX, headY] == APPLE) {
                            Queue<position> newSnake = new Queue<position>();
                            newSnake.Enqueue(HeadPosition);
                            foreach (position pos in snake) {
                                newSnake.Enqueue(pos);
                            }
                                snake = newSnake;
                        }
                        if (cell[headX, headY] == FREE) {
                            Queue<position> newSnake = new Queue<position>();
                            newSnake.Enqueue(HeadPosition);
                            int c = snake.Count();
                            foreach (position pos in snake) {
                                if (c-- > 1)  // add all but last one
                                newSnake.Enqueue(pos);
                            }
                                snake = newSnake;
                        }
                        return true;
                  }
                    else
                        return false;
                    break;
                case DOWN:
                    if ((headY > 0) && ((cell[headX, headY - 1] == FREE) || (cell[headX, headY - 1] == APPLE)))
                    {
                        cell[headX, headY + 1] = BODY;
                        position HeadPosition = new position();
                        HeadPosition.x = headX;
                        HeadPosition.y = headY--;

                         //C# does not have a insert(0,xxx) method or push_front method, so have to hack like this
                        if (cell[headX, headY] == APPLE) {
                            Queue<position> newSnake = new Queue<position>();
                            newSnake.Enqueue(HeadPosition);
                            foreach (position pos in snake) {
                                newSnake.Enqueue(pos);
                            }
                                snake = newSnake;
                        }
                        if (cell[headX, headY] == FREE) {
                            Queue<position> newSnake = new Queue<position>();
                            newSnake.Enqueue(HeadPosition);
                            int c = snake.Count();
                            foreach (position pos in snake) {
                                if (c-- > 1)  // add all but last one
                                newSnake.Enqueue(pos);
                            }
                                snake = newSnake;
                        }
                        return true;
                    }
                    else
                        return false;
                    break;
                case LEFT:
                    if ((headX > 0) && ((cell[headX - 1, headY] == FREE) || (cell[headX - 1, headY] == APPLE)))
                    {
                        cell[headX - 1, headY + 1] = BODY;
                        position HeadPosition = new position();
                        HeadPosition.x = headX--;
                        HeadPosition.y = headY;

                        //C# does not have a insert(0,xxx) method or push_front method, so have to hack like this
                        if (cell[headX, headY] == APPLE) {
                            Queue<position> newSnake = new Queue<position>();
                            newSnake.Enqueue(HeadPosition);
                            foreach (position pos in snake) {
                                newSnake.Enqueue(pos);
                            }
                                snake = newSnake;
                        }
                        if (cell[headX, headY] == FREE) {
                            Queue<position> newSnake = new Queue<position>();
                            newSnake.Enqueue(HeadPosition);
                            int c = snake.Count();
                            foreach (position pos in snake) {
                                if (c-- > 1)  // add all but last one
                                newSnake.Enqueue(pos);
                            }
                                snake = newSnake;
                        }
                        return true;
                    }
                    else
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
