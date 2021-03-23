using System;
using System.Collections.Generic;
using System.Linq;

namespace Lucky_Ticket
{
    public class Program
    {
        public static List<int> TicketNumber = new List<int>();

        private static bool IsInputSymbolsCorrect(string input)
        {
            foreach (var symb in input)
            {
                if ((int)char.GetNumericValue(symb) == -1)
                    return false;
            }
            return true;
        }

        private static bool IsInputLengthCorrect(string input)
        {            
            return input.Length >= 4 && input.Length <= 8;
        }

        public bool IsTicketLucky(List<int> number)
        {
            if (number.Take(number.Count / 2).Sum() == number.Skip(number.Count / 2).Take(number.Count / 2).Sum())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ticket is lucky");
                Console.ForegroundColor = ConsoleColor.White;
                number.Clear();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ticket is unlucky");
                Console.ForegroundColor = ConsoleColor.White;
                number.Clear();
                return false;
            }            
        }

        public bool ParseTicketStringToIntList(string input)
        {
            if (IsInputLengthCorrect(input) && IsInputSymbolsCorrect(input))
            {
                foreach (var symb in input)
                    TicketNumber.Add((int)Char.GetNumericValue(symb));
                if (TicketNumber.Count % 2 != 0)
                    TicketNumber.Insert(0, 0);
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Program ticket = new Program();

            while(true)
            {
                Console.WriteLine("Enter ticket number(/q to exit): ");
                string ticketStr = Console.ReadLine();
                if (ticketStr == "/q")
                    break;
                if(!ticket.ParseTicketStringToIntList(ticketStr))
                {
                    Console.WriteLine("Input is incorrect. Try again...");
                    continue;
                }
                ticket.IsTicketLucky(TicketNumber);
            }
        }
    }
}
