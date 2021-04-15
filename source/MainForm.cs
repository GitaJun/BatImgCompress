
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImgCompresser.Classess;

namespace ImgCompresser
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 跨线程修改WinForm控件所需的委托
        /// </summary>
        private readonly Action<string> append;

        public MainForm()
        {
            InitializeComponent();

            BindComponentEvent();

            append = AppendDetail;
        }

        /// <summary>
        /// 绑定控件的用户响应事件
        /// </summary>
        private void BindComponentEvent()
        {
            bt_chooseFolder.Click += (sender, args) =>  //图片选择
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tb_imgFloder.Text = folderBrowserDialog.SelectedPath;
                }
            };

            tb_flag.Click += (sender, args) => { tb_flag.Clear(); };
            tb_size.Click += (sender, args) => { tb_size.Clear(); };

            bt_compress.Click += OnCompressClick;  //压缩
        }

        private void AppendDetail(string detail)
        {
            tb_detail.AppendText(detail);
        }

        private void OnCompressClick(object sender, EventArgs e)
        {
            Task.Run(
                () =>
                {
                    tb_detail.Invoke(append, "开始压缩".PadCenter(30, '*').EnterLine(2));

                    int count = 0, total = 0;  //任务统计
                    List<FileInfo> imgs = new ImgCollector().CollectImg(new DirectoryInfo(tb_imgFloder.Text));  //图片收集
                    Queue<Task> tasks = new Queue<Task>();  //任务列表
                    Task[] taskWindow = new Task[int.Parse(tb_maxTask.Text)];  //任务窗口 - 同时运行的任务
        
                    /*遍历筛选图片，注册多任务列表*/
                    foreach (var file in imgs)
                    {
                        if (file.Length < long.Parse(tb_size.Text) * 1024) continue;

                        tasks.Enqueue(new Task(  //创建任务列表
                            () =>
                            {
                                tb_detail.Invoke(append, $"正在压缩图片：{file.FullName}".EnterLine(2));
                                string fileName = file.Name.Substring(0, file.Name.LastIndexOf(file.Extension));  //文件名字（不包括.后缀）
                                string dFile = $@"{file.DirectoryName}\\{fileName}_Compressed{file.Extension}";
                                int flag = int.Parse(tb_flag.Text);

                                if (CompressionCore.CompressImageRec(file.FullName, dFile, flag, int.Parse(tb_size.Text)))
                                {
                                    File.Delete(file.FullName);  //删除原文件
                                    FileInfo newFile = new FileInfo(dFile);  //压缩后新文件的实例
                                    newFile.MoveTo($@"{newFile.DirectoryName}\\{fileName}{newFile.Extension}");  //重命名新文件为原名字
                                    count++;

                                    tb_detail.Invoke(append, $"已压缩图片：{file.FullName}".EnterLine(2));
                                }
                            }));
                    }

                    /*在完成所有任务前轮询任务窗口开启任务*/
                    total = tasks.Count;
                    while (count < total)
                    {
                        for (int i = 0; i < taskWindow.Length; i++)
                        {
                            if (tasks.Count > 0)
                            {
                                if (taskWindow[i] is null)
                                {
                                    taskWindow[i] = tasks.Dequeue();
                                    taskWindow[i].Start();
                                }
                                else if (taskWindow[i].Status == TaskStatus.RanToCompletion)
                                {
                                    taskWindow[i].Dispose();
                                    taskWindow[i] = tasks.Dequeue();
                                    taskWindow[i].Start();
                                }
                            }
                        }

                        Thread.Sleep(500);
                    }

                    tb_detail.Invoke(append, $"压缩完成".PadCenter(15, '*').EnterLine(2));
                    MessageBox.Show($"已压缩{count}张图片");
                });
        }
    }
}
