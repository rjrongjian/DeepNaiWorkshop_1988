using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxBot.MyTool
{
    class MyLogUtil
    {
        public static void writeMessageLog(string str)
        {
            StreamWriter streamWriter = new StreamWriter("Message.txt", true);
            streamWriter.WriteLine(DateTime.Now.ToLongTimeString() + "=>" + str);
            streamWriter.WriteLine("---------------------------------------------------------");
            streamWriter.Close();
            
        }
    }
}
