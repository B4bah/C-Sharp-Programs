using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Program
{
    class NumberToName
    {
        static void Main()
        {
            Dictionary<string, string> contacts = GetContactsFromFile("contacts.txt");
            bool userChoice = GetUserChoice();
            string userInput = GetUserInput(userChoice);
            string requestedContactInfo = FindAskedContactInfo(contacts, userChoice, userInput);
            PrintRequestedContactInfo(requestedContactInfo, userChoice, userInput);
        }

        // Declaration of functions
        static Dictionary<string, string> GetContactsFromFile(string filename)
        {
            Dictionary<string, string> contacts = new Dictionary<string, string>();
            
            string[] allLines = File.ReadAllLines(filename);
            
            foreach (string line in allLines)
            {
                string[] parts = line.Split('-');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string phone = parts[1].Trim();
                    contacts[name] = phone;
                }
            }
            
            return contacts;
        }

        static bool GetUserChoice()
        {
            Console.Write("Do you wanna find the name of the contact with his phone number? [y/n]:\n>>> ");
            string input = Console.ReadLine();

            return input.ToLower() == "y";
        }

        static string GetUserInput(bool choice)
        {
            if (choice)
            {
                Console.Write("Enter the phone number of the contact:\n>>> ");
                return Console.ReadLine();
            }
            else
            {
                Console.Write("Enter the name of the contact:\n>>> ");
                return Console.ReadLine();
            }
        }

        static string FindAskedContactInfo(Dictionary<string, string> contacts, bool choice, string userInput)
        {
            if (choice)
            {
                return FindNameByNumber(contacts, userInput);
            }
            else
            {
                return FindNumberByName(contacts, userInput);
            }
        }
        
        static string FindNameByNumber(Dictionary<string, string> contacts, string phoneNumber)
        {
            foreach (var contact in contacts)
            {
                if (contact.Value == phoneNumber)
                {
                    return contact.Key;
                }
            }
            return null;
        }

        static string FindNumberByName(Dictionary<string, string> contacts, string name)
        {
            if (contacts.ContainsKey(name))
            {
                return contacts[name];
            }
            return null;
        }

        static void PrintRequestedContactInfo(string contactInfo, bool choice, string userInput)
        {
            if (contactInfo == null)
            {
                if (choice)
                {
                    Console.WriteLine($"Contact with phone number '{userInput}' not found.");
                }
                else
                {
                    Console.WriteLine($"Contact with name '{userInput}' not found.");
                }
            }
            else
            {
                if (choice)
                {
                    Console.WriteLine($"Phone number '{userInput}' belongs to: {contactInfo}");
                }
                else
                {
                    Console.WriteLine($"Contact '{userInput}' has phone number: {contactInfo}");
                }
            }
        }
    }
}