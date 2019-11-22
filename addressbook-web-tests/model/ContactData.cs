using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string name;
        private string surname;
        private string email;
        private string phone;

        public ContactData(string surname, string name)
        {
            this.name = name;
            this.surname = surname;
        }
        public ContactData(string surname)
        {
            this.surname = surname;
        }
        public ContactData()
        {
            
        }
    
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
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
