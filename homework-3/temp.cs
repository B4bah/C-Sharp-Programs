using System;
using System.IO;

namespace ContactBookSearching
{
    internal class Program
    {
        static void Main()
        {
            Contact[] allContacts = GetContactBookFromFile("C:\\Users\\Asus\\source\\repos\\ООП\\задание 8 ООП\\Cotacts.txt");
            bool userChoice = GetUserChoice();
            string userInput = GetUserInputFromKBD(userChoice);
            Contact[] chosenContacts = FindChosenContacts(allContacts, userInput, userChoice);
            PrintChosenContacts(chosenContacts);
        }

        struct Contact
        {
            private string phoneNumber, name;

            public string PhoneNumber { get { return phoneNumber; } }
            public string Name { get { return name; } }

            public Contact(string phoneNumber, string name)
            {
                this.phoneNumber = phoneNumber;
                this.name = name;
            }
        }

        static Contact[] GetContactBookFromFile(string file)
        {
            string[] dataFromFile = ReadContactsParametersFromFile(file);
            Contact[] contacts = new Contact[dataFromFile.Length];
            int index = 0;

            foreach (string str in dataFromFile)
            {
                string[] contactData = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                Contact contact = new Contact(contactData[0], contactData[1]);
                contacts[index] = contact;
                index++;
            }

            return contacts;
        }

        static string[] ReadContactsParametersFromFile(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {

                byte[] array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);
                textFromFile = textFromFile.Replace("\r", "");
                string[] dataFromFile = textFromFile.Split(new char[] {'\n'});

                return dataFromFile;

            }
        }

        static bool GetUserChoice()
        {
            Console.WriteLine("Введите +, чтобы искать контакт по номеру телефона или любой дугой символ, чтобы искать по имени");
            string userInput = Console.ReadLine();
            if (userInput == "+")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string GetUserInputFromKBD(bool userChoice)
        {

            if (userChoice)
            {
                Console.WriteLine("Введите номер телефона");
            }
            else
            {
                Console.WriteLine("Введите имя");
            }

            string userInput = Console.ReadLine();
            return userInput;
        }

        static Contact[] FindChosenContacts(Contact[] allContacts, string userInput, bool userChoice)
        {
            Contact[] chosenContacts = new Contact[allContacts.Length];
            string contactElement;
            int index = 0;

            foreach (Contact contact in allContacts)
            {
                if (userChoice)
                {
                    contactElement = contact.PhoneNumber;
                }
                else
                {
                    contactElement = contact.Name;
                }

                if (contactElement == userInput)
                {
                    chosenContacts[index] = contact;
                    index++;
                }
            }

            return chosenContacts;
        }

        static void PrintChosenContacts(Contact[] chosenContacts)
        {
            if (chosenContacts[0].PhoneNumber == null && chosenContacts[0].Name == null)
            {
                Console.WriteLine("Ничего не нашлось");
            }
            else
            {
                foreach (Contact contact in chosenContacts)
                {
                    Console.WriteLine($"{contact.PhoneNumber} {contact.Name}");
                }
            }
        }
    }
}

