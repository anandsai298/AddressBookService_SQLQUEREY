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
                using (this.connection)
                {
                    string query = @"select * from AddressBook";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.Text;
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    //HEAD
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                //UC2-GetAllPersonTypeRecords
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
                                    Console.WriteLine(addressBookDetails.PersonId + "\n" + addressBookDetails.Firstname + "\n" + addressBookDetails.Lastname + "\n" + addressBookDetails.Address + "\n" + addressBookDetails.City + "\n" + addressBookDetails.State + "\n" + addressBookDetails.ZipCode + "\n" + addressBookDetails.PHNO + "\n" + addressBookDetails.EmailId);
                                }
                            }
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
        public void AddAddressDetails(AddressBookDetails addressBookDetails)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("AddAddressDetails", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Firstname", addressBookDetails.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", addressBookDetails.Lastname);
                    cmd.Parameters.AddWithValue("@Address", addressBookDetails.Address);
                    cmd.Parameters.AddWithValue("@City", addressBookDetails.City);
                    cmd.Parameters.AddWithValue("@State", addressBookDetails.State);
                    cmd.Parameters.AddWithValue("@ZipCode", addressBookDetails.ZipCode);
                    cmd.Parameters.AddWithValue("@PHNO", addressBookDetails.PHNO);
                    cmd.Parameters.AddWithValue("@EmailId", addressBookDetails.EmailId);
                    this.connection.Open();
                    int RowsEffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (RowsEffected > 0)
                        Console.WriteLine("ADRESSBOOK Added successfully");
                    else
                        Console.WriteLine("ADRESSBOOK Added UNSuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteAddressBook(int ID)
        {
            try
            {
                AddressBookDetails addressBookDetails = new AddressBookDetails();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteAddressBook", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonId", ID);
                    this.connection.Open();
                    int RowsEffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (RowsEffected > 0)
                        Console.WriteLine("ADRESSBOOK Deleted successfully");
                    else
                        Console.WriteLine("ADRESSBOOK Delete UNSuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateAddressBook(int ID,string Name)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateAddressBook", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonId", ID);
                    cmd.Parameters.AddWithValue("@FirstName", Name);
                    this.connection.Open();
                    int RowsEffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (RowsEffected > 0)
                        Console.WriteLine("ADRESSBOOK Updated successfully");
                    else
                        Console.WriteLine("ADRESSBOOK Update UNSuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<AddressBookDetails> Personlist = new List<AddressBookDetails>();
        public void AddPersonToAddressBook(List<AddressBookDetails> Personlist)
        {
            Personlist.ForEach(PersonData =>
            {
                Console.WriteLine("Person is being adding to List : " + PersonData.Firstname);
                this.AddPerson(PersonData);
                Console.WriteLine("Person is added: " + PersonData.Firstname);
            }) ;
        }
        public void AddPersonToAddressBookByThread(List<AddressBookDetails> Personlist)
        {
            Personlist.ForEach(PersonData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Person is being adding to List : " + PersonData.Firstname);
                    this.AddPerson(PersonData);
                    Console.WriteLine("Person is added: " + PersonData.Firstname);
                });
                thread.Start();
            });
            Console.WriteLine(this.Personlist.Count);
        }

        public void AddPerson(AddressBookDetails Person)
        {
            Personlist.Add(Person);
        }
    }
}
