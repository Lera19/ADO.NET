using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /////Сделать отдельное представление «Информация о заказе»: внутри должна быть информация о заказе: место, поставщик, покупатель.+Представление создаете в БД, через ADO.Net обращаетесь уже к созданному объекту
            var waybills = new List<Waybill>();
            var connectionString = ConfigurationManager.ConnectionStrings["HomeworkSQLService"].ConnectionString;

            var view = "SELECT * FROM Informations";
            SqlDataAdapter adapter = new SqlDataAdapter(view, connectionString);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable depTable = dataSet.Tables[0];

            Console.WriteLine("Information");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                waybills.Add(new Waybill((int)row[0], (string)row[1], (string)row[2], (string)row[3]));
            }
            waybills.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}