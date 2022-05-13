using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShop.Models;
using System.Data.SqlClient;

namespace FoodShop.Data
{
    public class FoodDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoodDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // String used to tonnect to the database to perform data manipulation.

        public List<FoodModel> GetAll()
        {
            List<FoodModel> returnList = new List<FoodModel>();

            // Access the database.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Food";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        // Create a new food object. Add it to the list to return.

                        FoodModel food = new FoodModel();

                        food.Id = reader.GetInt32(0);
                        food.Name = reader.GetString(1);
                        food.Price = reader.GetDecimal(2);
                        food.Vegetarian = reader.GetBoolean(3);
                        food.Vegan = reader.GetBoolean(3);
                        food.GlutenFree = reader.GetBoolean(3);

                        returnList.Add(food);
                    }
                }
            }
            return returnList;
        }


        public FoodModel GetOne(int Id)
        {
            FoodModel food = new FoodModel();

            // Access the database.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Food WHERE Id = @Id";
                // Associate @Id with parameter.

                SqlCommand command = new SqlCommand(sqlQuery,connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Create a new food object. Add it to the list to return.

                        food.Id = reader.GetInt32(0);
                        food.Name = reader.GetString(1);
                        food.Price = reader.GetDecimal(2);
                        food.Vegetarian = reader.GetBoolean(3);
                        food.Vegan = reader.GetBoolean(3);
                        food.GlutenFree = reader.GetBoolean(3);
                    }
                }
            }
            return food;
        }

        public int Create(FoodModel foodModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO dbo.Food VALUES (@Name, @Price, @Vegetarian, @Vegan, @GlutenFree)";

                SqlCommand command = new SqlCommand(sqlQuery,connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = foodModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = foodModel.Name;
                command.Parameters.Add("@Price", System.Data.SqlDbType.Money).Value = foodModel.Price;
                command.Parameters.Add("@Vegetarian", System.Data.SqlDbType.Bit).Value = foodModel.Vegetarian;
                command.Parameters.Add("@Vegan", System.Data.SqlDbType.Bit).Value = foodModel.Vegan;
                command.Parameters.Add("@GlutenFree", System.Data.SqlDbType.Bit).Value = foodModel.GlutenFree;

                connection.Open();
                int newID = command.ExecuteNonQuery();
                return newID;
            }
        }

        public int Update(FoodModel foodModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE dbo.Food SET " +
                    "Name  = @Name, " +
                    "Price = @Price, " +
                    "Vegetarian = @Vegetarian, " +
                    "Vegan = @Vegan, " +
                    "GlutenFree = @GlutenFree, " +
                    "WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = foodModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = foodModel.Name;
                command.Parameters.Add("@Price", System.Data.SqlDbType.Money).Value = foodModel.Price;
                command.Parameters.Add("@Vegetarian", System.Data.SqlDbType.Bit).Value = foodModel.Vegetarian;
                command.Parameters.Add("@Vegan", System.Data.SqlDbType.Bit).Value = foodModel.Vegan;
                command.Parameters.Add("@GlutenFree", System.Data.SqlDbType.Bit).Value = foodModel.GlutenFree;

                connection.Open();
                int newId = command.ExecuteNonQuery();
                return newId;
            }
        }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM dbo.Food WHERE ID = @Id";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery,connection);
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();
                int deletedId = sqlCommand.ExecuteNonQuery();
                return deletedId;
            }
        }

        public List<FoodModel> SearchForName(string searchPhrase)
        {
            List<FoodModel> returnList = new List<FoodModel>();

            // Access the database.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Food WHERE NAME LIKE @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery,connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Create a new food object. Add it to the list to return.
                        FoodModel food = new FoodModel();
                        food.Id = reader.GetInt32(0);
                        food.Name = reader.GetString(1);
                        food.Price = reader.GetDecimal(2);
                        food.Vegetarian = reader.GetBoolean(3);
                        food.Vegan = reader.GetBoolean(3);
                        food.GlutenFree = reader.GetBoolean(3);

                        returnList.Add(food);
                    }
                }
            }
            return returnList;
        }

    }
}