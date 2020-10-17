using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string pCode, string descr, decimal price, int quantity)
        {
            ProductCode = pCode;
            ProductDescription = descr;
            ProductUnitPrice = price;
            ProductOnHandQuantity = quantity;
        }

        private string pCode;
        private string descr;
        private decimal price;
        private int quantity;

        public string ProductCode
        {
            get
            {
                return pCode;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 10)
                    pCode = value;
                else
                    throw new ArgumentOutOfRangeException("Description must be at least 1 character and no more than 10 characters long.");
            }
        }
        public string ProductDescription
        {
            get
            {
                return descr;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                    descr = value;
                else
                    throw new ArgumentOutOfRangeException("Description must be at least 1 character and no more than 50 characters long.");
            }
        }

        public decimal ProductUnitPrice
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new ArgumentOutOfRangeException("Price must not be a negative number.");
            }
        }

        public int ProductOnHandQuantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value > 0)
                    quantity = value;
                else
                    throw new ArgumentOutOfRangeException("On-Hand Quantity must be a positive integer.");
            }
        }

        public override string ToString() => ProductCode + ", " + ProductDescription + ", " + ProductUnitPrice + ", " + ProductOnHandQuantity;
    }
}
