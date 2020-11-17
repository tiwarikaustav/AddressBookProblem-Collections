// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aryav Tiwari"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace AddressBookProblem_Collections
{
    class Program
    {
        /// <summary>
        /// addressBookMapper is a dictionary used to store All AddressBooks created in the project
        /// which can be accessed with the help of their name
        /// </summary>
        private static readonly Dictionary<string, AddressBook> addressBookMapper = new Dictionary<string, AddressBook>();

        /// <summary>
        /// Entry point of program
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            StartProgram();
        }

        /// <summary>
        /// StartProgram function takes user requirement 
        /// </summary>
        private static void StartProgram()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nEnter 1 to add New Address Book \nEnter 2 to Add Contacts \nEnter 3 to Edit Contacts " +
                    "\nEnter 4 to Delete Contacts\nEnter any other key to exit");
                string options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                        AddAddressBook();
                        break;
                    case "2":
                        AddContactsInAddressBook();
                        break;
                    case "3":
                        EditDetailsOfAddressBook();
                        break;
                    case "4":
                        DeleteContactsOfAddressBook();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }

        /// <summary>
        /// AddAddressBook function is called when user want to create new AddressBook
        /// </summary>
        private static void AddAddressBook()
        {
            Console.WriteLine("\nEnter Name for the New Address Book");
            string name = Console.ReadLine();
            if (addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("Address Book Already exist with this name");
            }
            else
            {
                AddressBook addressBook = new AddressBook();
                addressBookMapper.Add(name, addressBook);
            }
        }

        /// <summary>
        /// AddContactsInAddressBook is called when user ask to enter new contact details in any AddressBook
        /// </summary>
        private static void AddContactsInAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to add new contact");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("These names already exist:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.AddContacts();
            }
        }

        /// <summary>
        /// EditDetailsOfAddressBook is called when a user ask to modify Contact details in a AddressBook
        /// </summary>
        private static void EditDetailsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to modify contact details");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.EditDetails();
            }
        }

        /// <summary>
        /// DeleteContactsOfAddressBook is called when user want to delete a particular contact from a AddressBook
        /// </summary>
        private static void DeleteContactsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to delete contact details");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.DeleteContact();
            }
        }
    }
}
