using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Data.Models
{
    public class Person : BaseEntity
    {
        private string _name;
        private string _email;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or empty.");
                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Contains("@") && value.Contains("."))
                    _email = value;
                else
                    throw new ArgumentException("Invalid email format.");
            }
        }
        public Person()
        {
            
        }
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
