﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WEC_Builder.Forms;

namespace WEC_Builder
{
    public partial class MainForm : Form
    {
        public const string url_root = "http://simpleweb.exmaru.com";

        public readonly string url_package = $"{url_root}/Content/release/latest.zip";
        public readonly string url_adm = $"{url_root}/Content/Download/Adm/latest.zip";

        public ConcurrentDictionary<string, string> Connections { get; set; } = new ConcurrentDictionary<string, string>();

        public ProjectInfo info { get; set; }

        public SqlConnection SqlConn { get; set; }

        public MainForm()
        {
            InitializeComponent();
            this.ProjectUnLoad();
        }

        private void 새프로젝트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QAForm qa = new QAForm(this);
            qa.Width = 600;
            qa.Height = 400;
            qa.WindowState = FormWindowState.Normal;
            qa.StartPosition = FormStartPosition.CenterParent;
            qa.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            qa.ShowInTaskbar = false;
            qa.Text = "새 프로젝트 만들기";
            qa.ShowDialog();
        }

        private void 프로젝트불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm la = new LoadForm(this);
            la.Width = 600;
            la.Height = 400;
            la.WindowState = FormWindowState.Normal;
            la.StartPosition = FormStartPosition.CenterParent;
            la.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            la.ShowInTaskbar = false;
            la.Text = "프로젝트 불러오기";
            la.ShowDialog();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Confirm("정말로 종료하시겠습니까?"))
            {
                Application.Exit();
            }
        }

        public void ProjectLoad(ProjectInfo _info)
        {
            if (_info != null)
            {
                this.info = _info;
                데이터베이스ToolStripMenuItem.Enabled = true;
                웹코드ToolStripMenuItem.Enabled = true;
                모듈설치ToolStripMenuItem.Enabled = true;
                게시판관리ToolStripMenuItem.Enabled = true;
                toolStripMenuItem1.Enabled = true;

                if (this.info != null && !string.IsNullOrWhiteSpace(this.info.Path))
                {
                    try
                    {
                        string filePath = System.IO.Path.Combine(info.Path, "web.config");
                        FileInfo fi = new FileInfo(filePath);
                        if (fi.Exists)
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(fi.FullName);
                            XmlNodeList elements = doc.ChildNodes;
                            XmlNodeList connectionStrings = elements.Item(1).SelectNodes("connectionStrings").Item(0).SelectNodes("add");

                            foreach (XmlNode node in connectionStrings)
                            {
                                Connections.AddOrUpdate(node.Attributes["name"].Value, node.Attributes["connectionString"].Value, (oldkey, oldValue) => node.Attributes["connectionString"].Value);
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(this.ConnectionString))
                        {
                            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(this.ConnectionString);
                            builder.ConnectTimeout = 3;
                            this.SqlConn = new SqlConnection(builder.ToString());
                            this.SqlConn.Open();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Current.Error(ex);
                        this.SqlConn = null;
                    }
                }
            }
        }

        public void ProjectUnLoad()
        {
            this.info = null;
            데이터베이스ToolStripMenuItem.Enabled = false;
            웹코드ToolStripMenuItem.Enabled = false;
            모듈설치ToolStripMenuItem.Enabled = false;
            게시판관리ToolStripMenuItem.Enabled = false;
            toolStripMenuItem1.Enabled = false;


            Connections.Clear();
        }

        public bool Confirm(string msg)
        {
            bool result = false;


            var confirmResult = MessageBox.Show(msg, "", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                result = true;
            }

            return result;
        }

        public void AllClose()
        {
            foreach(var frm in this.MdiChildren)
            {
                frm.Dispose();
            }
        }

        public string ConnectionString
        {
            get
            {
                string connStr = string.Empty;

                if (Connections != null && Connections.Count > 0)
                {
                    if (Connections.ContainsKey("DBConn"))
                    {
                        Connections.TryGetValue("DBConn", out connStr);
                    }
                    else
                    {
                        connStr = Connections.Values.FirstOrDefault();
                    }
                }

                return connStr;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.SqlConn != null)
            {
                if (this.SqlConn.State == ConnectionState.Open)
                {
                    this.SqlConn.Close();
                }
                this.SqlConn.Dispose();
            }
            this.SqlConn = null;
        }

        private void 연결정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllClose();
            var frm = new DbCheckForm(this);
            frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowInTaskbar = false;
            frm.MdiParent = this;
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();
        }

        private void sP만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllClose();
            var frm = new SPForm(this);
            frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowInTaskbar = false;
            frm.MdiParent = this;
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();
        }

        private void 목록코드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllClose();
            var frm = new ListCodeForm(this);
            frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowInTaskbar = false;
            frm.MdiParent = this;
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();
        }

        private void 상세코드ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 처리코드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllClose();
            var frm = new ProdForm(this);
            frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowInTaskbar = false;
            frm.MdiParent = this;
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();
        }

        private void aDMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Confirm("ADM 관리자를 설치하시겠습니까?"))
            {
                using (var wc = new WebClient())
                {
                    
                    DirectoryInfo di = new DirectoryInfo(System.IO.Path.Combine(info.Path, "adm"));
                    if (!di.Exists) di.Create();
                    wc.DownloadFile(url_adm, System.IO.Path.Combine(di.FullName, "release.zip"));
                    FileInfo fi = new FileInfo(System.IO.Path.Combine(di.FullName, "release.zip"));
                    if (fi.Exists)
                    {
                        ZipFile.ExtractToDirectory(fi.FullName, fi.DirectoryName);
                        fi.Delete();
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
