using System;
using System.Data;
using System.Data.SqlClient;

namespace Annuaire_V1
{
    public class Society
    {
        //Returns true if it finds the society's ID in the table
        public static bool Exists(int society_id, DataSet my_dataset)
        {
            for (int i = 0; i < my_dataset.Tables[Constants.Society_table].Rows.Count; i++)
            {
                if ((int)my_dataset.Tables[Constants.Society_table].Rows[i][0] == society_id)
                    return (true);
            }
            return (false);
        }

        //Displays the table after modification
        public static void ShowUpdate(DataSet my_dataset, SqlDataAdapter society_adapter)
        {
            Console.WriteLine("\nIt's updated :");
            my_dataset.Clear();
            society_adapter.Fill(my_dataset, Constants.Society_table);
            Display.Table(my_dataset, 2);
        }

        //Returns the indice of the society in the table thanks to the id of the society
        private static int FindSocietyByID(int society_id, DataSet my_dataset)
        {
            for (int i = 0; i < my_dataset.Tables[Constants.Society_table].Rows.Count; i++)
            {
                if ((int)my_dataset.Tables[Constants.Society_table].Rows[i][0] == society_id)
                    return (i);
            }
            return (-1);
        }

        //Returns the indice of the society in the table thanks to the id of a given contact
        private static int FindSocietyByContactID(int contact_id, DataSet my_dataset)
        {
            int society_id = -1;

            for (int i = 0; i < my_dataset.Tables[Constants.Contact_table].Rows.Count; i++)
            {
                if ((int)my_dataset.Tables[Constants.Contact_table].Rows[i][0] == contact_id)
                    society_id = (int)my_dataset.Tables[Constants.Contact_table].Rows[i][1];
            }
            return (FindSocietyByID(society_id, my_dataset));
        }

        //Returns the name of a society thanks to a contact ID
        public static string GetSocietyNameByContactID(int contact_id, DataSet my_dataset)
        {
            int society_indice = FindSocietyByContactID(contact_id, my_dataset);

            if (society_indice != -1)
                return (my_dataset.Tables[Constants.Society_table].Rows[society_indice][1].ToString());
            else
                return (null);
        }

        //Return the number of contact working in a given society
        public static int CountContactsInSociety(int society_id, DataSet my_dataset)
        {
            int nb_contacts = 0;

            for (int i = 0; i < my_dataset.Tables[Constants.Contact_table].Rows.Count; i++)
            {
                if ((int)my_dataset.Tables[Constants.Contact_table].Rows[i][1] == society_id)
                    nb_contacts++;
            }
            return (nb_contacts);
        }

        //Displays the name of every contact working in the society thanks to its ID
        public static void DisplayContactsBySocietyID(int society_id, DataSet my_dataset)
        {
            if (CountContactsInSociety(society_id, my_dataset) > 0) {
                for (int i = 0; i < my_dataset.Tables[Constants.Contact_table].Rows.Count; i++)
                {
                    if ((int)my_dataset.Tables[Constants.Contact_table].Rows[i][1] == society_id)
                        Console.WriteLine(Contact.GetContactFullName(i, my_dataset) + " works here !");
                }
            } else {
                Console.WriteLine("Nobody in your contacts works here !");
            }
        }

        //Add a new row to the society table
        public static void Add(SqlDataAdapter my_sql_adapter, DataSet my_dataset)
        {
            DataRow my_data_row = null;

            my_data_row = my_dataset.Tables[Constants.Society_table].NewRow();
            Console.Write("\nEnter the name of the society : ");
            my_data_row["nom"] = Console.ReadLine();
            Console.Write("\nEnter the address : ");
            my_data_row["adresse"] = Console.ReadLine();
            Console.Write("\nEnter the second address (can be empty) : ");
            my_data_row["adresse2"] = Console.ReadLine();
            Console.Write("\nEnter the postal code : ");
            my_data_row["codePostal"] = Console.ReadLine();
            Console.Write("\nEnter the city : ");
            my_data_row["ville"] = Console.ReadLine();
            Console.Write("\nEnter the standard number : ");
            my_data_row["standard"] = Console.ReadLine();
            my_dataset.Tables[Constants.Society_table].Rows.Add(my_data_row);
            my_sql_adapter.Update(my_dataset, Constants.Society_table);
        }

        //Delete a row from the contact table thanks to its ID
        private static bool Delete(SqlDataAdapter my_sql_adapter, DataSet my_dataset)
        {
            int society_id = 0;
            int society_indice = 0;

            Console.Write("Enter the ID of the society you want to delete : ");
            Int32.TryParse(Console.ReadLine(), out society_id);
            society_indice = FindSocietyByID(society_id, my_dataset);
            if (society_indice != -1) {
                my_dataset.Tables[Constants.Society_table].Rows[society_indice].Delete();
                my_sql_adapter.Update(my_dataset, Constants.Society_table);
                return (true);
            } else {
                Console.WriteLine("\nThere is no society with this ID in the database !");
                return (false);
            }
        }

        //Function that controls if the delete is effective or not
        public static void ControlDelete(SqlDataAdapter society_adapter, DataSet my_dataset)
        {
            Display.Table(my_dataset, 2);
            if (Delete(society_adapter, my_dataset))
                ShowUpdate(my_dataset, society_adapter);
        }

        //Update a row from the contact table thank to its ID
        private static bool Update(SqlDataAdapter my_sql_adapter, DataSet my_dataset)
        {
            int society_id = 0;
            int society_indice = 0;

            Console.Write("Enter the ID of the society you want to update : ");
            Int32.TryParse(Console.ReadLine(), out society_id);
            society_indice = FindSocietyByID(society_id, my_dataset);
            if (society_indice != -1) {
                Console.Write("\nEnter the name of the society : ");
                my_dataset.Tables[Constants.Society_table].Rows[society_indice][1] = Console.ReadLine();
                Console.Write("\nEnter the address : ");
                my_dataset.Tables[Constants.Society_table].Rows[society_indice][2] = Console.ReadLine();
                Console.Write("\nEnter the second address (can be empty) : ");
                my_dataset.Tables[Constants.Society_table].Rows[society_indice][3] = Console.ReadLine();
                Console.Write("\nEnter the postal code : ");
                my_dataset.Tables[Constants.Society_table].Rows[society_indice][4] = Console.ReadLine();
                Console.Write("\nEnter the city : ");
                my_dataset.Tables[Constants.Society_table].Rows[society_indice][5] = Console.ReadLine();
                Console.Write("\nEnter the standard number : ");
                my_dataset.Tables[Constants.Society_table].Rows[society_indice][6] = Console.ReadLine();
                my_sql_adapter.Update(my_dataset, Constants.Society_table);
                return (true);
            } else {
                Console.WriteLine("\nThere is no society with this ID in the database !");
                return (false);
            }
        }

        //Function that controls if the update is effective or not
        public static void ControlUpdate(SqlDataAdapter society_adapter, DataSet my_dataset)
        {
            Display.Table(my_dataset, 2);
            if (Update(society_adapter, my_dataset))
                ShowUpdate(my_dataset, society_adapter);
        }
    }
}