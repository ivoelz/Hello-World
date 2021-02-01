using System;
using System.IO; 
using System.Collections.Generic;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;

            do {

                Console.WriteLine("1. Read data from file.");
                Console.WriteLine("2. Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] ticket = line.Split(',');
                            string[] watching = ticket[6].Split('|');

                            Console.WriteLine($"Ticket {ticket[0]} \n");
                            Console.WriteLine($"Summary: {ticket[1]} \nStatus: {ticket[2]} \nPriority: {ticket[3]} \nSubmitter: {ticket[4]} \nAssigned: {ticket[5]} \nWatching: {String.Join(", ", watching)}\n\n");
                        }
                        sr.Close();
                    }
                    else Console.WriteLine("This file does not exist");
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file);

                    Console.Write("Please Enter Ticket ID: ");
                    string ticketId = Console.ReadLine();
                    
                    Console.Write("Please Enter Ticket Summary: ");
                    string summary = Console.ReadLine();

                    Console.Write("Please Enter Ticket Status: ");
                    string status = Console.ReadLine();

                    Console.Write("Please Enter Ticket Priority: ");
                    string priority = Console.ReadLine();

                    Console.Write("Please Enter Ticket Submitter Name: ");
                    string submitter = Console.ReadLine();

                    Console.Write("Please Enter Assigned Ticket Name: ");
                    string assigned = Console.ReadLine();

                    string addWatching;
                    List<string> watchers = new List<string>();

                    do {
                        Console.WriteLine("Please Enter Who's Watching: ");
                        watchers.Add(Console.ReadLine());

                        Console.Write("Would you like to enter another person who is watching? Y or N: ");
                        addWatching = Console.ReadLine().ToUpper();
                    } while (addWatching == "Y");

                    sw.WriteLine($"{ticketId},{summary},{status},{priority},{submitter},{assigned},{String.Join("|", watchers)}");
                    sw.Close();
                }

            } while (choice == "1" || choice == "2");

        }
    }
}
