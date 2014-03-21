using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopService.Model
{
    public class Client
    {
        static int idCount = 0;
        private int clientID;
        public int ClientID
        {
            get
            { 
                return clientID; 
            }
        }

        private Dictionary<int, bool> visitedStands;
        public Dictionary<int, bool> VisitedStands
        {
            get
            {
                return this.visitedStands;
            }
        }

        public Client(Shop shop)
        {
            idCount++;
            this.clientID = idCount;

            visitedStands = new Dictionary<int, bool>();
            foreach (var stand in shop)
            {
                visitedStands.Add(stand.StandID, false);
            }
        }
    }
}
