using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WriteTxtServices
{
    public partial class WriteTxtServices : ServiceBase
    {
        public WriteTxtServices()
        {
            InitializeComponent();
        }

        Timer timer1=new Timer();
        protected override void OnStart(string[] args)
        {
            timer1.Interval = 1000;//设置计时器的事件间隔
            timer1.Elapsed+=new ElapsedEventHandler(timer1_Elapsed);
            timer1.Enabled = true;

        }


        //定时任务
        private void timer1_Elapsed(object sender ,ElapsedEventArgs args)
        {
            Task.Run(() =>
            {
                File.AppendAllText(@"F:\hello.txt", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff") + Environment.NewLine);
            });
        }

        protected override void OnStop()
        {
            timer1.Enabled=false;  
        }
    }
}
