using System.Data;
using System.Data.SqlClient;

namespace Annuaire_V1
{
    public class Initialize
    {
        /*Initialize all the commands and parameters that will be needed to interact with the contact table
        Build the SQL data adapter for the contact table and returns it*/
        public static SqlDataAdapter ContactAdapter(SqlConnection my_connection)
        {
            SqlDataAdapter contact_adapter = new SqlDataAdapter(Constants.Select_contact, my_connection);

            contact_adapter.InsertCommand = new SqlCommand(Constants.Insert_contact, my_connection);
            contact_adapter.InsertCommand.Parameters.Add("@idSociete", SqlDbType.Int, 15, "idSociete");
            contact_adapter.InsertCommand.Parameters.Add("@civilite", SqlDbType.NVarChar, 100, "civilite");
            contact_adapter.InsertCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 100, "nom");
            contact_adapter.InsertCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 100, "prenom");
            contact_adapter.InsertCommand.Parameters.Add("@fonction", SqlDbType.NVarChar, 100, "fonction");
            contact_adapter.DeleteCommand = new SqlCommand(Constants.Delete_contact, my_connection);
            contact_adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 15, "id");
            contact_adapter.UpdateCommand = new SqlCommand(Constants.Update_contact, my_connection);
            contact_adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 15, "id");
            contact_adapter.UpdateCommand.Parameters.Add("@idSociete", SqlDbType.Int, 15, "idSociete");
            contact_adapter.UpdateCommand.Parameters.Add("@civilite", SqlDbType.NVarChar, 100, "civilite");
            contact_adapter.UpdateCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 100, "nom");
            contact_adapter.UpdateCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 100, "prenom");
            contact_adapter.UpdateCommand.Parameters.Add("@fonction", SqlDbType.NVarChar, 100, "fonction");
            return (contact_adapter);
        }

        /*Initialize all the commands and parameters that will be needed to interact with the society table
        Build the SQL data adapter for the society table and returns it*/
        public static SqlDataAdapter SocietyAdapter(SqlConnection my_connection)
        {
            SqlDataAdapter society_adapter = new SqlDataAdapter(Constants.Select_society, my_connection);

            society_adapter.InsertCommand = new SqlCommand(Constants.Insert_society, my_connection);
            society_adapter.InsertCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 100, "nom");
            society_adapter.InsertCommand.Parameters.Add("@adresse", SqlDbType.NVarChar, 100, "adresse");
            society_adapter.InsertCommand.Parameters.Add("@adresse2", SqlDbType.NVarChar, 100, "adresse2");
            society_adapter.InsertCommand.Parameters.Add("@codePostal", SqlDbType.NVarChar, 100, "codePostal");
            society_adapter.InsertCommand.Parameters.Add("@ville", SqlDbType.NVarChar, 100, "ville");
            society_adapter.InsertCommand.Parameters.Add("@standard", SqlDbType.NVarChar, 100, "standard");
            society_adapter.DeleteCommand = new SqlCommand(Constants.Delete_society, my_connection);
            society_adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 15, "id");
            society_adapter.UpdateCommand = new SqlCommand(Constants.Update_society, my_connection);
            society_adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 15, "id");
            society_adapter.UpdateCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 100, "nom");
            society_adapter.UpdateCommand.Parameters.Add("@adresse", SqlDbType.NVarChar, 100, "adresse");
            society_adapter.UpdateCommand.Parameters.Add("@adresse2", SqlDbType.NVarChar, 100, "adresse2");
            society_adapter.UpdateCommand.Parameters.Add("@codePostal", SqlDbType.NVarChar, 100, "codePostal");
            society_adapter.UpdateCommand.Parameters.Add("@ville", SqlDbType.NVarChar, 100, "ville");
            society_adapter.UpdateCommand.Parameters.Add("@standard", SqlDbType.NVarChar, 100, "standard");
            return (society_adapter);
        }
    }
}
