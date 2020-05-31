using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /////Создать хранимую процедуру с входящим параметром «Дата».+ Процедура возвращает все заказы, сделанные в этот день.Вызвать процедуру срерствами ADO.NET.
            var orders = new List<Order>();
            var connectionString = ConfigurationManager.ConnectionStrings["HomeworkSQLService"].ConnectionString;
            using (SqlConnection scn = new SqlConnection())
            {
                scn.ConnectionString = connectionString;
                scn.Open();

                SqlCommand sqlCommand = new SqlCommand("PROC_TEST6", scn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@Date", SqlDbType.Date);
                sqlCommand.Parameters["@Date"].Value = "2016/08/13";

                var dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine($"Order number {dataReader[0]} order_date {dataReader[1]}, {dataReader[2]}");
                }

                scn.Close();
            }
            orders.ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}