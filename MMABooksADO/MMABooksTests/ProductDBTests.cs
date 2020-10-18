using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("A4CS", p.ProductCode, "Could not find product in database with product code \'A4CS\' to match against.");
        }

        [Test]
        public void TestAddProduct()
        {
            /*Create the test variables.*/
            Product p = new Product();
            p.ProductCode = "AAAA";
            p.ProductDescription = "A product for testing. Not intended to be removed";
            p.ProductUnitPrice = 99;
            p.ProductOnHandQuantity = 10;

            /* Test the command.*/
            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            /* If the test subject has a name within the database, the test was successful. */
            Assert.AreEqual("AAAA", p.ProductCode);
            /*Clean up the test*/
           ProductDB.DeleteProduct(p);
        }

        [Test]
        public void TestDeleteProduct()
        {
            /*Create the test variables.*/
            Product p = new Product();
            p.ProductCode = "AAAA";
            p.ProductDescription = "A product for the purposes of testing.";
            p.ProductUnitPrice = 99;
            p.ProductOnHandQuantity = 10;
            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);

            /* Test the command.*/
            bool isProductDeleted = ProductDB.DeleteProduct(p);
            /* If it affected the database in some way, the test was successful. */
            Assert.AreEqual(true, isProductDeleted);
        }

        [Test]
        public void TestUpdateProduct()
        {
            /*Create the test variables.*/
            Product oldProduct = new Product();
            oldProduct.ProductCode = "AAAA";
            oldProduct.ProductDescription = "A product for the purposes of testing.";
            oldProduct.ProductUnitPrice = 99;
            oldProduct.ProductOnHandQuantity = 10;
            string ProductCode = ProductDB.AddProduct(oldProduct);
            oldProduct = ProductDB.GetProduct(ProductCode);

            Product newProduct = new Product();
            newProduct.ProductDescription = "Another product for the purposes of testing.";
            newProduct.ProductUnitPrice = 49;
            newProduct.ProductOnHandQuantity = 20;


            /* Test the command.*/
            bool isProductUpdated = ProductDB.UpdateProduct(oldProduct, newProduct);
            /* If it affected the database in some way, the test was successful. */
            Assert.AreEqual(true, isProductUpdated);
            /* Clean up the test.*/
            newProduct = ProductDB.GetProduct(ProductCode);
            ProductDB.DeleteProduct(newProduct);
        }

        [Test]
        public void TestGetProductList()
        {
            List<Product> products = ProductDB.GetProductList();
            Assert.AreEqual("0000", products[0].ProductCode);
        }
    }
}
