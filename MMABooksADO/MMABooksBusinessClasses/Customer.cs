﻿using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipcode;

        public int CustomerID {
            get 
            {
                return customerID;
            }
            set
            {
                if (value > 0)
                    customerID = value;
                else
                    throw new ArgumentOutOfRangeException("Customer ID must be a positive integer.");
            } 
        }

        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                    name = value;
                else
                    throw new ArgumentOutOfRangeException("Name must be at least 1 character and no more than 100 characters long.");
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                    address = value;
                else
                    throw new ArgumentOutOfRangeException("Address must be at least 1 character and no more than 50 characters long.");
            } 
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 20)
                    city = value;
                else
                    throw new ArgumentOutOfRangeException("City must be at least 1 character and no more than 20 characters long.");
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (value.Trim().Length == 2)
                    state = value;
                else
                    throw new ArgumentOutOfRangeException("State must be exactly two characters long");
            }
        }

        public string ZipCode {
            get
            {
                return zipcode;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 15)
                    zipcode = value;
                else
                    throw new ArgumentOutOfRangeException("Zipcode must be at least 1 character and no more than 15 characters long.");
            }
        }

        public override string ToString() => CustomerID + ", " + Name + ", " + Address + ", " + City + ", " + State + ", " + ZipCode;
    }
}
