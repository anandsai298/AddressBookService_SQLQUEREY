// See https://aka.ms/new-console-template for more information
using AddressBookService;
using System;
namespace EmployeePayRollService;
class Program
{
    static void Main(string[] args)
    {
        Operation operation = new Operation();
        operation.GetAllAddressBookRecords();
        /*AddressBookDetails details = new AddressBookDetails();
        operation.AddAddressDetails(details);
        operation.DeleteAddressBook(id);
        operation.UpdateAddressBook(1, "Askar");*/
    }
}
