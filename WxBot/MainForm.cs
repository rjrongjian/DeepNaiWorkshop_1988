using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChatAPI;
using WeChatAPI.Modal.Response;

namespace WxBot
{
    public partial class MainForm : Form
    {
        private LoginForm loginForm;
        private Client client;
        public MainForm()
        {
            InitializeComponent();
        }

        internal void DisplayQrCodeLogin(byte[] qrCodeImgBytes)
        {
            loginForm = new LoginForm(qrCodeImgBytes);
            loginForm.ShowDialog();
        }

        public void DisplayQrCodeLogin(byte[] qrCodeImgBytes,string info)
        {
            loginForm.DisplayQrCodeLogin(qrCodeImgBytes, info);
        }

        public void CloseLoginForm()
        {
            loginForm.Close();
        }
        //测试发送
        private void button1_Click(object sender, EventArgs e)
        {
            SendMsgResponse response = client.SendMsg(textBox3.Text,textBox2.Text);
            if (response.BaseResponse.Ret == 0)
            {
                MessageBox.Show("发送成功");
            }
            else
            {
                MessageBox.Show("发送失败");
            }
        }

        internal void setWxApi(Client client)
        {
            this.client = client;
        }

        internal void disPlayMessage(string v)
        {
            this.textBox1.Text = v;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //选择订单数据
            OpenFileDialog file = new OpenFileDialog();
            //file.Filter = "(excel文件)|*.xls";
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = file.FileName;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMsgResponse response = client.SendMsg(new FileInfo(textBox5.Text), textBox4.Text);
            if (response.BaseResponse.Ret == 0)
            {
                MessageBox.Show("发送成功");
            }
            else
            {
                MessageBox.Show("发送失败");
            }
        }
    }
}
