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

        public ShopManager()
        {
            organizingThread = new Thread(OrganizeClients);
        }
        public void PushClients(int countOfNewClients)
        {
            Thread thread = new Thread(AddNewClients);
            thread.Start(countOfNewClients);
        }
        private void OrganizeClients()
        {

        }


        
        private void AddNewClients(object countOfNewClients)
        {
            int count = (int)countOfNewClients;
            for (int i = 0; i < count; i++)
            {
                shopClients.Push(new Client(this.shop));
            }
        }
        private int IndexOfMin(List<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("List is null.");
            }
            if (list.Count == 0)
            {
                throw new ArgumentException("List is empty.");
            }

            int min = list[0];
            int minIndex = 0;
            for (int i = 1; i < list.Count; ++i)
            {
                if (list[i] < min)
                {
                    min = list[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

    }
}
