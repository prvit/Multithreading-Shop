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
        private ClientsQueue shopClients;
        public ClientsQueue ShopClients
        {
            get
            {
                return this.shopClients;
            }
        }
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
        private Thread organizingThread;
        Dictionary<int, Thread> vendorsThreads;
        public ShopManager()
        {
            shopClients = new ClientsQueue();
            organizingThread = new Thread(OrganizeClients);
        }
        public void PushClients(int countOfNewClients)
        {
            Thread thread = new Thread(AddNewClients);
            thread.Start(countOfNewClients);
        }
        private void StartOrganizeThread()
        {
            organizingThread.Start();
        }
        private void OrganizeClients()
        {
            lock (this.shopClients)
            {
                while (shopClients.ClientsInQueue.Count > 0)
                {
                    Client client = shopClients.GetFirst();
                    Dictionary<int, int> busyStandsTime = new Dictionary<int, int>();
                    foreach (var stand in shop.GetStandsClientWasNotBefore(client))
                    {
                        busyStandsTime.Add(stand.StandId, stand.GetCountOfClients * stand.TimeOfService);// TODO better algo
                    }
                    int idOfStandToAddClient = KeyOfMin(busyStandsTime);
                    int indexOfVendorToAddClient = shop[idOfStandToAddClient].GetIndexOfVendorWithMinClients();
                    this.shop[idOfStandToAddClient][indexOfVendorToAddClient].Queue.Push(client);
                    Console.WriteLine("Client {0} was sent to {1} Vendor.", client.ClientID, this.shop[idOfStandToAddClient][indexOfVendorToAddClient].VendorID);
                    Client pulledClient = shopClients.Pull();
                    //Console.WriteLine("Client {0} was sent to {1} Vendor.", client.ClientID, this.shop[idOfStandToAddClient][indexOfVendorToAddClient].VendorID);

                }
            }
        }
        public void StartProceedingThreads()
        {
            foreach (var stand in shop)
            {
                foreach (var vendor in stand)
                {
                    if (!vendorsThreads.ContainsKey(vendor.VendorID))
                    {
                        vendorsThreads.Add(vendor.VendorID, new Thread(ProceedeClientsByVendor));
                    }
                }
            }
        }
        private void ProceedeClientsByVendor(object vendorID)
        {

        }
        private void AddNewClients(object countOfNewClients)
        {
            int count = (int)countOfNewClients;
            lock (this.shopClients)
            {
                for (int i = 0; i < count; i++)
                {
                    Client client = new Client(this.shop); 
                    shopClients.Push(client);
                    Console.WriteLine("Client {0} was pushed to shop.", client.ClientID);
                }
            }
        }
        private int KeyOfMin(Dictionary<int, int> dict)
        {
            if (dict == null)
            {
                throw new ArgumentNullException("Dictionary is null.");
            }
            if (dict.Count == 0)
            {
                throw new ArgumentException("Dictionary is empty.");
            }

            int minValue = dict[0];
            int minKey = 0;
            for (int i = 1; i < dict.Count; ++i)
            {
                if (dict[i] < minValue)
                {
                    minValue = dict[i];
                    minKey = i;
                }
            }
            return minKey;
        }
    }
}
