using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]
        public void SetUp()
        {
            def = new Product();
            p = new Product("RD101", "Medium red apple. Grainy. Sweet.", 1, 60);
        }

        [Test]
        public void TestProductConstructors()
        {
            //Below, you will see that the arguments for ProductUnitPrice and ProductOnHandQuantity are not "null". This is because when I tested it, the tester said that for price it was expecting 0m, and for quantity, it was expecting 0. I didn't know types had different default values. Experiencing this makes me believe that strings are null if constructed by default, ints are 0 by default, and decimals are 0m by default. I'm not really sure how accurate any of this is, but at least I can explain why null is not used for price and quantity.
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.ProductDescription);
            Assert.AreEqual(0m, def.ProductUnitPrice);
            Assert.AreEqual(0, def.ProductOnHandQuantity);

            Assert.IsNotNull(p);
            Assert.AreNotEqual(null, p.ProductCode);
            Assert.AreEqual("RD101", p.ProductCode);
            Assert.AreNotEqual(null, p.ProductDescription);
            Assert.AreNotEqual(0m, p.ProductUnitPrice);
            Assert.AreNotEqual(0, p.ProductOnHandQuantity);
        }

        [Test]
        public void TestProductGetters()
        {
            string newProductCode = p.ProductCode;
            string newProductDescription = p.ProductDescription;
            decimal newProductUnitPrice = p.ProductUnitPrice;
            int newProductOnHandQuantity = p.ProductOnHandQuantity;

            Assert.AreEqual(newProductCode, p.ProductCode);
            Assert.AreEqual(newProductDescription, p.ProductDescription);
            Assert.AreEqual(newProductUnitPrice, p.ProductUnitPrice);
            Assert.AreEqual(newProductOnHandQuantity, p.ProductOnHandQuantity);
        }

        #region Test Product Setters
        [Test]
        public void TestSettersProductCode()
        {
            p.ProductCode= "ABC123";
            Assert.AreNotEqual("RD101", p.ProductCode, "The setter for Product Code did not work; the Product Code is unchanged.");
            Assert.AreEqual("ABC123", p.ProductCode, "The setter for Product Code did not work; the Product Code did not change to the expected value.");
        }

        [Test]
        public void TestSettersProductCodeTooShort()
        {     
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode= "            ");
        }

        [Test]
        public void TestSettersProductCodeTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "01234567890");
        }

        [Test]
        public void TestSettersProductDescription()
        {
            p.ProductDescription = "Large green apple. Crisp. Tart.";
            Assert.AreNotEqual("Medium red apple. Grainy. Sweet.", p.ProductDescription);
            Assert.AreEqual("Large green apple. Crisp. Tart.", p.ProductDescription);
        }

        [Test]
        public void TestSettersProductDescriptionTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductDescription = "            ");
        }

        [Test]
        public void TestSettersDescriptionTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductDescription = "012345678901234567890123456789012345678901234567890123456789");
        }

        [Test]
        public void TestSettersProductUnitPrice()
        {
            p.ProductUnitPrice = 234;
            Assert.AreNotEqual(1, p.ProductUnitPrice);
            Assert.AreEqual(234, p.ProductUnitPrice);
        }

        [Test]
        public void TestSettersProductOnHandQuantity()
        {
            p.ProductOnHandQuantity = 120;
            Assert.AreNotEqual(60, p.ProductOnHandQuantity);
            Assert.AreEqual(120, p.ProductOnHandQuantity);
        }
        #endregion

        [Test]
        public void TestSettersInvalidValueTryCatch()
        {
            try
            {
                p.ProductCode = "01234567890";
                p.ProductDescription = "012346578901234657890123465789012346578901234657890123465789";
                p.ProductUnitPrice = -1;
                p.ProductOnHandQuantity = -1;
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
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "01234567890");
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductDescription = "012346578901234657890123465789012346578901234657890123465789");
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductUnitPrice = -1);
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductOnHandQuantity = -1);
        }

        [Test]
        public void TestProductToString()
        {
            Product product1 = new Product("GS908", "Large green apple. Crisp. Tart.", 2, 40);
            Assert.IsTrue(product1.ToString().Contains("GS908"));
            Assert.IsTrue(product1.ToString().Contains("Large green apple. Crisp. Tart."));
            Assert.IsTrue(product1.ToString().Contains("2"));
            Assert.IsTrue(product1.ToString().Contains("40"));
        }


    }
}
