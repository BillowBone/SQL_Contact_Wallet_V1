using System;
using System.Data;

namespace Annuaire_V1
{
    public class Display
    {
        //Returns the right header depending on the type of the table
        private static string GetTableHeader(int option)
        {
            if (option == 1)
                return ("\n\tID\t\tID_Société\tCivilité\tNom\t\tPrénom\t\tFonction\n");
            else if (option == 2)
                return ("\n\tID\t\tNom\t\tAdresse\t\tAdresse2\tCode Postal\tVille\t\tStandard\n");
            else
                return (null);
        }

        //Returns the limit of each type of table
        private static int GetTableLimit(int option)
        {
            if (option == 1)
                return (6);
            else if (option == 2)
                return (7);
            else
                return (0);
        }

        //Returns the right contant value depending on the type of the table
        private static string GetTableName(int option)
        {
            if (option == 1)
                return (Constants.Contact_table);
            else if (option == 2)
                return (Constants.Society_table);
            else
                return (null);
        }

        //Displays a given table option is for the type of the table : 1 for a contact and 2 for a society
        public static void Table(DataSet my_dataset, int option)
        {
            int len = 0;

            Console.WriteLine(GetTableHeader(option));
            for (int i = 0; i < my_dataset.Tables[GetTableName(option)].Rows.Count; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < GetTableLimit(option); j++)
                {
                    len = StringLib.GetStringLenght(my_dataset.Tables[GetTableName(option)].Rows[i][j].ToString());
                    if (len >= 16)
                        Console.Write(my_dataset.Tables[GetTableName(option)].Rows[i][j].ToString());
                    else if (len >= 8)
                        Console.Write("{0}\t", my_dataset.Tables[GetTableName(option)].Rows[i][j].ToString());
                    else
                        Console.Write("{0}\t\t", my_dataset.Tables[GetTableName(option)].Rows[i][j].ToString());
                }
                Console.Write("\n");
            }
            Console.WriteLine("\n");
        }
    }
}
