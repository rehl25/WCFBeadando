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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        IWCFChatService proxy;
        string username;
        string password;

        public LoginForm()
        {
            ChannelFactory<IWCFChatService> channelfactory =
                new ChannelFactory<IWCFChatService>("ChatServiceEndpoint");
            proxy = channelfactory.CreateChannel();
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            username = userTextBox.Text;
            password = passTextBox.Text;
            try
            {
                if (proxy.Login(username, password))
                {
                    Thread t = new Thread(new ThreadStart(Chat));
                    password = "";
                    t.Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password!");
                }
            }catch (EndpointNotFoundException)
            {
                MessageBox.Show("Server Down! Please wait a few minutes!");
            }
            catch(FaultException)
            {
                MessageBox.Show("Lost connection to Database. Please close the application and retry.");
            }
        }

        private void Chat()
        {
            Application.Run(new ChatForm(username));
        }
    }
}
