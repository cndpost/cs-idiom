using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LRU_CSharp;

namespace LRU_CSharp
{

    class LRUBuffer
    {
        public LRUBuffer(int ibufsize)
        {
            bufsize = ibufsize;
            capacity = ibufsize;
        }

        public string getByKey(string key)
        {
            for (int i = 0; i < keylist.Count(); i++)
            {
                //if found in cache

                //debug
                Console.WriteLine(" i = {0}, key = {1} \n", i, keylist[i]);
                if (keylist[i] == key)
                {
                    //return result
                    String result = "GOT " + keyvaluemap[key];
                    //erase from current location and insert at end
                    keylist.Remove(key);
                    keylist.Add(key);
                    return result;
                }
            }
            //else return NOTFOUND
            return "NOTFOUND";
        }

        public void setByKey(string key, string value)
        {
            //if key not exist before
            for (int i = 0; i < keylist.Count(); i++)
            {
                //if found, remove it from current location and insert at end

                if (keylist[i] == key)
                {
                    //debug
                    //	cout << "set a key which exist before " << endl;
                    keylist.Remove(key);
                    keylist.Add(key);

                    //update a keypair by erase existing one and insert a new one
                    keyvaluemap.Remove(key);
                    keyvaluemap.Add(key, value);
                    return;
                }
            }
            //else not exist before, insert at end
            //debug
            //cout << "set a key not exist before" << endl;

            keylist.Add(key);
            if (capacity > 0)
                capacity--;
            else
            {
                keylist.Remove(keylist[0]);
            }

            //insert a new keypair
            keyvaluemap.Add(key, value);
            return;
        }

        ~LRUBuffer()
        {
        }

        //private:
        //	string  *keys;
        //	string  *values;
        int bufsize;
        int capacity; //current remaining capacity, if it is > 0, no need to remove existing item from oldest 
        //Map<String, String> keyvaluemap;
        // Use Dictionary as a map.
        Dictionary<String, String> keyvaluemap = new Dictionary<String, String>();
        List<String> keylist = new List<String>();

    };//class
}; //Namespace


    class Program
    {
        static void Main(String[] args)
        {
    String input;
	String output;
	String verb;
	String key;
	String value;
    String[] inputs;
	int bufsize;
	LRUBuffer lruBuffer = new LRUBuffer(1);

	while (true) {
		input = Console.ReadLine();
		inputs = input.Split(' ').Select(sValue => sValue.Trim()).ToArray(); 
        if (inputs.Count() == 0) {
            output = "";
            Console.WriteLine("{0} \n",output);
            continue;
        } 
        
        if (inputs.Count() == 1) {
            if (inputs[0].ToLower() == "exit")
                return;
            output = inputs[0];
            Console.WriteLine("{0} \n",output);
            continue;
        }

        if (inputs.Count() > 1){
            verb = inputs[0].ToLower();
            if (inputs.Count() > 2)
            {
                key = inputs[1];
                if (inputs.Count() >= 3)
                {
                    value = inputs[2];
                }
            }

            if (verb == "size")
            {
               // key = inputs[1];
                bufsize = Int32.Parse(inputs[1]);
                if (bufsize <= 0)
                {
                    output = "ERROR";
                    Console.WriteLine("{0} \n", output);
                    continue;
                }

                //for any size >= 1, we clear the existing buffer and resize the buffer
                //if (lruBuffer != null)
                //	delete lruBuffer;  // to avoid memory leak
                lruBuffer = new LRUBuffer(bufsize);
                output = "SIZE OK";
                Console.WriteLine("{0} \n", output);
                continue;

            }
            else if (verb == "set"){
                key = inputs[1].Trim();
                if (inputs.Count() >= 3)
                    value = inputs[2].Trim();
                else
                    value = " ";
                if (value.Length == 0)
                {
                    output = "ERROR";
                    Console.WriteLine("{0} \n", output);
                    continue;
                }
                lruBuffer.setByKey(key, value);
                output = "SET OK";
                Console.WriteLine("{0} \n", output);
                continue;

            }
            else if (verb == "get"){
                key = inputs[1].Trim();
                if ((key.Length == 0) || (inputs.Count() > 2) )
                {
                    output = "ERROR";
                    Console.WriteLine("{0} \n", output);
                    continue;

                }
                output = lruBuffer.getByKey(key);
                Console.WriteLine("{0} \n", output);
                continue;
            }
            else if (verb == "exit")
            {
                return;
            }
            else
            {
                output = "ERROR";
                Console.WriteLine("{0} \n", output);
                continue;
            }  // verb
        } //input.Counts
        
	} // while
	//return;
    } // Main
} //Program
   
