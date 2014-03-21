using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopService.Model;
using System.Threading;

namespace ShopService.Management
{
    class ShopManager
    {
        private Shop shop;

        public Shop Shop
        {
            set
            {
                if (value != null)
                {
                    shop = value;
                }
                else
                {
                    throw new ArgumentNullException("Can't set shop to null.");
                }
            }
            get
            {
                return this.shop;
            }
        }

        private List<Client> newClients;
        private List<Client> oldClients;

        public List<Client> NewClients
        {
            get
            {
                return this.newClients;
            }
        }
        public ShopManager(int countOfShopStands)
        {
            shop = new Shop(countOfShopStands);
            newClients = new List<Client>();
            oldClients = new List<Client>();
        }

        public void PushClients(int numberOfClients)
        {
            for (int i = 0; i < numberOfClients; i++)
            {
                newClients.Add(new Client(this.shop));
            }

            if (oldClients.Count == 0)
            {
                oldClients = newClients;
                HandleOldClients();
            }
            else
            {
                HandleOldClients();
                oldClients = newClients;
                HandleOldClients();
            }
            // TODO handle clients
        }

        private void HandleOldClients()
        {
            foreach (var client in oldClients)
            {
                List<int> busyTime = new List<int>();
                foreach (var stand in shop)
                {
                    busyTime.Add(stand.GetCountOfClients * stand.TimeOfService);
                }
                int indexOfStandToAddClient = IndexOfMin(busyTime);
                int indexOfVendorToAddClient = shop[indexOfStandToAddClient].GetIndexOfVendorWithMinClients();
                this.shop[indexOfStandToAddClient][indexOfVendorToAddClient].Queue.Push(client);
            }
            oldClients.Clear();
        }

        private List<Thread> threads = new List<Thread>();

        public void DoShopWork()
        {
            foreach (var stand in shop)
            {
                foreach (var vendor in stand)
                {
                    threads.Add(new Thread(Run));
                }
            }
            foreach (var stand in shop)
            {
                for (int i = 0; i < threads.Count; i++)
                {
                    threads[i].Start(stand[i]);
                }
            }
            
        }

        protected void Run(object vendor)
        {
            Vendor vndr = (Vendor)vendor;
            for (int i = 0; i < vndr.CountOfClients; i++)
            {
                Thread.Sleep(vndr.TimeOfService);
                vndr.Queue.ClientsInQueue.ElementAt(0).VisitedStands[vndr.StandId] = true;
                oldClients.Add(vndr.Queue.ClientsInQueue.ElementAt(0));
                vndr.Queue.Pull();
            }
        }

        private int IndexOfMin(List<int> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("List is null.");
            }
            if (self.Count == 0)
            {
                throw new ArgumentException("List is empty.");
            }

            int min = self[0];
            int minIndex = 0;
            for (int i = 1; i < self.Count; ++i)
            {
                if (self[i] < min)
                {
                    min = self[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

    }
}
