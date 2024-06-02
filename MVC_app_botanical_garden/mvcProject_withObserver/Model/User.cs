using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Model
{
    public class User
    {
        protected string userID;
        protected string person;    
        protected string password;
        protected string username;
        protected string adminStatus;

        public User() { }

        public User(string userID, string person, string password, string username)
        {
            this.userID = userID;
            this.person = person;
            this.password = password;
            this.username = username;
        }

        public User(string userID, string person, string password, string username, string adminStatus)
        {
            this.userID = userID;
            this.person = person;
            this.password = password;
            this.username = username;
            this.adminStatus = adminStatus;
        }
        public string Id
        {
            get { return this.userID; }
        }

        public string Person
        {
            get { return this.person; }
            set { this.person = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string AdminStatus
        {
            get { return this.adminStatus; }
            set { this.adminStatus = value; }
        }

        public override bool Equals(object obj)
        {
            if(this == obj) return true;
            if(obj == null || GetType() != obj.GetType()) 
                return false;
            User user = (User)obj;
            return Equals(Person, user.Person) && Equals(Password, user.Password) 
                && Equals(Username, user.Username);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (userID != null ? userID.GetHashCode() : 0);
                hash = hash * 23 + (person != null ? person.GetHashCode() : 0);
                hash = hash * 23 + (password != null ? password.GetHashCode() : 0);
                hash = hash * 23 + (username != null ? username.GetHashCode() : 0);
                hash = hash * 23 + (adminStatus != null ? adminStatus.GetHashCode() : 0);
                return hash;
            }
        }

    }

}
