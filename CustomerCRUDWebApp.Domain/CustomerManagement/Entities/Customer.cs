using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Domain.CustomerManagement.Entities
{
    public class Customer
    {
        public Guid CustomerID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string ContactNumber { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private  set; }
        public DateTime DateDeleted { get; private set; }
        private Customer()
        {

        }

        public Customer(string firstName,string lastName,string address,string contactNumber)
        {
            CustomerID = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ContactNumber = contactNumber;
            DateCreated = DateTime.Now;
        }

        public void Update(string firstName, string lastName, string address, string contactNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ContactNumber = contactNumber;
            DateUpdated = DateTime.Now;
        }

        public void Delete()
        {
            DateDeleted = DateTime.Now;
        }
    }
}
