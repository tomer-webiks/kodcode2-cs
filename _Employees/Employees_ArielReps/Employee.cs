using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class Employee
    {
        public string ID { get; set; }
        //private static int NextID;
        //public Employee() {
        //    ID = ++NextID;
        //}
        public Employee(string id)
        {
        }
        public Employee(string id,int code, string FirstName, string LastName, DateTime Birthday, bool isMale, string Status, string Cellphone, string City, string Street, string HouseNumber)
        {
            this.ID = id;
            this.code = code;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Birthday = Birthday;
            this.isMale = isMale;
            this.Street = Street;
            this.Status = Status;
            this.Cellphone = Cellphone;
            this.City = City;
            this.HouseNumber = HouseNumber;
        }
        public int code { get; set; }
        public string FirstName;
        public string LastName;
        private string FullName { get { return FirstName + " " + LastName; } }
        public DateTime Birthday;
        public int Age { get { return DateTime.Now.Year - Birthday.Year; } }
        public bool isMale { get; set; }
        public string Status {  get; set; }
        public string Cellphone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Adress { get { return Street + " " + HouseNumber + " " + City; } }
    }
}
