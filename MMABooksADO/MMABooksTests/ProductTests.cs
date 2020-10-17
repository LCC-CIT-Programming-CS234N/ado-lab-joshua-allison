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
            p = new Product("JA94", "Six feet, two inches. 180lbs. Bald.", 5, 1);
        }

        [Test]
        public void TestProductConstructor()
        {
            //Below, you will see that the arguments for ProductUnitPrice and ProductOnHandQuantity are not "null". This is because when I tested it, the tester said that for price it was expecting 0m, and for quantity, it was expecting 0. I didn't know types had different default values. Experiencing this makes me believe that strings are null if constructed by default, ints are 0 by default, and decimals are 0m by default. I'm not really sure how accurate any of this is, but at least I can explain why null is not used for price and quantity.
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.ProductDescription);
            Assert.AreEqual(0m, def.ProductUnitPrice);
            Assert.AreEqual(0, def.ProductOnHandQuantity);

            Assert.IsNotNull(p);
            Assert.AreNotEqual(null, p.ProductCode);
            Assert.AreEqual("JA94", p.ProductCode);
            Assert.AreNotEqual(null, p.ProductDescription);
            Assert.AreNotEqual(0m, p.ProductUnitPrice);
            Assert.AreNotEqual(0, p.ProductOnHandQuantity);
        }
    }
}
