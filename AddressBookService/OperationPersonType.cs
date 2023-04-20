using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService
{
    public class OperationPersonType
    {
        public static string connectingstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookService; Integrated Security=true";
        SqlConnection connection =new SqlConnection(connectingstring);
        public void GetAllPersonTypeRecords()
        {
            try
            {
                AddressBookDetails addressBookDetails = new AddressBookDetails();
                using(this.connection)
                {
                    string queryP = @"select * from PersonType";
                    SqlCommand cmd= new SqlCommand(queryP,connection);
                    cmd.CommandType=CommandType.Text;
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        addressBookDetails.PersonId = reader.GetInt32(0);
                        addressBookDetails.PersonName = reader.GetString(1);
                        addressBookDetails.RelationType = reader.GetString(2);
                        addressBookDetails.Id = reader.GetInt32(3);
                        Console.WriteLine(addressBookDetails.PersonId + "\n" + addressBookDetails.PersonName + "\n" + addressBookDetails.RelationType + "\n" + addressBookDetails.Id);
                    }
                    else
                    { Console.WriteLine("No Records are AVAILABLE"); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        
    }
}
