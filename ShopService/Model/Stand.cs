using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopService.Model;
using System.Collections;

namespace ShopService.Model
{
    public class Stand : IEnumerable
    {
        private static int idCount = 0;
        private int standId;
        public int StandId
        {
            get
            {
                return standId;
            }
        }

        private List<Vendor> vendors;
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

        public int CountOfVendors
        {
            get
            {
                return vendors.Count();
            }
        }
        public int GetCountOfClients
        {
            get
            {
                int count = 0;
                foreach (var vendor in this.vendors)
                {
                    count += vendor.Queue.ClientsInQueue.Count;
                }
                return count;
            }
        }

        public Stand()
        {
            idCount++;
            this.standId = idCount;
            this.vendors = new List<Vendor>();
            this.time_of_service = -1;
        }

        public Stand(int timeOfService)
        {
            idCount++;
            this.standId = idCount;
            this.vendors = new List<Vendor>();
            this.time_of_service = timeOfService;
        }

        public void AddVendor(Vendor vendor)
        {
            vendor.TimeOfService = this.time_of_service;
            vendors.Add(vendor);
        }
        public void AddVendor()
        {
            Vendor vendor = new Vendor(this);
            vendor.TimeOfService = this.time_of_service;
            vendors.Add(vendor);
        }
        public void RemoveVendor(int Id)
        {
            var vendor = vendors.FirstOrDefault(vend => vend.VendorID == Id);
            if (vendor != null)
            {
                vendors.Remove(vendor);                
            }
        }
        public int GetIdOfVendorWithMinClients()
        {
            int minCount = this.vendors[0].CountOfClients;
            int minId = this.vendors[0].VendorID;
            for (int i = 1; i < this.vendors.Count; ++i)
            {
                if (this.vendors[i].CountOfClients < minCount)
                {
                    minCount = this.vendors[i].CountOfClients;
                    minId = this.vendors[i].VendorID;
                }
            }
            return minId;
        }

        public void Clear()
        {
            vendors.Clear();
        }

        public Vendor this[int ID]
        {
            get
            {
                return vendors.FirstOrDefault(vendor => vendor.VendorID == ID);
            }
        }

        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public StandEnum GetEnumerator()
        {
            return new StandEnum(this.vendors);
        }

        public class StandEnum : IEnumerator
        {
            private List<Vendor> vendors;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public StandEnum(List<Vendor> vendorsList)
            {
                vendors = vendorsList;
            }

            public bool MoveNext()
            {
                position++;
                return (position < vendors.Count);
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

            public Vendor Current
            {
                get
                {
                    try
                    {
                        return vendors[position];
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
