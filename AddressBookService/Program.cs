// See https://aka.ms/new-console-template for more information
using AddressBookService;
using System;
namespace EmployeePayRollService;
class Program
{
    static void Main(string[] args)
    {
        Operation operation = new Operation();
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("1.GetAllAddressBookRecords\n2.AddAddressDetails\n3.DeleteAddressBook\n4.UpdateAddressBook");
            Console.WriteLine("enter option:");
            int option=Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
                    operation.GetAllAddressBookRecords();
                    break;
                case 2:
                    AddressBookDetails addressBookDetails = new AddressBookDetails()
                    {
                        Firstname = "Sanjay",
                        Lastname = "Sams",
                        Address = "desert",
                        City = "Rajadani",
                        State = "Rajastan",
                        ZipCode = 15002,
                        PHNO = "9856785412",
                        EmailId = "Sams@gmail.com",
                    };
                    operation.AddAddressDetails(addressBookDetails);
                    break;
                case 3:
                    operation.DeleteAddressBook(6);
                    break;
                case 4:
                    operation.UpdateAddressBook(1, "Ajith");
                    break;



            }
        }
    }
}
