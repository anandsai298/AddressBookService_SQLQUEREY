// See https://aka.ms/new-console-template for more information
using AddressBookService;
using System;
namespace EmployeePayRollService;
class Program
{
    static void Main(string[] args)
    {
        Operation operation = new Operation();
        //operation.GetAllAddressBookRecords();
        AddressBookDetails addressBookDetails = new AddressBookDetails()
        {
            Firstname="Ajay",
            Lastname="Kumar",
            Address="Turangi",
            City="Amalapuram",
            State = "AP",
            ZipCode = 780005,
            PHNO = "9517458962",
            EmailId = "ajay@gmail.com",
        };
        operation.AddAddressDetails(addressBookDetails);
        /*operation.DeleteAddressBook(id);
        operation.UpdateAddressBook(1, "Askar");*/
    }
}
