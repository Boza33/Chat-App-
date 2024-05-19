using System.Collections.Generic;
using System.Linq;

namespace Chat_App.Services
{
    public class ChatServices
    {

        private static readonly Dictionary<string, string> Users = new Dictionary<string, string>();
        public bool AddUserToList(string userToAdd)
        {
            lock (Users)
            {
                foreach(var user in Users)
                {
                    if (user.Key.ToLower() == userToAdd.ToLower())
                        return true;
                }
            }
            Users.Add(userToAdd, null);
            return true;  
        }
        public void AddUserConnectionID(string user, string connectionID)
        {
            lock (Users)
            {
                if (Users.ContainsKey(user))
                    Users[user] = connectionID;
            }
        }
        
    }
}
