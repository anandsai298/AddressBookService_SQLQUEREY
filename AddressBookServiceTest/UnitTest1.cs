using AddressBookService;
namespace AddressBookServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenAddressBook_WhenAddedToList_ShouldMatchAddressBookEntries()
        {
            List<AddressBookDetails> list = new List<AddressBookDetails>();
            list.Add(new AddressBookDetails(PersonId:1, Firstname:"Ask", Lastname:"Ar", Address:"Bridze", City:"Kakinada", State:"A.P", ZipCode:533002, PHNO:"7412589635", EmailId:"askar@gmail.com"));
            list.Add(new AddressBookDetails(PersonId: 2, Firstname: "anand", Lastname: "vr", Address: "Junction", City: "Vizag", State: "A.P", ZipCode: 533000, PHNO: "7412489635", EmailId: "anand@gmail.com"));
            list.Add(new AddressBookDetails(PersonId: 3, Firstname: "sai", Lastname: "aj", Address: "Rpund", City: "Khammam", State: "A.P", ZipCode: 53150, PHNO: "7412589645", EmailId: "sai@gmail.com"));
            list.Add(new AddressBookDetails(PersonId: 4, Firstname: "kumar", Lastname: "pj", Address: "Under", City: "Nellore", State: "A.P", ZipCode: 53002, PHNO: "7412549635", EmailId: "kumar@gmail.com"));
            Operation operation = new Operation();
            DateTime StartTime = DateTime.Now;
            operation.AddPersonToAddressBook(list);
            DateTime StopTime = DateTime.Now;
            Console.WriteLine("duration without thread:" + (StartTime - StopTime));
            Console.WriteLine("by using thread");
            DateTime StartDateTimeThread = DateTime.Now;
            operation.AddPersonToAddressBookByThread(list);
            DateTime StopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with threads: " + (StartDateTimeThread - StopDateTimeThread));
        }
    }
}