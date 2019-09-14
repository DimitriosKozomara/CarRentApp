using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvpProj
{
    public class Client : User
    {
        int clientID;
        string name;
        string surname;
        string pin;
        DateTime dateOfBirth;
        string number;

        public Client(string username, string password, string name, string surname, string PIN, DateTime dateOfBirth, string number) : base(username, password)
        {
            this.clientID = 0;
            this.name = name;
            this.surname = surname;
            this.pin = PIN;
            this.dateOfBirth = dateOfBirth;
            this.number = number;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string PIN { get => pin; set => pin = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Number { get => number; set => number = value; }
        public int ClientID { get => clientID; set => clientID = value; }
        
        public override string ToString()
        {
            /*return this.username + "\n" +
                this.clientID + ". " + this.name + " " + this.surname +
                "\nPIN: " + this.pin + 
                "\nDate of birth: "+ this.dateOfBirth + "\n" +
                this.number;
                */

            return "ID: " + this.clientID + ". " + this.username + " --> " + this.name + " " + this.surname;
        }
    }
}
