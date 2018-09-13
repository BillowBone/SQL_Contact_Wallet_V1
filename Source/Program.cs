using System;
using System.Data;
using System.Data.SqlClient;

namespace Annuaire_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection my_connection = new SqlConnection(Constants.Connection);
            SqlDataAdapter contact_adapter = Initialize.ContactAdapter(my_connection);
            SqlDataAdapter society_adapter = Initialize.SocietyAdapter(my_connection);
            DataSet my_dataset = new DataSet(Constants.Contact_table);

            my_connection.Open();
            contact_adapter.Fill(my_dataset, Constants.Contact_table);
            society_adapter.Fill(my_dataset, Constants.Society_table);
            UserInterface.Welcome(my_dataset, contact_adapter, society_adapter);
            my_connection.Close();
            Console.ReadLine();
        }
    }
}
