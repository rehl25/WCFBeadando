using ChatInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatServer
{
    public class WCFChatService : IWCFChatService
    {

        public bool Login(string username, string password)
        {
            List<string> tmp= new List<string>();
            try
            {
                using (Database database= new Database())
                {
                    var passwd = from User in database.Users
                               where User.UserName.Equals(username)
                               select User.Password;
                    tmp = passwd.ToList();
                }
            }
            catch
            {
                throw;
                
            }
            return tmp.Contains(password);
        }
    }
}
