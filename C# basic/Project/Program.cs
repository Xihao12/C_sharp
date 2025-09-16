using System;

namespace ConsoleCreatures
{
    class Program
    {
        static void Main()
        {
            // wrong comment:this is used for emoji
            // correct comment:This program prints an ASCII art creature to the console
            Console.WriteLine(" .-.");
            Console.WriteLine("(o o)");
            //wrong code:Console.WriteLine("| o |");
            //correct one should be:
            Console.WriteLine("| O |");
            Console.WriteLine("|   |");
            Console.WriteLine("'~~~'");
            Console.WriteLine("This is my creature");

            // one more easy and consise way to print all the results below:
            //Console.WriteLine(" .-.\n(o o)\n| O |\n|   |\n'~~~'");
        }
    }
}

