using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WxBot
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;//线程间操作无效: 从不是创建控件“button1”的线程访问它。
            InitializeComponent();
        }
    }
}
