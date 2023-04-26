using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService
{
    public class AddressBookDetails
    {
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PHNO { get; set; }
        public string EmailId { get; set; }
        public string PersonName { get; set; }
        public string RelationType { get; set; }
        public int Id { get; set; }

        public AddressBookDetails(int PersonId,string Firstname, string Lastname, string Address, string City, string State, int ZipCode, string PHNO, string EmailId)
        {
            this.PersonId = PersonId;
            this.Firstname=Firstname;
            this.Lastname = Lastname;
            this.Address = Address;
            this.City = City;   
            this.State = State;
            this.ZipCode = ZipCode;
            this.PHNO = PHNO;   
            this.EmailId = EmailId; 
        }
        public AddressBookDetails()
        {
            this.PersonId = PersonId;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
            this.PHNO = PHNO;
            this.EmailId = EmailId;
        }
    }
}
