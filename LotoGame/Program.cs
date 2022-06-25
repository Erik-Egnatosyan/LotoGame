using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] ticket = new int[5, 10];
            Random rnd = new Random();
            //ticket logic
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int ticketValue = 0;
                    while (true)
                    {
                        int matchCount = 0;
                        ticketValue = rnd.Next(10, 98);

                        for (int k = 0; k < 5; k++)
                        {
                            for (int d = 0; d < 10; d++)
                            {
                                if (ticket[k, d] == ticketValue)
                                    matchCount++;
                            }
                        }
                        if (matchCount == 0)
                            break;
                    }
                    ticket[i, j] = ticketValue;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"{ticket[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // change logic for out of box while
            int[] outOfbox = new int[49];

            for (int i = 0; i < outOfbox.Length; i++)
            {
                int boxNumber = 0;
                while (true)
                {
                    int outNum = 0;
                    boxNumber = rnd.Next(10, 80);
                    for (int k = 0; k < outOfbox.Length; k++)
                    {
                        if (outOfbox[k] == boxNumber)
                        {
                            outNum++;
                        }
                    }
                    if (outNum == 0)
                    {
                        break;
                    }
                }
                outOfbox[i] = boxNumber;
                Console.WriteLine(outOfbox[i]);
            }
            //convert 99 if ticket has the number
            for (int x = 0; x < outOfbox.Length; x++)
            {
                for (int y = 0; y < ticket.GetLength(0); y++)
                {
                    for (int z = 0; z < ticket.GetLength(1); z++)
                    {
                        if (outOfbox[x] == ticket[y, z])
                        {
                            //Console.WriteLine("Yes you have a repeat number!");
                            ticket[y, z] = 99;
                        }
                    }
                }
            }
            //Output modified ticket
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"{ticket[i, j]} ");
                }
                Console.WriteLine();
            }
            //Win check if all columns have "99" number.
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ticket[i, j] == 99)
                    {
                        count++;
                    }
                }
            }
            if (count >= 10)
            {
                Console.WriteLine("You win my friend!");
            }
            else
            {
                Console.WriteLine("Are you lose?? It's impossible!!");
            }
        }
    }
}
