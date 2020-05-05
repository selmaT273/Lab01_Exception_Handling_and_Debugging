using System;

namespace Lab01_Exception_Handling_and_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");
            StartSequence();
        }

        static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero.");
            int userInput = Convert.ToInt32(Console.ReadLine());

            int[] newArray = new int[userInput];

           
            Console.WriteLine(string.Join(", ", Populate(newArray)));
        }

        static int[] Populate(int[] intArray)
        {
            foreach (int newIndex in intArray)
            {
                Console.WriteLine($"Please enter a number: {newIndex} of {intArray}");
                intArray[newIndex] = Convert.ToInt32(Console.ReadLine());
            }
            return intArray;
        }

        //static int GetSum(intArray)
        //{

        //}

        //static int GetProduct(intArray, intSum)
        //{

        //}

        //static decimal GetQuotient(intProduct)
        //{

        //}

    }
}
