using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopService.Management;
using ShopService.Model;
using ShopService.Utilities;
using System.Threading;
using Transitions;

namespace UI
{
    public partial class ShopForm : Form
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
        Dictionary<string, int> queueHeights;



        public ShopForm()
        {
            InitializeComponent();
            this.rtb_Log.Text = "";
            Logger.SetUpLogFile("", rtb_Log);

            shop = new Shop(15);
            shopClients = new ClientsQueue();
            organizingThread = new Thread(OrganizeClients);
            vendorsThreads = new Dictionary<int, Thread>();
            isShopClosing = false;
            TestShopFill();
            queueHeights = new Dictionary<string, int>();
            queueHeights.Add((string)this.gb_Stand1.Tag, this.gb_Stand1.Location.Y - 12);
            queueHeights.Add((string)this.gb_Stand2.Tag, this.gb_Stand1.Location.Y - 12);
            queueHeights.Add((string)this.gb_Stand3.Tag, this.gb_Stand1.Location.Y - 12);
            queueHeights.Add((string)this.gb_Stand4.Tag, this.gb_Stand1.Location.Y - 12);
            queueHeights.Add((string)this.gb_Stand5.Tag, this.gb_Stand1.Location.Y - 12);
            queueHeights.Add((string)this.gb_Overall.Tag, this.gb_Overall.Location.Y - 12);


            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (!organizingThread.IsAlive)
            {
                organizingThread.Start();
            }
            Thread newThread = new Thread(StartProceedingThreads);
            newThread.Start();
        }
        //private void rtb_LogText(string message)
        //{
        //    if (this.rtb_Log.InvokeRequired)
        //    {
        //        rtb_Log.Invoke(new Action(()=> rtb_Log.AppendText(message + Environment.NewLine)));   
        //    }
        //}

        
        public void PushClients(object countOfNewClients)
        {
            AddNewClients((int)countOfNewClients);
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
                    List<Stand> unvisitedStands = shop.GetStandsClientWasNotBefore(client);
                    if (unvisitedStands.Count > 1)
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
                            //rtb_LogText(line);
                            Client pulledClient = shopClients.Pull();
                            FindTag(this.Controls, getGroupBox(idOfStandToAddClient), "Client" + pulledClient.ClientID, true, (1000));

                        }
                    }
                    else
                    {
                        Client pulledClient = shopClients.Pull();
                        string line = String.Format("Client {0} quit shop.", pulledClient.ClientID);
                        string Tag = "Client" + pulledClient.ClientID;
                        quitShop(Tag);
                        Logger.LogInfo(line);
                        //rtb_LogText(line);

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
                    //rtb_LogText(line);
                }
            }
        }
        private void quitShop(string Tag)
        {
            Label labelToRemove = null;
            foreach (Label label in Controls.OfType<Label>())
            {
                if (label.Tag != null && label.Tag.ToString() == Tag)
                {
                    labelToRemove = label;
                }
            }
            Transition.run(labelToRemove, "BackColor", Color.Pink, new TransitionType_Flash(5, 500));
            Thread.Sleep(500);
            if (labelToRemove != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Controls.Remove(labelToRemove)));
                    if (labelToRemove.InvokeRequired)
                    {
                        labelToRemove.Invoke(new Action(() => labelToRemove.Dispose()));
                    }
                    else
                    {
                        labelToRemove.Dispose();
                    }
                }
                else
                {
                    this.Controls.Remove(labelToRemove);
                    labelToRemove.Dispose();
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
        private GroupBox getGroupBox(int id)
        {
            switch (id)
            {
                case 1:
                    return this.gb_Stand1;
                case 2:
                    return this.gb_Stand2;
                case 3:
                    return this.gb_Stand3;
                case 4:
                    return this.gb_Stand4;
                case 5:
                    return this.gb_Stand5;
                default:
                    return this.gb_Overall;
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
                    Thread.Sleep(time * 1000);
                    Client pulledClient = this.shop[currVendor.VendorStandId][currVendor.VendorID].Queue.Pull();
                    pulledClient.VisitedStands[currVendor.VendorStandId] = true;
                    string line = String.Format("Client {0} was served by {1} Vendor. (Stand {2})", pulledClient.ClientID, currVendor.VendorID, currVendor.VendorStandId);
                    Logger.LogInfo(line);
                    //FindTag(this.Controls, this.gb_Overall, "Client" + pulledClient.ClientID, false);
                    Console.WriteLine(line);
                    if (!isShopClosing)
                    {
                        this.shopClients.Push(pulledClient);
                        string ln = String.Format("Client {0} was sent to overall queue.", pulledClient.ClientID);
                        Logger.LogInfo(ln);
                        //FindTag(this.Controls, this.gb_Overall,"Client"+pulledClient.ClientID, true);

                        //rtb_LogText(ln);
                    }
                    else
                    {
                        string ln = String.Format("Client {0} quit a shop.", pulledClient.ClientID);
                        Logger.LogInfo(ln);
                        //rtb_LogText(ln);
                    }
                    redrawStand(currVendor.VendorStandId);
                }
                else
                {
                    //Thread.CurrentThread.Abort();
                }
            }
            //vendorsThreads[currVendor.VendorID].Abort();
        }
        private void redrawStand(int standId)
        {
            List<int> clientsId = new List<int>();
            foreach (var vendor in shop[standId])
            {
                foreach (var client in vendor.Queue.ClientsInQueue)
	            {
                    clientsId.Add(client.ClientID);
	            }
            }
            queueHeights["Stand" + standId] = 345 - 12;
            foreach (int id in clientsId)
            {
                FindTag(this.Controls, getGroupBox(standId), "Client" + id, false, 100);
            }
            
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
                    Label lbl = new Label()
                    {
                        Text = "Client "+ client.ClientID,
                        AutoSize = true,
                        Location = new System.Drawing.Point(702, 220),
                        Size = new System.Drawing.Size(35, 13),
                        Tag = "Client"+client.ClientID
                    };
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => this.Controls.Add(lbl)));
                    }
                    else
                    {
                        this.Controls.Add(lbl);
                    }
                    FindTag(this.Controls, this.gb_Overall, "Client" + client.ClientID, false, 1000);
                    //clientsRepresentation[client.ClientID].PerformLayout();
                    
                    

                    //rtb_LogText(line);
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

            for (int i = 1; i <= 5; i++)
			{
                int j = rand.Next(5,10);
                this.shop.AddStand(j);
			}
            foreach (var stand in shop)
            {
                    stand.AddVendor();                    
            }
        }

        private void btn_Push_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(PushClients);
            int count = Convert.ToInt32(tb_PushCount.Text);
            newThread.Start(count);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            CloseShop();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void AnimateControl(Control c, GroupBox gb, bool fromVendor, int speed)
        {
            lock (c)
            {
                int xDest = c.Location.X - (gb.Location.X + gb.Width / 2);
                int yDest = c.Location.Y - (queueHeights[(string)gb.Tag]);
                queueHeights[(string)gb.Tag] -= c.Height - 2;
                Transition t1 = new Transition(new TransitionType_Linear(speed));
                if (fromVendor)
                {
                    t1.add(c, "Top", gb.Top - 200);
                }

                t1.add(c, "Left", c.Left - xDest);

                Transition t2 = new Transition(new TransitionType_Linear(speed));
                t2.add(c, "Top", c.Top - yDest);

                Transition.runChain(t1, t2);
            }
        }
        private void FindTag(Control.ControlCollection controls, GroupBox gb, string Tag, bool flag, int speed)
        {
            foreach (Control c in controls)
            {
                if (c.Tag != null)
                {
                    if (c.Tag.Equals(Tag))
                    {
                        AnimateControl(c, gb, flag, speed);                        
                    }
                }
                    //logic

                if (c.HasChildren)
                {
                    FindTag(c.Controls, gb, Tag, flag, speed); //Recursively check all children controls as well; ie groupboxes or tabpages
                }
            }
        }
    }
}
