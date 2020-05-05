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
                // Calling the method that calls Populate, GetSum, GetProduct, and GetQuotient
                StartSequence();
            }
            catch(Exception ex)
            {
                // Generic exception to handle if it hasnt been caught by another type of exception
                Console.Write("Whoops, something went wrong.", ex.Message);
            }
            finally
            {
                // Always ends the game with this string
                Console.Write("Program is complete");
            }
        }

        static void StartSequence()
        {
            try
            {
                // Prompt the user to enter a number & convert it to an int
                Console.WriteLine("Enter a number greater than zero.");
                int userInput = Convert.ToInt32(Console.ReadLine());

                // Create a new empty array with the array length equal to the user's input
                int[] newArray = new int[userInput];

                // Call Populate and then convert its return value to a string seperated by commas to show the user
                Console.WriteLine($"The numbers in the array are {string.Join(", ", Populate(newArray))}");

                // Call GetSum passing in the new array that was populated and setting it to variable sum
                int sum = GetSum(newArray);

                // Printing out sum to user
                Console.WriteLine($"The sum of the array is {sum}");

                // Call GetProduct passing in the populated newArray and the sum variable
                int product = GetProduct(newArray, sum);

                // Call GetQuotient passing in the product variable
                GetQuotient(product);
            }
            catch (FormatException fex)
            {
                // Handle formatting errors and gracefully tell the user:
                Console.WriteLine("Oops, there was an error with the format.");
            }
            catch(OverflowException oex)
            {
                // Handle overflows and gracefully tell the user:
                Console.WriteLine("Uh oh. Overflow detected");
            }

        }

        // Populate will return an int array
        static int[] Populate(int[] intArray)
        {
            // Set a counter starting at one to indicate to the user how many numbers they've populated so far
            int j = 1;

            // Make a for loop to iterate over each index in the new empty array
            for (int i = 0; i < intArray.Length; i++)
            {
                // Ask the user to input a number to fill the empty indexes of the new array
                Console.WriteLine($"Please enter a number: {j} of {intArray.Length}");

                //Convert the user's input to an integer
                intArray[i] = Convert.ToInt32(Console.ReadLine());

                // Increment the counter to move onto the next index in the array
                j++;
            }

            // Tell the user what the size of the array is
            Console.WriteLine($"Your array is size: {intArray.Length}");

            // Return the populated array to be sent up to StartSequence
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
