using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI;
using WeChatAPI.Modal;
using WeChatAPI.Modal.Response;
using WxBot.MyTool;

namespace WxBot.MyPlugin
{
    class MyPlugin
    {
        private Client wxApi;
        private LoginForm loginForm;
        private MainForm mainForm;



        //修改联系人完成
        public void Client_ModContactListComplete(object sender, TEventArgs<List<ModContactItem>> e)
        {
            Console.WriteLine("修改联系人完成");
        }
        //删除联系人完成
        public void Client_DelContactListComplete(object sender, TEventArgs<List<DelContactItem>> e)
        {
            Console.WriteLine("删除联系人完成");
        }
        //接收消息
        public void Client_ReceiveMsg(object sender, TEventArgs<List<AddMsg>> e)
        {
            StringBuilder sbForDisplay = new StringBuilder();

            foreach (AddMsg addMsg in e.Result)
            {

                string message = String.Format("\"MsgId\":\"{0}\",\"FromUserName\":\"{1}\",\"ToUserName\":\"{2}\",\"MsgType\":\"{3}\",\"Content\":\"{4}\",\"Status\":{5},\"ImgStatus\":{6},\"CreateTime\":{7},\"VoiceLength\":{8},\"PlayLength\":{9},\"FileName\":\"{10}\",\"FileSize\":\"{11}\",\"MediaId\":\"{12}\",\"Url\":\"{13}\",\"AppMsgType\":{14},\"StatusNotifyCode\":\"{15}\",\"StatusNotifyUserName\":\"{16}\",\"ForwardFlag\":{17},\"HasProductId\":{18},\"Ticket\":\"{19}\",\"ImgHeight\":{20},\"ImgWidth\":{21},\"SubMsgType\":{22},\"NewMsgId\":{23},\"OriContent\":\"{24}\",", addMsg.MsgId, addMsg.FromUserName, addMsg.ToUserName, addMsg.MsgType.ToString(), addMsg.Content, addMsg.Status, addMsg.ImgStatus, addMsg.CreateTime, addMsg.VoiceLength, addMsg.PlayLength, addMsg.FileName, addMsg.FileSize, addMsg.MediaId, addMsg.Url, addMsg.AppMsgType, addMsg.StatusNotifyCode.ToString(), addMsg.StatusNotifyUserName, addMsg.ForwardFlag, addMsg.HasProductId, addMsg.Ticket, addMsg.ImgHeight, addMsg.ImgWidth, addMsg.SubMsgType, addMsg.NewMsgId, addMsg.OriContent);
                string recommendInfo = string.Format("\"UserName\":\"{0}\",\"NickName\":\"{1}\",\"QQNum\":{2},\"Province\":\"{3}\",\"City\":\"{4}\",\"Content\":\"{5}\",\"Signature\":\"{6}\",\"Alias\":\"{7}\",\"Scene\":{8},\"VerifyFlag\":{9},\"AttrStatus\":{10},\"Sex\":{11},\"Ticket\":\"{12}\",\"OpCode\":\"{13}\",", addMsg.RecommendInfo.UserName, addMsg.RecommendInfo.NickName, addMsg.RecommendInfo.QQNum, addMsg.RecommendInfo.Province, addMsg.RecommendInfo.City, addMsg.RecommendInfo.Content, addMsg.RecommendInfo.Signature, addMsg.RecommendInfo.Alias, addMsg.RecommendInfo.Scene, addMsg.RecommendInfo.VerifyFlag, addMsg.RecommendInfo.AttrStatus, addMsg.RecommendInfo.Sex, addMsg.RecommendInfo.Ticket, addMsg.RecommendInfo.OpCode);
                string addInfo = string.Format("\"AppID\":\"{0}\",\"Type\":{1}", addMsg.AppInfo.AppID, addMsg.AppInfo.Type);
                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                sb.Append(message);
                sb.Append("\"RecommendInfo\":{");
                sb.Append(recommendInfo);
                sb.Append("},\"AddInfo\":{");
                sb.Append(addInfo);
                sb.Append("}}");
                MyLogUtil.writeMessageLog(sb.ToString());
                sbForDisplay.Append(sb.ToString() + "\r\n");
            }
            mainForm.disPlayMessage(sbForDisplay.ToString());
        
        }
        //登出完成
        public void Client_LogoutComplete(object sender, TEventArgs<User> e)
        {
            Console.WriteLine("登出完成");
        }
        //公众号文章读取完成
        public void Client_MPSubscribeMsgListComplete(object sender, TEventArgs<List<MPSubscribeMsg>> e)
        {
            Console.WriteLine("公众号文章读取完成");
        }
        //获取联系人列表
        public void Client_GetContactComplete(object sender, TEventArgs<List<Contact>> e)
        {
            Console.WriteLine("获取联系人列表");
        }
        //批次读取联系人信息
        public void Client_BatchGetContactComplete(object sender, TEventArgs<List<Contact>> e)
        {
            Console.WriteLine("批次读取联系人信息");
        }
        //用户登陆完成，返回当前用户登陆信息
        public void Client_LoginComplete(object sender, TEventArgs<User> e)
        {
            mainForm.CloseLoginForm();
            mainForm.Show();


            Console.WriteLine("用户登陆完成，返回当前用户登陆信息");
        }

        internal void SetWxApi(Client client)
        {
            wxApi = client;
        }

        internal void SetMainForm(MainForm welcomeForm)
        {
            this.mainForm = welcomeForm;
        }

        //用户扫码完成
        public void Client_CheckScanComplete(object sender, TEventArgs<byte[]> e)
        {
            //头像返回
            mainForm.DisplayQrCodeLogin(e.Result,"请在手机端确认登陆");


            //Console.WriteLine("用户扫码完成");
        }
        //获取登陆二维码完成
        public void Client_GetLoginQrCodeComplete(object sender, TEventArgs<byte[]> e)
        {
            //显示二维码登陆窗口
            mainForm.DisplayQrCodeLogin(e.Result);


            Console.WriteLine("获取登陆二维码完成");
        }
        //异步调用的异常都会反馈在这里。
        public void Client_ExceptionCatched(object sender, TEventArgs<Exception> e)
        {
            Console.WriteLine("异常信息："+e.Result);
            Console.WriteLine("异步调用的异常都会反馈在这里");
        }
    }
}
