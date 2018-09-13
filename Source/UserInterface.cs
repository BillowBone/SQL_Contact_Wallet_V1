using System;
using System.Data;
using System.Data.SqlClient;

namespace Annuaire_V1
{
    class UserInterface
    {
        //Function that asks the user to choose an option
        private static int UserChoose(int limit)
        {
            int choice = 0;

            do
            {
                Console.Write("Your choice : ");
                Int32.TryParse(Console.ReadLine(), out choice);
                if (choice < 1 || choice > limit)
                    Console.WriteLine("You have to choose between 1 and " + limit + " !");
            } while (choice < 1 || choice > limit);
            return (choice);
        }

        //Function that asks the user to select a contact or society ID
        private static int UserChooseID(DataSet my_dataset, string table)
        {
            int id = 0;

            Console.Write("\n");
            do
            {
                Console.Write("Select a " + table + " ID : ");
                Int32.TryParse(Console.ReadLine(), out id);
                if (!Contact.Exists(id, my_dataset) && table == "contact")
                    Console.WriteLine("There is no " + table + " with this ID in the database !");
                if (!Society.Exists(id, my_dataset) && table == "society")
                    Console.WriteLine("There is no " + table + " with this ID in the database !");
                if (Contact.Exists(id, my_dataset) && table == "contact")
                    break;
                if (Society.Exists(id, my_dataset) && table == "society")
                    break;
            } while (1 == 1);
            Console.Write("\n");
            return (id);
        }

        //Call the appropriate function for each choice on the contact's table options
        private static void ContactChoice(DataSet my_dataset, SqlDataAdapter contact_adapter, int choice)
        {
            switch (choice)
            {
                case 1:
                    Display.Table(my_dataset, 1);
                    break;
                case 2:
                    Contact.Add(contact_adapter, my_dataset);
                    Contact.ShowUpdate(my_dataset, contact_adapter);
                    break;
                case 3:
                    Contact.ControlUpdate(contact_adapter, my_dataset);
                    break;
                case 4:
                    Contact.ControlDelete(contact_adapter, my_dataset);
                    break;
                case 5:
                    Display.Table(my_dataset, 1);
                    Console.WriteLine("\nThis contact works at {0} !", Society.GetSocietyNameByContactID(UserChooseID(my_dataset, "contact"), my_dataset));
                    break;
            }
        }

        //Display the list of actions the user can execute with the contact table
        private static void ContactPossibilities(DataSet my_dataset, SqlDataAdapter contact_adapter)
        {
            int choice = 0;

            Console.WriteLine("\nHere are the actions you can execute with your contacts table :");
            Console.Write("\n\tDisplay the table of contacts : 1");
            Console.Write("\n\tAdd a new contact : 2");
            Console.Write("\n\tUpdate an existing contact : 3");
            Console.Write("\n\tDelete an existing contact : 4");
            Console.Write("\n\tDisplay the name of a society thanks to a contact ID : 5\n\n");
            choice = UserChoose(5);
            ContactChoice(my_dataset, contact_adapter, choice);
        }

        //Call the appropriate function for each choice on the society's table options
        private static void SocietyChoice(DataSet my_dataset, SqlDataAdapter society_adapter, int choice)
        {
            switch (choice)
            {
                case 1:
                    Display.Table(my_dataset, 2);
                    break;
                case 2:
                    Society.Add(society_adapter, my_dataset);
                    Society.ShowUpdate(my_dataset, society_adapter);
                    break;
                case 3:
                    Society.ControlUpdate(society_adapter, my_dataset);
                    break;
                case 4:
                    Society.ControlDelete(society_adapter, my_dataset);
                    break;
                case 5:
                    Display.Table(my_dataset, 2);
                    Society.DisplayContactsBySocietyID(UserChooseID(my_dataset, "society"), my_dataset);
                    break;
                case 6:
                    Display.Table(my_dataset, 2);
                    Console.WriteLine("There is {0} contact(s) working here !", Society.CountContactsInSociety(UserChooseID(my_dataset, "society"), my_dataset));
                    break;
            }
        }

        //Display the list of actions the user can execute with the society table
        private static void SocietyPossibilities(DataSet my_dataset, SqlDataAdapter society_adapter)
        {
            int choice = 0;

            Console.WriteLine("\nHere are the actions you can execute with your societies table :");
            Console.Write("\n\tDisplay the table of societies : 1");
            Console.Write("\n\tAdd a new society : 2");
            Console.Write("\n\tUpdate an existing society : 3");
            Console.Write("\n\tDelete an existing society : 4");
            Console.Write("\n\tDisplay the list of all the contacts working in a given society : 5");
            Console.Write("\n\tDisplay the number of contacts working in a given society : 6\n\n");
            choice = UserChoose(6);
            SocietyChoice(my_dataset, society_adapter, choice);
        }

        //First interaction with the user, first he has to choose rather if he wants to interact with the contact table or the society table
        public static void Welcome(DataSet my_dataset, SqlDataAdapter contact_adapter, SqlDataAdapter society_adapter)
        {
            int choice = 0;

            Console.WriteLine("Hello and welcome to your contact wallet\n");
            Console.WriteLine("Please choose the table you want to interact with :");
            Console.WriteLine("\n\tContacts : 1\n\tSocieties : 2\n");
            choice = UserChoose(2);
            if (choice == 1)
                ContactPossibilities(my_dataset, contact_adapter);
            else if (choice == 2)
                SocietyPossibilities(my_dataset, society_adapter);
        }
    }
}
