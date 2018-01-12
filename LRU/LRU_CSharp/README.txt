This is a C# version of my LRU cache implementation. It is ported from https://github.com/cndpost/cppidioms/tree/master/lrucache

That CPP version is also included in the soluton file of this LRU.sln, so you can do a project by project comparison to see the
differences of C++ and C# in terms of doing I/O, parsing string, implementing list and dicionary, etc.

The original requirements is listed as follows:
=======================================================


Please include the following in a zip or tar:

* A short README (or similar) that evaluates the runtime complexity of your algorithm, how to build the program (if needed), how to run the program, any known issues, limitations, assumptions, and any other details needed.
* The source code you have written.

Solutions to the problem below exist on the internet, but we are going to ask you to pretend that they don't. While we don't mind if you use the internet as you normally would to solve a previously unsolved problem (refreshing yourself general knowledge on syntax, libraries, etc), you should not look at cache algorithms and implementations and things of that sort. We trust that you will follow the spirit of this. 

We are interested in your approach and style, not someone else's. It's more important that it be your own than it be optimal or perfect. Finally, all of the code you supply for this exercise must be your own written from scratch for obvious reasons. Feel free to use standard language libraries.

With all of that out of the way, the question: 
Design and implement an LRU (Least Recently Used) cache. This is a cache with a fixed size in terms of the number of items it holds (supplied at instantiation). For this exercise, we won’t worry about the number of bytes. Your program can treat the keys and values as strings. You don’t need to support keys or values that contain spaces. The cache must allow client code to get items from the cache and set items to the cache. Once the cache is full, when the client wants to store a new item in the cache, an old item must be overwritten or removed to make room. The item we will remove is the Least Recently Used (LRU) item. Note that your cache does not need persistence across sessions.

Please read input from stdin and print output to stdout and support the following format (please DO NOT print any kind of a prompt or extra line breaks).

All inputs and outputs exist on their own line:

The first input line should set the max number of items for the cache using the keyword SIZE. The program should respond with ‘SIZE OK’. This must only occur as the first operation.

Set items with a line giving the key and value, separated by a space, 
your program should respond with 'SET OK'.

Get items with a line giving the key requested, your program should respond with the previously stored value, for example, “GOT foo”. If the key is not in the cache, it should reply with “NOTFOUND”.

‘EXIT’ should cause your program to exit.

If the input is invalid, your program should respond with ‘ERROR’

Sample Input
SIZE 3
GET foo
SET foo 1
GET foo
SET foo 1.1
GET foo
SET spam 2
GET spam
SET ham third
SET parrot four
GET foo
GET spam
GET ham
GET ham parrot
GET parrot
EXIT

Expected Output
SIZE OK
NOTFOUND
SET OK
GOT 1
SET OK
GOT 1.1
SET OK
GOT 2
SET OK
SET OK
NOTFOUND
GOT 2
GOT third
ERROR
GOT four