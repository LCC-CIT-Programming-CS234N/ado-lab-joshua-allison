using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        // this method gets called BEFORE EVERY TEST to recreate the product object
        // so that every test gets a "fresh" product and the results of one test
        // don't impact the results of the next
        [SetUp]
        public void SetUp()
        {
            def = new Customer();
            c = new Customer(1, "Mouse, Mickey", "101 Main Street", "Orlando", "FL", "10001");
        }

        [Test]
        public void TestCustomerConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreEqual("Mouse, Mickey", c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);
        }

        #region Setters
        [Test]
        public void TestCustomerIDSetter()
        {
            c.CustomerID = 234;
            Assert.AreNotEqual(1, c.CustomerID);
            Assert.AreEqual(234, c.CustomerID);
        }

        [Test]
        public void TestNameSetter()
        {
            c.Name = "Mouse, Minnie";
            Assert.AreNotEqual("Mouse, Mickey", c.Name);
            Assert.AreEqual("Mouse, Minnie", c.Name);
        }

        [Test]
        public void TestSettersNameTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "            ");
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
        }

        [Test]
        public void TestAddressSetter()
        {
            c.Address = "999 1st Street";
            Assert.AreNotEqual("101 Main Street", c.Address);
            Assert.AreEqual("999 1st Street", c.Address);
        }

        [Test]
        public void TestSettersAddressTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "            ");
        }

        [Test]
        public void TestSettersAddressTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "012345687901234568790123456879012345687901234568790123456879");
        }

        [Test]
        public void TestCitySetter()
        {
            c.City = "Anaheim";
            Assert.AreNotEqual("Orlando", c.City);
            Assert.AreEqual("Anaheim", c.City);
        }

        [Test]
        public void TestSettersCityTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "            ");
        }

        [Test]
        public void TestSettersCityTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "012345678901234567890123456789");
        }

        [Test]
        public void TestStateSetter()
        {
            c.State = "CA";
            Assert.AreNotEqual("FL", c.State);
            Assert.AreEqual("CA", c.State);
        }

        [Test]
        public void TestSettersStateTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "C");
        }

        [Test]
        public void TestSettersStateTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "California");
        }

        [Test]
        public void TestZipCodeSetter()
        {
            c.ZipCode = "09990";
            Assert.AreNotEqual("1001", c.ZipCode);
            Assert.AreEqual("09990", c.ZipCode);
        }

        [Test]
        public void TestSettersZipCodeTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "           ");
        }

        [Test]
        public void TestSettersZipCodeTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "01234567890123456789");
        }
        #endregion

        [Test]
        public void TestCustomerGetters()
        {
            int newCustomerID = c.CustomerID;
            string newName = c.Name;
            string newAddress = c.Address;
            string newCity = c.City;
            string newState = c.State;
            string newZipCode= c.ZipCode;

            Assert.AreEqual(newCustomerID, c.CustomerID);
            Assert.AreEqual(newName, c.Name);
            Assert.AreEqual(newAddress, c.Address);
            Assert.AreEqual(newCity, c.City);
            Assert.AreEqual(newState, c.State);
            Assert.AreEqual(newZipCode, c.ZipCode);
        }

        [Test]
        public void TestCustomerToString()
        {
            Customer customer1 = new Customer(999, "Doe, John", "123 Main Street", "Jamestown", "VA", "90009");
            Assert.IsTrue(customer1.ToString().Contains("999"));
            Assert.IsTrue(customer1.ToString().Contains("Doe, John"));
            Assert.IsTrue(customer1.ToString().Contains("123 Main Street"));
            Assert.IsTrue(customer1.ToString().Contains("Jamestown"));
            Assert.IsTrue(customer1.ToString().Contains("VA"));
            Assert.IsTrue(customer1.ToString().Contains("90009"));
        }

        [Test]
        public void TestSettersInvalidValueTryCatch()
        {
            try
            {
                c.CustomerID = -1;
                c.Name = "012234567890122345678901223456789012234567890122345678901223456789012234567890122345678901223456789012234567890122345678901223456789";
                c.Address = "012234567890122345678901223456789012234567890122345678901223456789";
                c.City = "012234567890122345678901223456789";
                c.State = "123";
                c.ZipCode = "0122345678901223456789";
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        [Test]
        public void TestSettersInvalidValueThrows()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.CustomerID = -1);
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "012234567890122345678901223456789012234567890122345678901223456789012234567890122345678901223456789012234567890122345678901223456789");
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "012234567890122345678901223456789012234567890122345678901223456789");
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "012234567890122345678901223456789");
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "123");
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "0122345678901223456789");
        }
    }
}
