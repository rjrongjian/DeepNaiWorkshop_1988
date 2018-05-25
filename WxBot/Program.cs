using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChatAPI;
using WeChatAPI.Modal;
using WeChatAPI.Modal.Response;

namespace WxBot
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// 必须在.net framework 4.52版本才能跑 和netstand有关 https://codehollow.com/2017/05/port-net-framework-net-standard/
        /// </summary>
        [STAThread]
        static void Main()
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            MyPlugin.MyPlugin myPlugin = new MyPlugin.MyPlugin();

            Client client = new Client();
            client.ExceptionCatched += myPlugin.Client_ExceptionCatched;
            client.GetLoginQrCodeComplete += myPlugin.Client_GetLoginQrCodeComplete; 
            client.CheckScanComplete += myPlugin.Client_CheckScanComplete; ;
            client.LoginComplete += myPlugin.Client_LoginComplete; 
            client.BatchGetContactComplete += myPlugin.Client_BatchGetContactComplete; 
            client.GetContactComplete += myPlugin.Client_GetContactComplete; 
            client.MPSubscribeMsgListComplete += myPlugin.Client_MPSubscribeMsgListComplete; 
            client.LogoutComplete += myPlugin.Client_LogoutComplete; 
            client.ReceiveMsg += myPlugin.Client_ReceiveMsg; 
            client.DelContactListComplete += myPlugin.Client_DelContactListComplete; 
            client.ModContactListComplete += myPlugin.Client_ModContactListComplete;
            
            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();
            myPlugin.SetWxApi(client);
            myPlugin.SetMainForm(mainForm);
            mainForm.setWxApi(client);
            client.Start();
            Application.Run(mainForm);
        }

        
    }
}
