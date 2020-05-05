using System;

namespace Lab01_Exception_Handling_and_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");
            StartSequence();

            Console.Write("Program is complete");
        }

        static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero.");
            int userInput = Convert.ToInt32(Console.ReadLine());

            int[] newArray = new int[userInput];

           
            Console.WriteLine($"The numbers in the array are {string.Join(", ", Populate(newArray))}");
            Console.WriteLine($"The sum of the array is {GetSum(newArray)}");
            GetProduct(newArray, GetSum(newArray));
            GetQuotient(GetProduct(newArray, GetSum(newArray)));

        }

        static int[] Populate(int[] intArray)
        {
            int j = 1;

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine($"Please enter a number: {j} of {intArray.Length}");
                intArray[i] = Convert.ToInt32(Console.ReadLine());
                j++;
            }
            Console.WriteLine($"Your array is size: {intArray.Length}");
            return intArray;
            
        }

        static int GetSum(int[] intArray)
        {
            int sum = 0;

            for (int i = 0; i < intArray.Length; i++)
            {
                sum += intArray[i];
            }

            return sum;
        }

        static int GetProduct(int[] intArray, int intSum)
        {
            Console.WriteLine($"Please select a random number between 1 and {intArray.Length}");
            int randomNum = Convert.ToInt32(Console.ReadLine());
            int product = intSum * randomNum;

            Console.WriteLine($"{intSum} * {randomNum} = {product}");
            return product;
        }

        static decimal GetQuotient(decimal intProduct)
        {
            Console.WriteLine($"Please enter a number to divide your product {intProduct} by.");
            decimal divideBy = Convert.ToInt32(Console.ReadLine());
            decimal quotient = decimal.Divide(intProduct, divideBy);

            Console.WriteLine($"{intProduct} / {divideBy} = {quotient}");
            return quotient;
        }

    }
}
