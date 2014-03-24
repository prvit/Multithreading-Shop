using ShopService.Management;
using ShopService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ShopService.Utilities;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ShopManager shopManager;
        public MainWindow()
        {
            InitializeComponent();
            TextBlockLogger tblogger = new TextBlockLogger();
            tblogger.TextBlock = this.tb_logger;
            tblogger.Dispatcher = this.tb_logger.Dispatcher;
            sv_log.UpdateLayout();
            sv_log.ScrollToVerticalOffset(tb_logger.ActualHeight);
            tblogger.ScrollViewer = this.sv_log;
            Logger.SetUpLogFile("");
            Logger.LogInfo("Shop started");

            shopManager = new ShopManager(tblogger);

            shopManager.TestShopFill();
            //shopManager.PushClients(50);
            
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            shopManager.CloseShop();
        }

        private void btn_Open_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_Push_Click(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(this.tb_PushNumber.Text);
            shopManager.PushClients(num);
            shopManager.StartOrganizeThread();
            shopManager.StartProceedingThreads();
        }
    }
}
