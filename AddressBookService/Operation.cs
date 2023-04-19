using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService
{
    public class Operation
    {
        public static string Connectingstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookService; Integrated Security=true";
        SqlConnection connection = new SqlConnection(Connectingstring);
        public void GetAllAddressBookRecords()
        {
            try
            {
                AddressBookDetails addressBookDetails = new AddressBookDetails();
                using(this.connection)
                {
                    string query = @"select * from AddressBook";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.Text;
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        addressBookDetails.PersonId = reader.GetInt32(0);
                        addressBookDetails.Firstname = reader.GetString(1);
                        addressBookDetails.Lastname = reader.GetString(2);
                        addressBookDetails.Address = reader.GetString(3);
                        addressBookDetails.City = reader.GetString(4);
                        addressBookDetails.State = reader.GetString(5);
                        addressBookDetails.ZipCode = (int)reader.GetInt64(6);
                        addressBookDetails.PHNO = reader.GetString(7);
                        addressBookDetails.EmailId = reader.GetString(8);
                        Console.WriteLine(addressBookDetails.PersonId+"\n"+ addressBookDetails.Firstname + "\n"+ addressBookDetails.Lastname + "\n"+ addressBookDetails.Address + "\n"+ addressBookDetails.City + "\n"+ addressBookDetails.State + "\n"+ addressBookDetails.ZipCode + "\n"+ addressBookDetails.PHNO + "\n" + addressBookDetails.EmailId);
                    }
                    else
                    { Console.WriteLine("No Records are AVAILABLE"); }
                }
            }
            catch(Exception ex)
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
