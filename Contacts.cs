// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contacts.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aryav Tiwari"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem_Collections
{
    public class Contact
    {
        /// <summary>
        /// Variables to store first name, last name, address, city, state, zip, phone number and email 
        /// </summary>
        public string firstName, lastName, address, city, state, zip, phoneNumber, email;

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        public Contact()
        {
            this.firstName = "";
            this.lastName = "";
            this.address = "";
            this.city = "";
            this.state = "";
            this.zip = "";
            this.phoneNumber = "";
            this.email = "";
        }
    }
}
