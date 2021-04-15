
namespace ImgCompresser
{
    partial class MainForm
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
            this.bt_compress = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bt_chooseFolder = new System.Windows.Forms.Button();
            this.tb_imgFloder = new System.Windows.Forms.TextBox();
            this.tb_detail = new System.Windows.Forms.TextBox();
            this.tb_size = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_flag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_maxTask = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_compress
            // 
            this.bt_compress.Location = new System.Drawing.Point(12, 320);
            this.bt_compress.Name = "bt_compress";
            this.bt_compress.Size = new System.Drawing.Size(525, 31);
            this.bt_compress.TabIndex = 0;
            this.bt_compress.Text = "压缩";
            this.bt_compress.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "请选择图片文件夹";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // bt_chooseFolder
            // 
            this.bt_chooseFolder.Location = new System.Drawing.Point(437, 11);
            this.bt_chooseFolder.Name = "bt_chooseFolder";
            this.bt_chooseFolder.Size = new System.Drawing.Size(100, 21);
            this.bt_chooseFolder.TabIndex = 1;
            this.bt_chooseFolder.Text = "选择图片文件夹";
            this.bt_chooseFolder.UseVisualStyleBackColor = true;
            // 
            // tb_imgFloder
            // 
            this.tb_imgFloder.Location = new System.Drawing.Point(12, 12);
            this.tb_imgFloder.Name = "tb_imgFloder";
            this.tb_imgFloder.Size = new System.Drawing.Size(419, 21);
            this.tb_imgFloder.TabIndex = 2;
            // 
            // tb_detail
            // 
            this.tb_detail.Location = new System.Drawing.Point(12, 70);
            this.tb_detail.Multiline = true;
            this.tb_detail.Name = "tb_detail";
            this.tb_detail.ReadOnly = true;
            this.tb_detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_detail.Size = new System.Drawing.Size(525, 244);
            this.tb_detail.TabIndex = 3;
            this.tb_detail.TabStop = false;
            // 
            // tb_size
            // 
            this.tb_size.Location = new System.Drawing.Point(354, 43);
            this.tb_size.Name = "tb_size";
            this.tb_size.Size = new System.Drawing.Size(25, 21);
            this.tb_size.TabIndex = 4;
            this.tb_size.Text = "200";
            this.tb_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "文件大小(KB)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "压缩质量(1-100)：";
            // 
            // tb_flag
            // 
            this.tb_flag.Location = new System.Drawing.Point(512, 43);
            this.tb_flag.Name = "tb_flag";
            this.tb_flag.Size = new System.Drawing.Size(25, 21);
            this.tb_flag.TabIndex = 6;
            this.tb_flag.Text = "90";
            this.tb_flag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "最大任务数：";
            // 
            // tb_maxTask
            // 
            this.tb_maxTask.Location = new System.Drawing.Point(228, 43);
            this.tb_maxTask.Name = "tb_maxTask";
            this.tb_maxTask.Size = new System.Drawing.Size(25, 21);
            this.tb_maxTask.TabIndex = 8;
            this.tb_maxTask.Text = "2";
            this.tb_maxTask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 364);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_maxTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_flag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_size);
            this.Controls.Add(this.tb_detail);
            this.Controls.Add(this.tb_imgFloder);
            this.Controls.Add(this.bt_chooseFolder);
            this.Controls.Add(this.bt_compress);
            this.Name = "MainForm";
            this.Text = "图片压缩";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_compress;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button bt_chooseFolder;
        private System.Windows.Forms.TextBox tb_imgFloder;
        private System.Windows.Forms.TextBox tb_detail;
        private System.Windows.Forms.TextBox tb_size;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_flag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_maxTask;
    }
}

