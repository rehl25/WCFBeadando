using ChatInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ChatForm : Form
    {
        IWCFChatService proxy;
        public ChatForm(string username)
        {
            ChannelFactory<IWCFChatService> channelfactory =
                new ChannelFactory<IWCFChatService>("ChatServiceEndpoint");
            proxy = channelfactory.CreateChannel();
            InitializeComponent();
            usernameLabel.Text = username;
            chatTextBox.ReadOnly = true;
            List<string> userInfo= new List<string>();
            foreach (UserInfo u in proxy.UserList())
            {
                userInfo.Add(u.Username);
            }
            usersListBox.DataSource = userInfo;
        }
        public void WaitForMessage()
        {
            while (true)
            {

            }
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {

            }
        }
    }
}
