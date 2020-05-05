using System;

namespace Lab01_Exception_Handling_and_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");

            try
            {
                StartSequence();
            }
            catch(Exception ex)
            {
                Console.Write("Whoops, something went wrong.", ex.Message);
            }
            finally
            {
                Console.Write("Program is complete");
            }
        }

        static void StartSequence()
        {
            try
            {

                Console.WriteLine("Enter a number greater than zero.");
                int userInput = Convert.ToInt32(Console.ReadLine());

                int[] newArray = new int[userInput];


                Console.WriteLine($"The numbers in the array are {string.Join(", ", Populate(newArray))}");
                int sum = GetSum(newArray);
                Console.WriteLine($"The sum of the array is {sum}");
                int product = GetProduct(newArray, sum);
                GetQuotient(product);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Oops, there was an error with the format.");
            }
            catch(OverflowException oex)
            {
                Console.WriteLine("Uh oh. Overflow detected");
            }

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
            try
            {
                Console.WriteLine($"Please select a random number between 1 and {intArray.Length}");
                int randomNum = Convert.ToInt32(Console.ReadLine());
                int product = intSum * randomNum;

                Console.WriteLine($"{intSum} * {randomNum} = {product}");
                return product;
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.WriteLine("Out of range");
                throw iex;
            }
        }

        static decimal GetQuotient(decimal intProduct)
        {
            try
            {
                Console.WriteLine($"Please enter a number to divide your product {intProduct} by.");
                decimal divideBy = Convert.ToInt32(Console.ReadLine());
                decimal quotient = decimal.Divide(intProduct, divideBy);

                Console.WriteLine($"{intProduct} / {divideBy} = {quotient}");
                return quotient;
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine(dex.Message);
                return 0;
            }
        }

    }
}
