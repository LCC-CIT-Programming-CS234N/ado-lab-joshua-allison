using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestAddCustomer()
        {
            /*Create the test variables.*/
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            /* Test the command.*/
            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            /* If the test subject has a name within the database, the test was successful. */
            Assert.AreEqual("Mickey Mouse", c.Name);
            /*Clean up the test*/
            CustomerDB.DeleteCustomer(c);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            /*Create the test variables.*/
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);

            /* Test the command.*/
            bool isCustomerDeleted = CustomerDB.DeleteCustomer(c);
            /* If it affected the database in some way, the test was successful. */
            Assert.AreEqual(true, isCustomerDeleted);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            /*Create the test variables.*/
            Customer oldCustomer = new Customer();
            oldCustomer.Name = "Mickey Mouse";
            oldCustomer.Address = "101 Main Street";
            oldCustomer.City = "Orlando";
            oldCustomer.State = "FL";
            oldCustomer.ZipCode = "10101";
            int customerID = CustomerDB.AddCustomer(oldCustomer);
            oldCustomer = CustomerDB.GetCustomer(customerID);

            Customer newCustomer = new Customer();
            newCustomer.Name = "Minnie Mouse";
            newCustomer.Address = "123 Dream Street";
            newCustomer.City = "Anaheim";
            newCustomer.State = "CA";
            newCustomer.ZipCode = "01010";
            
            /* Test the command.*/
            bool isCustomerUpdated = CustomerDB.UpdateCustomer(oldCustomer, newCustomer);
            /* If it affected the database in some way, the test was successful. */
            Assert.AreEqual(true, isCustomerUpdated);
            /* Clean up the test.*/
            newCustomer = CustomerDB.GetCustomer(customerID);
            CustomerDB.DeleteCustomer(newCustomer);
        }
    }
}
