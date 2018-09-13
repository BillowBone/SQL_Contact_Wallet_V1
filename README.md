# SQL_Contact_Wallet_V1
Program that manage a contact wallet with SQL Server 2017 in a terminal console

The database contains 2 tables :

Contact :
  -[PK] id
  -[FK] id of the society
  -title
  -surname
  -name
  -function (can be NULL)
  
Society :
  -[PK] id
  -name of the society
  -address
  -second address (can be NULL)
  -postal code
  -city
  -standard (can be NULL)
  
  All SQL and database settings are in the Constants.cs class
