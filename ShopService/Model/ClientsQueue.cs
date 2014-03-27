using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopService.Model;
using System.Collections;

namespace ShopService.Model
{
    public class ClientsQueue : IEnumerable
    {
        private const int FIRST_ELEMENT = 0;
        private List<Client> queue;
        public List<Client> ClientsInQueue
        {
            get { return this.queue; }

            set { this.queue = value; }
        }
        public ClientsQueue()
        {
            queue = new List<Client>();
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
        public void Pull(Client client)
        {
            ClientsInQueue.Remove(client);
        }
        public Client GetMostSuitableClient()
        {
            lock (ClientsInQueue)
            {
                Client suitableClient = ClientsInQueue.ElementAt(FIRST_ELEMENT);
                foreach (var client in ClientsInQueue)
                {
                    if (client.VisitedStands.Count > suitableClient.VisitedStands.Count)
                    {
                        suitableClient = client;
                    }
                }
                return suitableClient;
            }
        }
        public Client GetFirst()
        {
            return this.queue.First();
        }

        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ClientQueueEnum GetEnumerator()
        {
            return new ClientQueueEnum(this.queue);
        }

        public class ClientQueueEnum : IEnumerator
        {
            private List<Client> queue;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public ClientQueueEnum(List<Client> queue)
            {
                this.queue = queue;
            }

            public bool MoveNext()
            {
                position++;
                return (position < queue.Count);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Client Current
            {
                get
                {
                    try
                    {
                        return queue[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
        #endregion
    }
}
