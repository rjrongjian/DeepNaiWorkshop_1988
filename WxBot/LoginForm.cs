using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WxBot.MyTool;

namespace WxBot
{
    public partial class LoginForm : Form
    {
        private byte[] qrCode;
        public LoginForm(byte[] qrCode)
        {
            this.qrCode = qrCode;
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("开始加载图片...");
            label1.Text = "微信扫码以登陆平台";
            Image qrCodeImg = ImageHelper.BytesToImage(qrCode);
            //qrCodeImg.Save(@"D:\test2\tupian.jpg");
            //加载获取的二维码
            qrCodePictureBox.Image = qrCodeImg;
            //qrCodePictureBox.BackgroundImage = qrCodeImg;
            
        }

        internal void DisplayQrCodeLogin(byte[] qrCodeImgBytes, string info)
        {
            label1.Text = info;
            Image qrCodeImg = ImageHelper.BytesToImage(qrCodeImgBytes);
            //qrCodeImg.Save(@"D:\test2\tupian.jpg");
            //加载获取的二维码
            qrCodePictureBox.Image = qrCodeImg;
        }
    }
}
