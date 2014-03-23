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
        private const int FIRST_ELEMENT = 0;
        private List<Client> queue;
        public List<Client> ClientsInQueue
        {
            get { return this.queue; }

            set { this.queue = value; }
        }
        public void Push(Client newMember)
        {
            List<Client> tempQueue = ClientsInQueue;
            tempQueue.Add(newMember);
            ClientsInQueue = tempQueue;
        }
        public Client Pull()
        {
            Client deletedClient = ClientsInQueue.ElementAt(FIRST_ELEMENT);
            ClientsInQueue.RemoveAt(FIRST_ELEMENT);
            return deletedClient;
        }
        public Client GetFirst()
        {
            return this.queue.ElementAt(FIRST_ELEMENT);
        }
    }
}
