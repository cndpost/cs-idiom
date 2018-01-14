// SnakeGameCPP-Vector.cpp : Defines the entry point for the console application.
// This version of the snake game used the vector to implement the snake body data structure


#include "stdafx.h"
#include <vector>
using namespace std;

#define UP 0
#define RIGHT 1
#define DOWN 2
#define LEFT 3
#define FREE 0
#define APPLE 1
#define MINE 2
#define BODY 3

#define  N  30

//because the list will use pointers to struct, so we use the next typedef instead of struc def here
//struct position {
//	int x;
//	int y;
//};

typedef struct position {
	int x;
	int y;
} pos, *ppos;

class SnakeGame
{

private:
	int cell[N][N];// = new int[N][N]();
	int headX, headY;
	vector<ppos> snake;

public:
	SnakeGame()
	{
		//snake = new list<position>();
		;
	}
	~SnakeGame()
	{
		;
	}

	int MakeStep(int direction)
	{
		switch (direction)
		{
		case UP:
			if ((headY < N) && ((cell[headX][headY] == FREE) || (cell[headX][headY] == APPLE)))
			{
				cell[headX][headY + 1] = BODY;
				pos *head = new position();
				head->x = headX;
				head->y = headY++;
				snake.insert(snake.begin(), head);   //vector has insert(0,...), deque has push_front(), queue has push() operation; but 0 has to be iterator type so
													// has to be changed to snake.begin()
				if (cell[headX][headY] == FREE) {
					pos *tail = snake.back();
					cell[tail->x][tail->y] = FREE; //tail out of this position
					snake.pop_back();// list, deque, vector all have pop_back() operation. Simple queue does not have push_front or pop_back operations
					delete tail;  //avoid memory leak
				}
				return true;
			}
			break;
		case RIGHT:
			if ((headX < N) && ((cell[headX + 1][headY] == FREE) || (cell[headX + 1][headY] == APPLE)))
			{
				cell[headX + 1][headY] = BODY;
				pos *head = new position();
				head->x = headX++;
				head->y = headY;
				snake.insert(snake.begin(), head);
				if (cell[headX][headY] == FREE) {
					pos *tail = snake.back();
					cell[tail->x][tail->y] = FREE; //tail out of this position
					snake.pop_back();//.RemoveAt(snake.size() - 1);
					delete tail;  //avoid memory leak
				}
				return true;
			}
			break;
		case DOWN:
			if ((headY > 0) && ((cell[headX][headY - 1] == FREE) || (cell[headX][headY - 1] == APPLE)))
			{
				cell[headX][headY - 1] = BODY;
				pos *head = new position();
				head->x = headX;
				head->y = headY--;
				snake.insert(snake.begin(), head);
				if (cell[headX][headY] == FREE) {
					pos *tail = snake.back();
					cell[tail->x][tail->y] = FREE; //tail out of this position
					snake.pop_back();//.RemoveAt(snake.size() - 1);
					delete tail;  //avoid memory leak
				}
				return true;
			}
			break;
		case LEFT:
			if ((headX > 0) && ((cell[headX - 1][headY] == FREE) || (cell[headX - 1][headY] == APPLE)))
			{
				cell[headX - 1][headY] = BODY;
				pos *head = new position();
				head->x = headX--;
				head->y = headY;
				snake.insert(snake.begin(),head);
				if (cell[headX][headY] == FREE) {
					pos *tail = snake.back();
					cell[tail->x][tail->y] = FREE; //tail out of this position
					snake.pop_back();//.RemoveAt(snake.size() - 1);	
					delete tail;  //avoid memory leak
				}
				return true;
			}
			break;
		default:
			break;
		}

		return 0;
	};;
};

int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}
