using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests.Pages
{
    class ContactData
    {
        private string name;
        private string surname;
        private string email;
        private string phone;

        public ContactData(string name, string surname, string email, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
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
    }
}
