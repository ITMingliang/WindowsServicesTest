namespace ServicesTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bt_Install = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Uninstall = new System.Windows.Forms.Button();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.bt_Start = new System.Windows.Forms.Button();
            this.rtbMSG = new System.Windows.Forms.RichTextBox();
            this.labState = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Install
            // 
            this.bt_Install.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Install.Location = new System.Drawing.Point(53, 45);
            this.bt_Install.Name = "bt_Install";
            this.bt_Install.Size = new System.Drawing.Size(134, 35);
            this.bt_Install.TabIndex = 0;
            this.bt_Install.Text = "安装服务";
            this.bt_Install.UseVisualStyleBackColor = true;
            this.bt_Install.Click += new System.EventHandler(this.bt_Install_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Uninstall);
            this.groupBox1.Controls.Add(this.bt_Stop);
            this.groupBox1.Controls.Add(this.bt_Start);
            this.groupBox1.Controls.Add(this.bt_Install);
            this.groupBox1.Location = new System.Drawing.Point(22, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 417);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "按钮操作";
            // 
            // bt_Uninstall
            // 
            this.bt_Uninstall.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Uninstall.Location = new System.Drawing.Point(53, 287);
            this.bt_Uninstall.Name = "bt_Uninstall";
            this.bt_Uninstall.Size = new System.Drawing.Size(134, 35);
            this.bt_Uninstall.TabIndex = 0;
            this.bt_Uninstall.Text = "卸载服务";
            this.bt_Uninstall.UseVisualStyleBackColor = true;
            this.bt_Uninstall.Click += new System.EventHandler(this.bt_Uninstall_Click);
            // 
            // bt_Stop
            // 
            this.bt_Stop.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Stop.Location = new System.Drawing.Point(53, 196);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(134, 35);
            this.bt_Stop.TabIndex = 0;
            this.bt_Stop.Text = "停止服务";
            this.bt_Stop.UseVisualStyleBackColor = true;
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click);
            // 
            // bt_Start
            // 
            this.bt_Start.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Start.Location = new System.Drawing.Point(53, 118);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(134, 35);
            this.bt_Start.TabIndex = 0;
            this.bt_Start.Text = "启动服务";
            this.bt_Start.UseVisualStyleBackColor = true;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // rtbMSG
            // 
            this.rtbMSG.Location = new System.Drawing.Point(299, 29);
            this.rtbMSG.Name = "rtbMSG";
            this.rtbMSG.Size = new System.Drawing.Size(435, 322);
            this.rtbMSG.TabIndex = 2;
            this.rtbMSG.Text = "";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labState.Location = new System.Drawing.Point(329, 381);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(93, 20);
            this.labState.TabIndex = 3;
            this.labState.Text = "提示信息";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 494);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.rtbMSG);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Windows服务工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Install;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Uninstall;
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.RichTextBox rtbMSG;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.Timer timer1;
    }
}

