using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopService.Model
{
    public class Vendor
    {
        private static int idCount = 0;
        private int vendorID;
        public int VendorID
        {
            get
            {
                return vendorID;
            }
        }
        private int time_of_service;
        public int TimeOfService
        {
            set
            {
                if (value > 0)
                {
                    time_of_service = value;
                }
                else
                {
                    throw new FormatException("Time of service can't be less than zero.");
                }
            }
            get
            {
                return time_of_service;
            }
        }

        private ClientsQueue queue;
        public ClientsQueue Queue
        {
            get
            {
                return this.queue;
            }
        }

        public int CountOfClients
        {
            get
            {
                return queue.ClientsInQueue.Count;
            }
        }

        private int vendorStandId;
        public int VendorStandId
        {
            get
            {
                return this.vendorStandId;
            }
        }

        public Vendor(Stand stand)
        {
            idCount++;
            this.vendorID = idCount;
            this.TimeOfService = stand.TimeOfService;
            this.queue = new ClientsQueue();
            this.vendorStandId = stand.StandId;
        }
    }
}
