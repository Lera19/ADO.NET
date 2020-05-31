using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /////Необходимо реализовать получение всех данных по таблицам Order и Customer из консольного приложения
            var orders = new List<Order>();
            var customers = new List<Customer>();
            var connectionString = ConfigurationManager.ConnectionStrings["HomeworkSQLService"].ConnectionString;
            using (SqlConnection scn = new SqlConnection())
            {
                scn.ConnectionString = connectionString;
                scn.Open();
                string selectTableCust = "Select * From customers";
                string selectTableOr = "Select * From orders";
                SqlCommand sqlCommand = new SqlCommand(selectTableOr, scn);
                SqlCommand sqlCommand1 = new SqlCommand(selectTableCust, scn);
                var dataReader1 = sqlCommand1.ExecuteReader();
                while (dataReader1.Read())
                {
                    customers.Add(new Customer((string)dataReader1[0], (string)dataReader1[1]));
                }
                dataReader1.Close();
                var dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    orders.Add(new Order((string)dataReader[0], (DateTime)dataReader[1]));
                }
                scn.Close();
            }
            customers.ForEach(Console.WriteLine);
            orders.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}