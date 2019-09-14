using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpProj
{
    public abstract class User
    {
        protected string username;
        protected string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public static User Login(string username, string password)
        {
            Administrator admin = Data.ReadAdmin();

            if (admin.username.Equals(username))
            {
                if (admin.password.Equals(password))
                    return admin;
                MessageBox.Show("Wrong password!");
                return null;
            }

            List<Client> clients = Data.ReadAll<Client>();
            //LINQ
            var client = clients.Where(x => x.username.Equals(username)).FirstOrDefault();
            if(client == null)
            {
                MessageBox.Show("Client with '" + username + "' username does not exist!");
                return null;
            }

            if (client.password.Equals(password))
                return client;
            MessageBox.Show("Wrong password!");
            return null;
        }

        public static bool UsernameExists(string username)
        {
            //Conversion testing
            List<User> users = Data.ReadAll<Client>().ConvertAll(x => (User)x);
            users.Add(Data.ReadAdmin());

            int check = users.Where(x => x.username.Equals(username)).Count();

            if (check > 0)
                return true;
            return false;
        }

    }

}
