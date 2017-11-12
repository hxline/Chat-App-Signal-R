using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using ServerHost.Models;

namespace ServerHost
{
    public class MyHub : Hub
    {

        #region Data Members

        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();
        private string Cid = null;
        #endregion

        #region Procedures

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                int i = 0;

                // Tambah ke list user
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });

                if (ConnectedUsers.Count > 1)
                {
                    foreach (var cu in ConnectedUsers.Where(x => x.ConnectionId != id))
                    {
                        if (Cid != null)
                        {
                            Cid = Cid + "?" + cu.ConnectionId + "|" + cu.UserName;
                        }
                        else
                        {
                            Cid = cu.ConnectionId + "|" + cu.UserName;
                        }
                    }
                }

                // Ngirim ke caller baru daftar user online
                Clients.Caller.onConnected(Cid,id);

                // Ngirim ke semua client kecuali caller
                Clients.AllExcept(id).onNewUserConnected(id, userName);
                
            }
        }

        public void SendPrivateMessage(string toUserId, string message)
        {
            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // Ngirim ke client tertentu
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // Ngirim ke caller
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }

        }

        public void Send(string id, string message)
        {
            Console.WriteLine("Client mengirimkan {0}: {1}", id, message);
            var user = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == id);
            var pesan = user.UserName + ": " + message;
            Clients.AllExcept(id).addMessage(pesan);
        }

        #endregion

        public override Task OnConnected()
        {
            Console.WriteLine("Terkoneksi {0}",Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);
            }
            Console.WriteLine("Terputus {0}", Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}
