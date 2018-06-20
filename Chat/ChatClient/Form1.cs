using ChatInterfaces;
using ChatServer;
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
    public partial class Form1 : Form
    {
        IWCFChatService proxy;
        public Form1()
        {
            ChannelFactory<WCFChatService> channelfactory = 
                new ChannelFactory<WCFChatService>();
            proxy = channelfactory.CreateChannel();
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (proxy.Login(userTextBox.Text,passTextBox.Text))
            {
                InfoLabel.Text = "Login Success!";
            }
            else
            {
                InfoLabel.Text = "Login Failed!";
            }
        }
    }
}
