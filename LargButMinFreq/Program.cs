using System;
using System.Collections.Generic;

namespace LargButMinFreq
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"5
5
2 2 5 50 1
11
1 2 3 4 5 6 7 8 9 10 11
6
1 1 2 2 19 10
4
1 1 2 2
8
1 100 100 300 300 2 3 4";
            input = input.Replace("\r", "");
            Test[] tests = parseInput(input);

            foreach(Test t in tests)
            {
                int largest = LargButMinFreq(t.numbers, t.numbers.Length);
                Console.WriteLine(largest);
            }
        }

        public static Test[] parseInput(string input)
        {
            string[] inputs = input.Split("\n");
            Test[] tests = new Test[Int32.Parse(inputs[0])];
            int testPosition = 0;
            for(int i = 1; i < inputs.Length; i++)
            {
                Test t;
                if(i%2 == 1)//odd
                {
                    t = new Test(inputs[i+1].Split(" "));
                    tests[testPosition] = t;
                    testPosition++;
                }
            }
            return tests;
        }

        //Place elements into Dictionary where the key is the item and the value is the frequency
        public static int LargButMinFreq(int[] A, int n)
        {
            Dictionary<int, int> items = new Dictionary<int,int>();
            foreach(int number in A)
            {
                if (items.TryGetValue(number, out int val))
                {
                    items[number] = val + 1;
                }
                else
                {
                    items.Add(number, 1);
                }
            }

            int frequency = int.MaxValue;
            int largest = int.MinValue;

            foreach(KeyValuePair<int,int> keyValuePair in items)
            {
                //Console.WriteLine("Number: " + keyValuePair.Key + ", Frequency: " + keyValuePair.Value);
                if (frequency >= keyValuePair.Value)
                {
                    if (largest < keyValuePair.Key)
                    {
                        frequency = keyValuePair.Value;
                        largest = keyValuePair.Key;
                        //Console.WriteLine("Replacing");
                    }
                }
                
            }
            return largest;
        }


    }

    class Test
    {
        public int[] numbers;
        
        public Test(string[] input)
        {
            numbers = new int[input.Length];
            for(int i = 0; i < input.Length; i++)
            {
                numbers[i] = Int32.Parse(input[i]);
            }
        }
    }
}
