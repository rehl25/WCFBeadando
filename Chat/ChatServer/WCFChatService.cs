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
            catch{throw;}
            return tmp[0].Trim().Equals(password);
        }
        public List<UserInfo> UserList()
        {
            List<UserInfo> userInfo = new List<UserInfo>();

            try
            {
                using (Database data = new Database())
                {
                    foreach (User u in data.Users)
                    {
                        UserInfo uInfo = new UserInfo();
                        uInfo.Username = u.UserName;
                        uInfo.Password = u.Password;
                        userInfo.Add(uInfo);//Terrible idea in reality, 
                                            //but the only way I could think of 
                                            //to return a complex type
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return userInfo;
        }
    }
}
