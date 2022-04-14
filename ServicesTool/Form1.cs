using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesTool
{
    public partial class Form1 : Form
    {
        /*
         * 
         * cmd命令（管理员运行）
         * cd C:\Windows\Microsoft.NET\Framework\v4.0.30319
         * InstallUtil F:\Learning\WindowsServicesTest\WriteTxtServices\WriteTxtServices\bin\Debug\WriteTxtServices.exe    ----------安装服务
         * InstallUtil -u F:\Learning\WindowsServicesTest\WriteTxtServices\WriteTxtServices\bin\Debug\WriteTxtServices.exe  ----------卸载服务
         * net start WriteTxtServices --------开启服务
         * net stop WriteTxtServices  ---------停止服务
         * sc delete WriteTxtServices ---------删除服务
         * 
         * 
         */
        public Form1()
        {
            InitializeComponent();
        }

        //设置服务地址和服务名
        protected string serviceFilePath = string.Empty;
        protected string serviceName = string.Empty;
        protected string CfgFile = string.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程检查
            Control.CheckForIllegalCrossThreadCalls = false;

            //配置文件地址
            //CfgFile = $"{Application.StartupPath}/LocalInfo.config";
            CfgFile = Directory.GetCurrentDirectory() + "\\LocalInfo.config";

            //服务程式地址       
            serviceFilePath = AppConfigHelper.GetAppSetting(CfgFile, "serviceFilePath", "");
            serviceName = AppConfigHelper.GetAppSetting(CfgFile, "serviceName", "");

            if (serviceFilePath=="" || serviceName=="")
            {
                MessageBox.Show("请先在配置文件中设置服务的地址和名称！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                base.Close();
                return;
            }

            timer1.Interval = 100;
            timer1.Enabled = true;
        }


       

        //安装服务
        private void bt_Install_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ShowMessage("开始安装服务...");
                if (IsServiceExisted(serviceName))
                {
                    UninstallService(serviceFilePath);
                }
                InstallService(serviceFilePath);
            });
        }


        //启动服务
        private void bt_Start_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ShowMessage("服务正在启动...");
                if (IsServiceExisted(serviceName))
                {
                    ServiceStart(serviceName);
                    ShowMessage("服务已启动");
                }

            });
        }


        //停止服务
        private void bt_Stop_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ShowMessage("服务正在停止...");
                if (IsServiceExisted(serviceName))
                {
                    ServiceStop(serviceName);
                    ShowMessage("服务已停止");
                }
            });
        }


        //卸载服务
        private void bt_Uninstall_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ShowMessage("开始卸载服务...");
                if (this.IsServiceExisted(serviceName))
                {
                    this.ServiceStop(serviceName);
                }
                this.UninstallService(serviceFilePath);
            });
        }


        #region 方法封装
        private void ShowMessage(string s)
        {
            Action setState = () =>
            {
                rtbMSG.AppendText(DateTime.Now.ToString("f") + "：");
                rtbMSG.AppendText(Environment.NewLine);
                rtbMSG.AppendText(s);
                rtbMSG.AppendText(Environment.NewLine);

            };
            rtbMSG.Invoke(setState);
        }

        //判断服务是否存在
        private bool IsServiceExisted(string serviceName)
        {
            try
            {
                ServiceController[] services = ServiceController.GetServices();
                foreach (ServiceController sc in services)
                {
                    if (sc.ServiceName.ToLower() == serviceName.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return false;
            }
        }

        //安装服务
        private void InstallService(string serviceFilePath)
        {
            try
            {
                using (AssemblyInstaller installer = new AssemblyInstaller())
                {
                    installer.UseNewContext = true;
                    installer.Path = serviceFilePath;
                    IDictionary savedState = new Hashtable();
                    installer.Install(savedState);
                    installer.Commit(savedState);
                    ShowMessage("服务安装完成");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        //卸载服务
        private void UninstallService(string serviceFilePath)
        {
            try
            {
                using (AssemblyInstaller installer = new AssemblyInstaller())
                {
                    installer.UseNewContext = true;
                    installer.Path = serviceFilePath;
                    installer.Uninstall(null);
                    ShowMessage("服务卸载完成");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        //启动服务
        private void ServiceStart(string serviceName)
        {
            try
            {
                using (ServiceController control = new ServiceController(serviceName))
                {
                    if (control.Status == ServiceControllerStatus.Stopped)
                    {
                        control.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }


        //停止服务
        private void ServiceStop(string serviceName)
        {
            try
            {
                using (ServiceController control = new ServiceController(serviceName))
                {
                    if (control.Status == ServiceControllerStatus.Running)
                    {
                        control.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        #endregion

        #region 页面元素
       
        //btn状态
        private void ButtonState()
        {
            if (IsServiceExisted(serviceName))
            {
                bt_Install.Enabled = false;
                bt_Uninstall.Enabled = true;
                using (var service = new ServiceController(serviceName))
                {
                    if (service.Status == ServiceControllerStatus.Running || service.Status == ServiceControllerStatus.StartPending)
                    {
                        bt_Uninstall.Enabled = false;
                        bt_Start.Enabled = false;
                        bt_Stop.Enabled = true;
                    }
                    else
                    {
                        bt_Uninstall.Enabled = true;
                        bt_Start.Enabled = true;
                        bt_Stop.Enabled = false;
                    }
                }
            }
            else
            {
                bt_Install.Enabled = true;
                bt_Uninstall.Enabled = false;
                bt_Start.Enabled = false;
                bt_Stop.Enabled = false;
            }
        }
        //底部label状态
        private void LabelState()
        {
            if (!IsServiceExisted(serviceName))
            {
                this.labState.Text = $"【{serviceName}】服务未安装";
                return;
            }
            using (var service = new ServiceController(serviceName))
            {
                switch (service.Status)
                {
                    case ServiceControllerStatus.Running:
                        this.labState.Text = $"【{serviceName}】服务已启动";
                        break;
                    case ServiceControllerStatus.StartPending:
                        this.labState.Text = $"【{serviceName}】服务正在启动...";
                        break;
                    case ServiceControllerStatus.Stopped:
                        this.labState.Text = $"【{serviceName}】服务已停止";
                        break;
                    case ServiceControllerStatus.StopPending:
                        this.labState.Text = $"【{serviceName}】服务正在停止...";
                        break;
                    default:
                        break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonState();
            LabelState();
        }

        #endregion
    }
}
