using System;
using System.Data;
using System.Data.SqlClient;

namespace Annuaire_V1
{
    public class Contact
    {
        //Returns true if it finds the contact's ID in the table
        public static bool Exists(int contact_id, DataSet my_dataset)
        {
            for (int i = 0; i < my_dataset.Tables[Constants.Contact_table].Rows.Count; i++)
            {
                if ((int)my_dataset.Tables[Constants.Contact_table].Rows[i][0] == contact_id)
                    return (true);
            }
            return (false);
        }

        //Displays the table after modification
        public static void ShowUpdate(DataSet my_dataset, SqlDataAdapter contact_adapter)
        {
            Console.WriteLine("\nIt's updated :");
            my_dataset.Clear();
            contact_adapter.Fill(my_dataset, Constants.Contact_table);
            Display.Table(my_dataset, 1);
        }

        //Takes a whole dataset with the row's indice of a contact and returns its full name like {name surname}
        public static string GetContactFullName(int indice, DataSet my_dataset)
        {
            string full_name = my_dataset.Tables[Constants.Contact_table].Rows[indice][4] + " "
                                    + my_dataset.Tables[Constants.Contact_table].Rows[indice][3];

            return (full_name);
        }

        //Returns the full name of a contact thanks to his ID
        //Not Used in this code but can be usefull in case of a third table
        static string GetContactNameByID(int contact_id, DataSet my_dataset)
        {
            for (int i = 0; i < my_dataset.Tables[Constants.Contact_table].Rows.Count; i++)
            {
                if ((int)my_dataset.Tables[Constants.Contact_table].Rows[i][0] == contact_id)
                    return (GetContactFullName(i, my_dataset));
            }
            return (null);
        }

        //Returns the indice of a contact in the table thanks to his ID
        public static int FindContactByID(int contact_id, DataSet my_dataset)
        {
            for (int i = 0; i < my_dataset.Tables[Constants.Contact_table].Rows.Count; i++)
            {
                if ((int)my_dataset.Tables[Constants.Contact_table].Rows[i][0] == contact_id)
                    return (i);
            }
            return (-1);
        }

        //Add a new row to the contact table
        public static void Add(SqlDataAdapter contact_adapter, DataSet my_dataset)
        {
            DataRow my_data_row = null;
            int nb = 0;

            my_data_row = my_dataset.Tables[Constants.Contact_table].NewRow();
            Console.Write("\nEnter the ID of the society : ");
            Int32.TryParse(Console.ReadLine(), out nb);
            my_data_row["idSociete"] = nb;
            Console.Write("\nEnter the title : ");
            my_data_row["civilite"] = Console.ReadLine();
            Console.Write("\nEnter the surname : ");
            my_data_row["nom"] = Console.ReadLine();
            Console.Write("\nEnter the name : ");
            my_data_row["prenom"] = Console.ReadLine();
            Console.Write("\nEnter the function : ");
            my_data_row["fonction"] = Console.ReadLine();
            my_dataset.Tables[Constants.Contact_table].Rows.Add(my_data_row);
            contact_adapter.Update(my_dataset, Constants.Contact_table);
        }

        //Delete a row from the contact table thanks to its ID
        private static bool Delete(SqlDataAdapter contact_adapter, DataSet my_dataset)
        {
            int contact_id = 0;
            int contact_indice = 0;

            Console.Write("Enter the ID of the contact you want to delete : ");
            Int32.TryParse(Console.ReadLine(), out contact_id);
            contact_indice = FindContactByID(contact_id, my_dataset);
            if (contact_indice != -1) {
                my_dataset.Tables[Constants.Contact_table].Rows[contact_indice].Delete();
                contact_adapter.Update(my_dataset, Constants.Contact_table);
                return (true);
            } else {
                Console.WriteLine("\nThere is no contact with this ID in the database !");
                return (false);
            }
        }

        //Function that controls if the delete is effective or not
        public static void ControlDelete(SqlDataAdapter contact_adapter, DataSet my_dataset)
        {
            Display.Table(my_dataset, 1);
            if (Delete(contact_adapter, my_dataset))
                ShowUpdate(my_dataset, contact_adapter);
        }

        //Update a row from the contact table thank to its ID
        private static bool Update(SqlDataAdapter contact_adapter, DataSet my_dataset)
        {
            int contact_id = 0;
            int contact_indice = 0;
            int nb = 0;

            Console.Write("Enter the ID of the contact you want to update : ");
            Int32.TryParse(Console.ReadLine(), out contact_id);
            contact_indice = FindContactByID(contact_id, my_dataset);
            if (contact_indice != -1) {
                Console.Write("\nEnter the ID of the society : ");
                Int32.TryParse(Console.ReadLine(), out nb);
                my_dataset.Tables[Constants.Contact_table].Rows[contact_indice][1] = nb;
                Console.Write("\nEnter the title : ");
                my_dataset.Tables[Constants.Contact_table].Rows[contact_indice][2] = Console.ReadLine();
                Console.Write("\nEnter the surname : ");
                my_dataset.Tables[Constants.Contact_table].Rows[contact_indice][3] = Console.ReadLine();
                Console.Write("\nEnter the name : ");
                my_dataset.Tables[Constants.Contact_table].Rows[contact_indice][4] = Console.ReadLine();
                Console.Write("\nEnter the function : ");
                my_dataset.Tables[Constants.Contact_table].Rows[contact_indice][5] = Console.ReadLine();
                contact_adapter.Update(my_dataset, Constants.Contact_table);
                return (true);
            } else {
                Console.WriteLine("\nThere is no contact with this ID in the database !");
                return (false);
            }
        }

        //Function that controls if the update is effective or not
        public static void ControlUpdate(SqlDataAdapter contact_adapter, DataSet my_dataset)
        {
            Display.Table(my_dataset, 1);
            if (Update(contact_adapter, my_dataset))
                ShowUpdate(my_dataset, contact_adapter);
        }
    }
}
