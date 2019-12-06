using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string surname, string name)
        {
            Name = name;
            Surname = surname;
        }
        public ContactData(string surname)
        {
            Surname = surname;
        }
        public ContactData()
        {
            
        }
    
        public string Name{get; set;}
        public string Surname{ get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone);
                }
            }

            set
            {
                allPhones = value;
            } }

        private string Cleanup(string phone)
        {
            if (phone == null)
            {
                return "";
            }
            return phone.Replace(" ", "")
                .Replace("-", "")
                .Replace(")", "")
                .Replace("(", "");
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Surname == other.Surname && Name == other.Name;
        }

        public override int GetHashCode()
        {
            //return Name.GetHashCode();
            return 0;                                                   //lekcja 4.2,w konce
        }

        public override string ToString()
        {

            return " Name = " +  Name;

        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compareResult = Surname.CompareTo(other.Surname);

            if (compareResult == 0)
            {
                return Name.CompareTo(other.Name);
            }

            return compareResult;
        }
    }
}
