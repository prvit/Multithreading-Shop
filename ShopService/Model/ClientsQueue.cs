using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopService.Model;

namespace ShopService.Model
{
    public class ClientsQueue
    {
        private List<Client> _queue;

        public List<Client> ClientsInQueue
        {
            get { return this._queue; }

            set { this._queue = value; }
        }

        public void Push(Client newMember)
        {
            List<Client> tempQueue = ClientsInQueue;
            tempQueue.Add(newMember);
            ClientsInQueue = tempQueue;
        }
        public void Pull()
        {
            int count = ClientsInQueue.Count;
            List<Client> tempQueue = ClientsInQueue;
            tempQueue.RemoveAt(0);
            ClientsInQueue = tempQueue;
        }
        public void Pull(int index)
        {
            List<Client> tempQueue = ClientsInQueue;
            tempQueue.RemoveAt(index);
            ClientsInQueue = tempQueue;
        }
    }
}
