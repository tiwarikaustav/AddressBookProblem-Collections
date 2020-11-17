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
        /// addressBookMapper is a data structure used to store All AddressBooks created in the project
        /// which can be accessed with the help of their name
        /// </summary>
        private static readonly Dictionary<string, AddressBook> addressBookMapper = new Dictionary<string, AddressBook>();

        /// <summary>
        /// cityToContactMapperGlobal is a variable which store all contacts with their city names
        /// </summary>
        public static readonly Dictionary<string, List<Contact>> cityToContactMapperGlobal = new Dictionary<string, List<Contact>>();

        /// <summary>
        /// stateToContactMapperGlobal is a variable which store all contacts with their state names
        /// </summary>
        public static readonly Dictionary<string, List<Contact>> stateToContactMapperGlobal = new Dictionary<string, List<Contact>>();

        /// <summary>
        /// Defines the entry point of the application.
        /// Calls StartProgram function
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            StartProgram();
        }

        /// <summary>
        /// StartProgram function asks user about which activity to be done
        /// </summary>
        private static void StartProgram()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nEnter 1 to add New Address Book \nEnter 2 to Add Contacts \nEnter 3 to Edit Contacts " +
                    "\nEnter 4 to Delete Contacts\nEnter 5 to search contact using city name" +
                    "\nEnter 6 to search contact using state name\nEnter any other key to exit");
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
                    case "5":
                        SearchContactWithCityName();
                        break;
                    case "6":
                        SearchContactWithStateName();
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
                Console.WriteLine("Please Enter Valid Name from following names:");
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

        private static void SearchContactWithCityName()
        {
            Console.WriteLine("\nEnter full name of the person!");
            string personName = Console.ReadLine();
            Console.WriteLine("\nEnter name of the city!");
            string cityName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(cityName))
            {
                Console.WriteLine("No record found with such city name!");
                return;
            }
            foreach (Contact contact in cityToContactMapperGlobal[cityName])
            {
                if ((contact.firstName + " " + contact.lastName) == personName)
                {
                    Console.WriteLine("Contact found!");
                    Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                    Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                    Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                    Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                    return;
                }
            }
            Console.WriteLine($"No Contact Exist With This Name!");
        }

        private static void SearchContactWithStateName()
        {
            Console.WriteLine("\nEnter full name of the person!");
            string personName = Console.ReadLine();
            Console.WriteLine("\nEnter name of the state!");
            string stateName = Console.ReadLine();
            if (!stateToContactMapperGlobal.ContainsKey(stateName))
            {
                Console.WriteLine("No record found with this state name!");
                return;
            }
            foreach (Contact contact in stateToContactMapperGlobal[stateName])
            {
                if ((contact.firstName + " " + contact.lastName) == personName)
                {
                    Console.WriteLine("Contact found!");
                    Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                    Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                    Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                    Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                    return;
                }
            }
            Console.WriteLine($"No Contact Exist With This Name!");
        }
    }
}
