using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using System.Threading;
using ClientHostForm.Models;

namespace ClientHostForm
{
    public partial class Pesan : Form
    {
        static List<Members> ConnectedUsers = new List<Members>();
        private HubConnection connection;
        private IHubProxy hub;
        private int loop;
        private string myId;

        public Pesan()
        {
            InitializeComponent();
            #region Koneksi
            string url = @"http://192.168.10.62:5000";
            connection = new HubConnection(url);
            hub = connection.CreateHubProxy("MyHub");
            connection.Start().Wait();
            #endregion
        }

        public void Send()
        {
            #region Kirim pesan
            var SyncSend= SynchronizationContext.Current;
            hub.On<string>("addMessage", message =>
                {
                    SyncSend.Post(_ =>
                        {
                            //Ngakalin biar ga kirim pesan lebih dari 1
                            while (loop < 1)
                            {
                                listPesan.Items.Add(message.ToString());
                                loop++;
                            }
                        }, null);
                });
            #endregion

            hub.Invoke("Send", myId, textPesan.Text).Wait();
        }

        public void Load_user()
        {
            var Sync = SynchronizationContext.Current;

            #region User baru online
            hub.On<string,string>("onNewUserConnected", (id, username) =>
            {
                Sync.Post(_ =>
                {
                    ConnectedUsers.Add(new Members(username, id));
                    
                    listOnline.DataSource = ConnectedUsers;
                }, null);
            });
            #endregion

            #region load daftar user
            hub.On<string,string>("onConnected", (Cid,id) =>
            {
                Sync.Post(_ =>
                {
                    myId = id;
                    if (Cid != null)
                    {
                        var users = Cid.Split('?');
                        foreach (var user in users)
                        {
                            var splUser = user.Split('|');
                            ConnectedUsers.Add(new Members(splUser[1], splUser[0]));

                            listOnline.DataSource = ConnectedUsers;
                        }
                    }
                }, null);
            });
            #endregion

            #region Hapus daftar user
            hub.On<string,string>("onDisconnected", (id,username) =>
            {
                Sync.Post(_ =>
                {
                    var item = ConnectedUsers.FirstOrDefault(x => x.id == id);
                    if (item != null)
                    {
                        ConnectedUsers.Remove(item);
                        listOnline.DataSource = ConnectedUsers;
                    }
                }, null);
            });
            #endregion

            hub.Invoke("Connect", textUsername.Text).Wait();
        }

        #region Control
        private void buttonKirim_Click(object sender, EventArgs e)
        {
            Send();
            //Set loop ke 0 lagi
            loop = 0;
        }

        private void buttonUsername_Click(object sender, EventArgs e)
        {
            Load_user();
            
            buttonUsername.Enabled = false;
            textUsername.Enabled = false;
        }

        private void listOnline_DoubleClick(object sender, EventArgs e)
        {
            Members m = (Members)listOnline.SelectedItem;
            label1.Text = m.id;
            label2.Text = m.name;
        }

        #endregion
    }
}
