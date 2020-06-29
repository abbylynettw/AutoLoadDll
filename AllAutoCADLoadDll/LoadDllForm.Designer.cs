namespace AllAutoCADLoadDll
{
    partial class LoadDllForm
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
            this.listBoxAutoCAD = new System.Windows.Forms.ListBox();
            this.label_CadList = new System.Windows.Forms.Label();
            this.button_load = new System.Windows.Forms.Button();
            this.button_unload = new System.Windows.Forms.Button();
            this.labelAppName = new System.Windows.Forms.Label();
            this.textBox_AppName = new System.Windows.Forms.TextBox();
            this.textBox_AppDesc = new System.Windows.Forms.TextBox();
            this.labelAppDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxAutoCAD
            // 
            this.listBoxAutoCAD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxAutoCAD.FormattingEnabled = true;
            this.listBoxAutoCAD.ItemHeight = 20;
            this.listBoxAutoCAD.Location = new System.Drawing.Point(38, 60);
            this.listBoxAutoCAD.Name = "listBoxAutoCAD";
            this.listBoxAutoCAD.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxAutoCAD.Size = new System.Drawing.Size(445, 224);
            this.listBoxAutoCAD.TabIndex = 0;
            // 
            // label_CadList
            // 
            this.label_CadList.AutoSize = true;
            this.label_CadList.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CadList.Location = new System.Drawing.Point(34, 27);
            this.label_CadList.Name = "label_CadList";
            this.label_CadList.Size = new System.Drawing.Size(153, 19);
            this.label_CadList.TabIndex = 1;
            this.label_CadList.Text = "已安装的CAD版本";
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(133, 307);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(109, 27);
            this.button_load.TabIndex = 2;
            this.button_load.Text = "安装";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_unload
            // 
            this.button_unload.Location = new System.Drawing.Point(268, 307);
            this.button_unload.Name = "button_unload";
            this.button_unload.Size = new System.Drawing.Size(109, 27);
            this.button_unload.TabIndex = 2;
            this.button_unload.Text = "卸载";
            this.button_unload.UseVisualStyleBackColor = true;
            this.button_unload.Click += new System.EventHandler(this.button_unload_Click);
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.Location = new System.Drawing.Point(45, 177);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(82, 15);
            this.labelAppName.TabIndex = 3;
            this.labelAppName.Text = "程序名称：";
            this.labelAppName.Visible = false;
            // 
            // textBox_AppName
            // 
            this.textBox_AppName.Location = new System.Drawing.Point(133, 174);
            this.textBox_AppName.Name = "textBox_AppName";
            this.textBox_AppName.Size = new System.Drawing.Size(109, 25);
            this.textBox_AppName.TabIndex = 4;
            this.textBox_AppName.Text = "ExcelForm.dll";
            this.textBox_AppName.Visible = false;
            // 
            // textBox_AppDesc
            // 
            this.textBox_AppDesc.Location = new System.Drawing.Point(133, 205);
            this.textBox_AppDesc.Name = "textBox_AppDesc";
            this.textBox_AppDesc.Size = new System.Drawing.Size(109, 25);
            this.textBox_AppDesc.TabIndex = 6;
            this.textBox_AppDesc.Text = "导出Excel";
            this.textBox_AppDesc.Visible = false;
            // 
            // labelAppDesc
            // 
            this.labelAppDesc.AutoSize = true;
            this.labelAppDesc.Location = new System.Drawing.Point(45, 208);
            this.labelAppDesc.Name = "labelAppDesc";
            this.labelAppDesc.Size = new System.Drawing.Size(82, 15);
            this.labelAppDesc.TabIndex = 5;
            this.labelAppDesc.Text = "程序描述：";
            this.labelAppDesc.Visible = false;
            // 
            // LoadDllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 367);
            this.Controls.Add(this.textBox_AppDesc);
            this.Controls.Add(this.labelAppDesc);
            this.Controls.Add(this.textBox_AppName);
            this.Controls.Add(this.labelAppName);
            this.Controls.Add(this.button_unload);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.label_CadList);
            this.Controls.Add(this.listBoxAutoCAD);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.Name = "LoadDllForm";
            this.Text = "导出Excel安装程序";
            this.Load += new System.EventHandler(this.LoadDllForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAutoCAD;
        private System.Windows.Forms.Label label_CadList;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_unload;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.TextBox textBox_AppName;
        private System.Windows.Forms.TextBox textBox_AppDesc;
        private System.Windows.Forms.Label labelAppDesc;
    }
}

