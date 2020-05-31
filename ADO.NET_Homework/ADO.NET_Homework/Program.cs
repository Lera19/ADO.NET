using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO.NET_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Осуществить несколько операций вставки/удаления из консольного приложения к любой таблице существующей БД.
            var orders = new List<Order>();
            var connectionString = ConfigurationManager.ConnectionStrings["HomeworkSQLService"].ConnectionString;

            using (SqlConnection scn = new SqlConnection())
            {
                scn.ConnectionString = connectionString;
                scn.Open();

                var insertOrder = "INSERT INTO orders(order_id, order_date) VALUES(4, '14.08.2016');" +
                                  "INSERT INTO orders(order_id,order_date) VALUES (5,'14.09.2016');" +
                                  "INSERT INTO orders(order_id,order_date) VALUES (6,'14.10.2016')" +
                                  "DELETE FROM orders WHERE order_id=4;" +
                                  "DELETE FROM orders WHERE order_id=5;" +
                                  "DELETE FROM orders WHERE order_id=6;";

                SqlCommand sqlCommand = new SqlCommand(insertOrder, scn);
                var newOrder = sqlCommand.ExecuteNonQuery();
                Console.WriteLine(newOrder);
                sqlCommand.CommandText = "SELECT * FROM orders";
                var dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    orders.Add(new Order((string)dataReader[0], (DateTime)dataReader[1]));
                }

                scn.Close();
            }
            orders.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}