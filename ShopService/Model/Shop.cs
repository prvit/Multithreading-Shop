﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopService.Model
{
    public class Shop : IEnumerable
    {
        private List<Stand> stands;
        public List<Stand> Stands
        {
            get
            {
                return this.stands;
            }
        }
        public int CountOfStands
        {
            get
            {
                return stands.Count();
            }
        }
        public Shop(int countOfStands)
        {
            stands = new List<Stand>(countOfStands);
        }
        public void AddStand(int standTimeOfService, int price)
        {
            stands.Add(new Stand(standTimeOfService, price));
        }
        public void RemoveStand(int standId)
        {
            var standToRemove = this.stands.FirstOrDefault(stand => stand.StandId == standId);
            stands.Remove(standToRemove);
        }
        public Stand this[int ID]
        {
            get
            {
                return stands.FirstOrDefault(stand => stand.StandId == ID);
            }
        }
        public List<Stand> GetStandsClientWasNotBefore(Client client)
        {
            List<Stand> listOfStands = new List<Stand>();
            foreach (var stand in this)
            {
                if (client.VisitedStands[stand.StandId] == false)
                {
                    listOfStands.Add(stand);
                }
            }
            return listOfStands;
        }
        public void Clear()
        {
            this.stands.Clear();
        }

        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ShopEnum GetEnumerator()
        {
            return new ShopEnum(this.stands);
        }

        public class ShopEnum : IEnumerator
        {
            private List<Stand> stands;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public ShopEnum(List<Stand> standsList)
            {
                stands = standsList;
            }

            public bool MoveNext()
            {
                position++;
                return (position < stands.Count);
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

            public Stand Current
            {
                get
                {
                    try
                    {
                        return stands[position];
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
