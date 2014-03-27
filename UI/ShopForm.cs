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
            
            vendorsThreads = new Dictionary<int, Thread>();
            isShopClosing = false;
            TestShopFill();
            queueHeights = new Dictionary<string, int>();
            queueHeights.Add((string)this.lbl_vendor1.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor2.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor3.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor4.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor5.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor6.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor7.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor8.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor9.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor10.Tag, this.gb_Stand1.Location.Y - 40);
            queueHeights.Add((string)this.lbl_vendor11.Tag, this.gb_Stand1.Location.Y - 40);


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
            if (organizingThread == null)
            {
                organizingThread = new Thread(OrganizeClients);
                organizingThread.Start();
            }
            else if (!organizingThread.IsAlive)
            {
                organizingThread = new Thread(OrganizeClients);
                organizingThread.Start();
            }
            Thread newThread = new Thread(StartProceedingThreads);
            newThread.Start();
        }
        
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
                    Client client = shopClients.GetMostSuitableClient();
                    shopClients.Pull(client);
                    Dictionary<int, int> busyStandsTime = new Dictionary<int, int>();
                    List<Stand> unvisitedStands = shop.GetStandsClientWasNotBefore(client);
                    if (unvisitedStands.Count > 0)
                    {
                        lock (shopClients)
                        {
                            foreach (var stand in unvisitedStands)
                            {
                                busyStandsTime.Add(stand.StandId, (stand.GetCountOfClients * stand.TimeOfService) / stand.CountOfVendors);// TODO better algo
                            }
                            int idOfStandToAddClient = KeyOfMin(busyStandsTime);
                            int idOfVendorToAddClient = shop[idOfStandToAddClient].GetIdOfVendorWithMinClients();
                            this.shop[idOfStandToAddClient][idOfVendorToAddClient].Queue.Push(client);
                            string line = String.Format("Client {0} was sent to {1} Vendor queue. (Stand {2})", client.ClientID, 
                                this.shop[idOfStandToAddClient][idOfVendorToAddClient].VendorID, this.shop[idOfStandToAddClient][idOfVendorToAddClient].VendorStandId);
                            
                            Logger.LogInfo(line);
                            //rtb_LogText(line);
                            //Client pulledClient = 
                            if (!vendorsThreads[idOfVendorToAddClient].IsAlive)
                            {
                                vendorsThreads[idOfVendorToAddClient] = new Thread(ProceedeClientsByVendor);
                                vendorsThreads[idOfVendorToAddClient].Start(this.shop[idOfStandToAddClient][idOfVendorToAddClient]);
                            }
                            FindTag(this.Controls, getLabel(idOfVendorToAddClient), "Client" + client.ClientID, true, (1000));

                        }
                    }
                    else
                    {
                        //Client pulledClient = shopClients.Pull();
                        string line = String.Format("Client {0} quit shop.", client.ClientID);
                        string Tag = "Client" + client.ClientID;
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
                    string Tag = "Client" + pulledClient.ClientID;
                    quitShop(Tag);
                    Logger.LogInfo(line);
                    //rtb_LogText(line);
                }
            }
        }

        private Label getLabel(int idOfVendorToAddClient)
        {
            switch (idOfVendorToAddClient)
            {
                case 1:
                    return this.lbl_vendor1;
                case 2:
                    return this.lbl_vendor2;
                case 3:
                    return this.lbl_vendor3;
                case 4:
                    return this.lbl_vendor4;
                case 5:
                    return this.lbl_vendor5;
                case 6:
                    return this.lbl_vendor6;
                case 7:
                    return this.lbl_vendor7;
                case 8:
                    return this.lbl_vendor8;
                case 9:
                    return this.lbl_vendor9;
                case 10:
                    return this.lbl_vendor10;
                case 11:
                    return this.lbl_vendor11;
                default:
                    return null;
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
            if (labelToRemove != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                        {
                            
                            this.Controls.Remove(labelToRemove);
                        }));
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
                        //vendorsThreads[vendor.VendorID].Start(vendor);
                    }

                    
                    //if (!vendorsThreads[vendor.VendorID].IsAlive)
                    //{
                    //    vendorsThreads[vendor.VendorID].Start(vendor);
                    //}
                }
            }
        }
        //private GroupBox getGroupBox(int id)
        //{
        //    switch (id)
        //    {
        //        case 1:
        //            return this.gb_Stand1;
        //        case 2:
        //            return this.gb_Stand2;
        //        case 3:
        //            return this.gb_Stand3;
        //        case 4:
        //            return this.gb_Stand4;
        //        case 5:
        //            return this.gb_Stand5;
        //        default:
        //            return null;
        //    }
        //}
        private void ProceedeClientsByVendor(object vendor)
        {
            Vendor currVendor = (Vendor)vendor;
            int time = currVendor.TimeOfService;
            while (currVendor.CountOfClients > 0)
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
                    addTotalMoneyEarned(this.shop[currVendor.VendorStandId].Price);
                    //FindTag(this.Controls, this.gb_Overall,"Client"+pulledClient.ClientID, true);

                    //rtb_LogText(ln);
                }
                else
                {
                    string ln = String.Format("Client {0} quit a shop.", pulledClient.ClientID);
                    addTotalMoneyEarned(this.shop[currVendor.VendorStandId].Price);
                    quitShop("Client"+pulledClient.ClientID);
                    Logger.LogInfo(ln);
                    //rtb_LogText(ln);
                }
                redrawVendorClients(currVendor.VendorStandId, currVendor.VendorID);
            }
            
            //Thread.CurrentThread.Abort();
        }

        private void addTotalMoneyEarned(int p)
        {
            if (this.label_money.InvokeRequired)
            {
                label_money.Invoke(new Action(() => label_money.Text = (Convert.ToInt32(label_money.Text) + p).ToString()));
            }
            else
            {
                label_money.Text = (Convert.ToInt32(label_money.Text) + p).ToString();
            }
        }
        private void redrawStand(int standId)
        {
            lock (shop[standId])
            {
                foreach (var vendor in shop[standId])
                {
                    redrawVendorClients(standId, vendor.VendorID);
                }
            }
            
        }
        private void redrawVendorClients(int standId, int vendorId)
        {
            queueHeights["Vendor" + vendorId] = 345 - 40;
            List<int> clientsId = new List<int>();
            lock (shop[standId][vendorId].Queue)
            {
                foreach (var client in shop[standId][vendorId].Queue.ClientsInQueue)
                {
                    clientsId.Add(client.ClientID);
                }
            }

            foreach (int id in clientsId)
            {
                FindTag(this.Controls, getLabel(vendorId), "Client" + id, false, 50);
            }
        }
        private void AddNewClients(object countOfNewClients)
        {
            int count = (int)countOfNewClients;
            lock (this.shopClients)
            {
                Random random = new Random();
                for (int i = 0; i < count; i++)
                {
                    Client client = new Client(this.shop); 
                    shopClients.Push(client);
                    string line = String.Format("Client {0} was pushed to shop.", client.ClientID);
                    Logger.LogInfo(line);

                    int rnd = random.Next(1,8);
                    Image image = Image.FromFile(@"E:\GitHub\Multithreading-Shop\images\"+rnd+".bmp"); // read in image

                    Label lbl = new Label()
                    {
                        Text = client.ClientID.ToString(),
                        Location = new System.Drawing.Point(464, 16),
                        Tag = "Client"+client.ClientID,
                        Image = image,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        TextAlign = ContentAlignment.MiddleRight,
                        AutoSize = false,
                        Size = new System.Drawing.Size(image.Width + 30, image.Height)
                        //Size = new Size(image.Width, image.Height)
                    };
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => this.Controls.Add(lbl)));
                    }
                    else
                    {
                        this.Controls.Add(lbl);
                    }
                    lock (lbl)
                    {
                        FindTag(this.Controls, null, "Client" + lbl.Tag, false, 1000);
                    }
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
            this.shop.AddStand(3, 7);
            this.shop.AddStand(5, 11);
            this.shop.AddStand(10, 20);
            this.shop.AddStand(1, 3);
            this.shop.AddStand(8, 5);
            this.shop[1].AddVendor();
            this.shop[1].AddVendor();
            this.shop[1].AddVendor();
            this.shop[2].AddVendor();
            this.shop[2].AddVendor();
            this.shop[3].AddVendor();
            this.shop[3].AddVendor();
            this.shop[4].AddVendor();
            this.shop[5].AddVendor();
            this.shop[5].AddVendor();
            this.shop[5].AddVendor();
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

        private void AnimateControl(Control c, Control controlTo, bool fromVendor, int speed)
        {
            lock (c)
            {
                int xDest = c.Location.X - (controlTo.Location.X);// + controlTo.Width / 2);
                int yDest = c.Location.Y - (queueHeights[(string)controlTo.Tag]);
                queueHeights[(string)controlTo.Tag] -= c.Height + 10;
                Transition t1 = new Transition(new TransitionType_Linear(speed));
                if (fromVendor)
                {
                    t1.add(c, "Top", controlTo.Top - 250);
                }

                t1.add(c, "Left", c.Left - xDest);

                Transition t2 = new Transition(new TransitionType_Linear(speed));
                t2.add(c, "Top", c.Top - yDest);

                Transition.runChain(t1, t2);
            }
        }
        private void FindTag(Control.ControlCollection controls, Control gb, string Tag, bool flag, int speed)
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
