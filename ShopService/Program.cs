using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopService.Management;
using System.Threading;
using ShopService.Utilities;

namespace ShopService
{
    public class Program
    {
        static void Main()
        {
            Logger.SetUpLogFile("");
            Logger.LogInfo("Shop started");
            Console.WriteLine("Shop started.");


            ShopManager shopManager = new ShopManager();
            Timer timer = new Timer(close, shopManager, 20000, 40000);

            shopManager.TestShopFill();
            shopManager.PushClients(50);
            shopManager.StartOrganizeThread();
            shopManager.StartProceedingThreads();
            //shopManager.PushClients(100);
            //shopManager.PushClients(100);

            Console.Read();
        }
        static private void Push100(object sm)
        {
            Thread.Sleep(5000);
            ShopManager shopManager = (ShopManager)sm;
            shopManager.PushClients(100);
        }
        static void close(object state)
        {
            ShopManager sm = (ShopManager)state;
            sm.CloseShop();
        }
    }
}
