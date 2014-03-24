using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopService.Model;
using System.Threading;
using System.IO;
using ShopService.Utilities;
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
        private bool isShopClosing;
        public ShopManager()
        {
            shop = new Model.Shop(15);
            shopClients = new ClientsQueue();
            organizingThread = new Thread(OrganizeClients);
            vendorsThreads = new Dictionary<int, Thread>();
            isShopClosing = false;
            StartOrganizeThread();
        }
        public void PushClients(int countOfNewClients)
        {
            Thread thread = new Thread(AddNewClients);
            thread.Start(countOfNewClients);
        }
        public void StartOrganizeThread()
        {
            if (!organizingThread.IsAlive)
            {
                organizingThread.Start();                
            }
        }
        public void CloseShop()
        {
            isShopClosing = true;
            organizingThread.Abort();
        }
        private void OrganizeClients()
        {
            while (!isShopClosing)
            {
                if (shopClients.ClientsInQueue.Count > 0)
                {
                    Client client = shopClients.GetFirst();
                    Dictionary<int, int> busyStandsTime = new Dictionary<int, int>();
                    if (client == null)
                    {
                        
                    }
                    List<Stand> unvisitedStands = shop.GetStandsClientWasNotBefore(client);
                    if (unvisitedStands.Count > 0)
                    {
                        lock (shopClients)
                        {
                            foreach (var stand in unvisitedStands)
                            {
                                busyStandsTime.Add(stand.StandId, stand.GetCountOfClients * stand.TimeOfService);// TODO better algo
                            }
                            int idOfStandToAddClient = KeyOfMin(busyStandsTime);
                            if (client.ClientID == 11)
                            {

                            }
                            int idOfVendorToAddClient = shop[idOfStandToAddClient].GetIdOfVendorWithMinClients();
                            this.shop[idOfStandToAddClient][idOfVendorToAddClient].Queue.Push(client);
                            string line = String.Format("Client {0} was sent to {1} Vendor queue. (Stand {2})", client.ClientID, 
                                this.shop[idOfStandToAddClient][idOfVendorToAddClient].VendorID, this.shop[idOfStandToAddClient][idOfVendorToAddClient].VendorStandId);
                            Logger.LogInfo(line);
                            Console.WriteLine(line);
                            Client pulledClient = shopClients.Pull();
                        }
                    }
                    else
                    {
                        Client pulledClient = shopClients.Pull();
                        string line = String.Format("Client {0} quit shop.", pulledClient.ClientID);
                        Logger.LogInfo(line);
                        Console.WriteLine(line);

                    }
                }
            }
            if (isShopClosing)
            {
                while (shopClients.ClientsInQueue.Count > 0)
                {
                    Client pulledClient = shopClients.Pull();
                    string line = String.Format("Client {0} quit shop.", pulledClient.ClientID);
                    Logger.LogInfo(line);
                    Console.WriteLine(line);
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
                    if (!vendorsThreads[vendor.VendorID].IsAlive)
	                {
		                vendorsThreads[vendor.VendorID].Start(vendor);
	                }
                }
            }
        }
        private void ProceedeClientsByVendor(object vendor)
        {
            Vendor currVendor = (Vendor)vendor;
            int time = currVendor.TimeOfService;
            while(true)
            {
                if (currVendor.CountOfClients > 0)
                {
                    Thread.Sleep(time*1000);
                    Client pulledClient = this.shop[currVendor.VendorStandId][currVendor.VendorID].Queue.Pull();
                    pulledClient.VisitedStands[currVendor.VendorStandId] = true;
                    string line = String.Format("Client {0} was served by {1} Vendor. (Stand {2})", pulledClient.ClientID, currVendor.VendorID, currVendor.VendorStandId);
                    Logger.LogInfo(line);
                    Console.WriteLine(line);
                    if (!isShopClosing)
                    {
                        this.shopClients.Push(pulledClient);
                        string ln = String.Format("Client {0} was sent to overall queue.", pulledClient.ClientID);
                        Logger.LogInfo(ln);
                        Console.WriteLine(ln);
                    }
                    else
                    {
                        string ln = String.Format("Client {0} quit a shop.", pulledClient.ClientID);
                        Logger.LogInfo(ln);
                        Console.WriteLine(ln);
                    }
                }
            }
            //vendorsThreads[currVendor.VendorID].Abort();
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
                    string line = String.Format("Client {0} was pushed to shop.", client.ClientID);
                    Logger.LogInfo(line);
                    Console.WriteLine(line);
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
            var first = dict.OrderBy(kvp => kvp.Key).First();
            int minValue = first.Value;
            int minKey = first.Key;
            foreach (var item in dict)
            {
                if (item.Value < minValue)
                {
                    minValue = item.Value;
                    minKey = item.Key;
                }
            }
            return minKey;
        }
        public void TestShopFill()
        {
            Random rand = new Random();

            for (int i = 1; i <= 10; i++)
			{
                int j = rand.Next(1, 10);
                this.shop.AddStand(j);
			}
            foreach (var stand in shop)
            {
                for (int i = 0; i < rand.Next(1,5); i++)
                {
                    stand.AddVendor();                    
                }
            }
        }
    }
}
