using SS.Toolkit.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine(string.Equals("Domain", "domain", StringComparison.OrdinalIgnoreCase));
            Add("wxuin=3481460434; Domain=wx2.qq.com; Path=/; Expires=Wed, 23-May-2018 19:22:47 GMT");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void Add(string cookieStr)
        {
            Cookie cookie = new Cookie();
            var keys = cookieStr.Split(';');
            foreach (var item in keys)
            {
                if (item.IndexOf('=') != -1)
                {
                    var k = item.Split('=')[0];
                    var v = item.Split('=')[1];
                    if (string.Equals(k, "path", StringComparison.OrdinalIgnoreCase))
                    {
                        cookie.Path = v;
                    }
                    else if (string.Equals(k, "domain", StringComparison.OrdinalIgnoreCase))
                    {
                        cookie.Domain = v;
                    }
                    else if (string.Equals(k, "version", StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.TryParse(v, out int version))
                        {
                            cookie.Version = version;
                        }
                    }
                    else if (string.Equals(k, "comment", StringComparison.OrdinalIgnoreCase))
                    {
                        cookie.Comment = v;
                    }
                    else
                    {
                        cookie.Name = k;
                        cookie.Value = v;
                    }
                }
                else
                {
                    if (string.Equals(item, "secure ", StringComparison.OrdinalIgnoreCase))
                    {
                        cookie.Secure = true;
                    }
                    else if (string.Equals(item, "httponly ", StringComparison.OrdinalIgnoreCase))
                    {
                        cookie.HttpOnly = true;
                    }
                }
            }
        }
    }
}
