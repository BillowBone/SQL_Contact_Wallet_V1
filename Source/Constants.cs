namespace Annuaire_V1
{
    //All SQL server settings are here
    static class Constants
    {
        public const string Source = "localhost";
        public const string Db_name = "Annuaire";
        public const string Connection = "Data Source=" + Source + "; Integrated Security=SSPI; Initial Catalog=" + Db_name;
        public const string Contact_table = "contact";
        public const string Society_table = "societe";
        public const string Select_contact = "SELECT * FROM " + Contact_table;
        public const string Select_society = "SELECT * FROM " + Society_table;
        public const string Insert_contact = "INSERT INTO " + Contact_table + "(idSociete, civilite, nom, prenom, fonction) Values(@idSociete, @civilite, @nom, @prenom, @fonction)";
        public const string Insert_society = "INSERT INTO " + Society_table + "(nom, adresse, adresse2, codePostal, ville, standard) Values(@nom, @adresse, @adresse2, @codePostal, @ville, @standard)";
        public const string Delete_contact = "DELETE FROM " + Contact_table + " WHERE id=@id";
        public const string Delete_society = "DELETE FROM " + Society_table + " WHERE id=@id";
        public const string Update_contact = "UPDATE " + Contact_table + " SET idSociete=@idSociete, civilite=@civilite, nom=@nom, prenom=@prenom, fonction=@fonction WHERE id=@id";
        public const string Update_society = "UPDATE " + Society_table + " SET nom=@nom, adresse=@adresse, adresse2=@adresse2, codePostal=@codePostal, ville=@ville, standard=@standard WHERE id=@id";
    }
}
