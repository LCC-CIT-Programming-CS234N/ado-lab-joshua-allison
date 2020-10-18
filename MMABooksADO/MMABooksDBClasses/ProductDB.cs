using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = custReader["ProductCode"].ToString();
                    product.ProductDescription = custReader["Description"].ToString();
                    product.ProductUnitPrice = (decimal)custReader["UnitPrice"];
                    product.ProductOnHandQuantity = (int)custReader["OnHandQuantity"];
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue(
                "@Description", product.ProductDescription);
            insertCommand.Parameters.AddWithValue(
                "@UnitPrice", product.ProductUnitPrice);
            insertCommand.Parameters.AddWithValue(
                "@OnHandQuantity", product.ProductOnHandQuantity);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();

                string selectStatement =
                    "SELECT * FROM products WHERE ProductCode = \'" + product.ProductCode + "\'";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);

                string resultProductCode = selectCommand.ExecuteScalar().ToString();
                return resultProductCode;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct(Product product)
        {
            // get a connection to the database
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @ProductDescription " +
                "AND UnitPrice = @ProductUnitPrice " +
                "AND OnHandQuantity = @ProductOnHandQuantity";

            // set up the command object
            MySqlCommand deleteCommand =
                new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ProductCode", product.ProductCode);
            deleteCommand.Parameters.AddWithValue(
                "@ProductDescription", product.ProductDescription);
            deleteCommand.Parameters.AddWithValue(
                "@ProductUnitPrice", product.ProductUnitPrice);
            deleteCommand.Parameters.AddWithValue(
                "@ProductOnHandQuantity", product.ProductOnHandQuantity);

            try
            {
                // open the connection
                connection.Open();
                // execute the command
                int deleteCommandReturn = deleteCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
                if (deleteCommandReturn == 1)
                    return true;
                /* I believe the 'return false' in the comment above refers to the 'return false' below, so I will leave that there, and not type 'else return false' above.*/
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }

            return false;
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            // create a connection
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "Description = @newDescription, " +
                "UnitPrice = @newUnitPrice, " +
                "OnHandQuantity = @newOnHandQuantity " +
                "WHERE ProductCode = @oldProductCode " +
                "AND Description = @oldDescription " +
                "AND UnitPrice = @oldUnitPrice " +
                "AND OnHandQuantity = @oldOnHandQuantity";
            // setup the command object
            MySqlCommand updateCommand =
                new MySqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@newDescription", newProduct.ProductDescription);
            updateCommand.Parameters.AddWithValue(
                "@newUnitPrice", newProduct.ProductUnitPrice);
            updateCommand.Parameters.AddWithValue(
                "@newOnHandQuantity", newProduct.ProductOnHandQuantity);
            updateCommand.Parameters.AddWithValue(
                "@oldProductCode", oldProduct.ProductCode);
            updateCommand.Parameters.AddWithValue(
                "@oldDescription", oldProduct.ProductDescription);
            updateCommand.Parameters.AddWithValue(
                "@oldUnitPrice", oldProduct.ProductUnitPrice);
            updateCommand.Parameters.AddWithValue(
                "@oldOnHandQuantity", oldProduct.ProductOnHandQuantity);
            try
            {
                // open the connection
                connection.Open();
                // execute the command
                int updateCommandReturn = updateCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
                if (updateCommandReturn == 1)
                    return true;
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }

            return false;
        }

        public static List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement = "SELECT ProductCode, Description "
                                   + "FROM products "
                                   + "ORDER BY ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductCode = reader["ProductCode"].ToString();
                    p.ProductDescription = reader["Description"].ToString();
                    products.Add(p);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return products;
        }


    }
}
