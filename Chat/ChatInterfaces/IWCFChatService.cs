using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatInterfaces
{
    [ServiceContract]
    public interface IWCFChatService
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        bool Login(string username,string password);

        [OperationContract]
        List<UserInfo> UserList();
    }
}
