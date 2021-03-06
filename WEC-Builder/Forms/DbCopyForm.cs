﻿using OctopusV3.Core;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace WEC_Builder.Forms
{
    public partial class DbCopyForm : Form
    {
        protected MainForm main { get; set; }

        protected JavaScriptSerializer ser { get; set; } = new JavaScriptSerializer();

        protected SqlConnectionStringBuilder AgoDB { get; set; }
        protected SqlConnectionStringBuilder newDB { get; set; }

        private bool IsProc = true;

        public DbCopyForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog di = new FolderBrowserDialog();
            if (di.ShowDialog() == DialogResult.OK)
            {
                TB_Location.Text = di.SelectedPath;
            }
        }

        private void Btn_Search_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog di = new FolderBrowserDialog();
            if (di.ShowDialog() == DialogResult.OK)
            {
                TB_Path.Text = di.SelectedPath;
            }
        }

        private void Btn_Get_Target_Db_Click(object sender, EventArgs e)
        {
            string targetPath = TB_Location.Text;
            if (!string.IsNullOrWhiteSpace(targetPath))
            {
                DirectoryInfo di = new DirectoryInfo(targetPath);
                if (di.Exists)
                {
                    FileInfo fi = new FileInfo(System.IO.Path.Combine(targetPath, "web.config"));
                    if (fi.Exists)
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(fi.FullName);
                            XmlNodeList elements = doc.ChildNodes;
                            XmlNodeList connectionStrings = elements.Item(1).SelectNodes("connectionStrings").Item(0).SelectNodes("add");

                            if (connectionStrings != null && connectionStrings.Count > 0)
                            {
                                string connStr = connectionStrings[0].Attributes["connectionString"].Value;
                                if (!string.IsNullOrWhiteSpace(connStr))
                                {
                                    IsProc = false;
                                    AgoDB = new SqlConnectionStringBuilder(connStr);
                                    TB_Container.Text = AgoDB.InitialCatalog;
                                    TB_IP.Text = AgoDB.DataSource;
                                    TB_ID.Text = AgoDB.UserID;
                                    TB_Password.Text = AgoDB.Password;
                                    TB_App.Text = AgoDB.ApplicationName;
                                    TB_Conn.Text = AgoDB.ToString();
                                    IsProc = true;
                                }
                                else
                                {
                                    this.main.Alert("대상 프로젝트에 접속 정보가 비어 있습니다.");
                                }
                            }
                            else
                            {
                                this.main.Alert("대상 프로젝트에 접속 정보가 비어 있습니다.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Current.Error(ex);
                            this.main.Alert(ex.Message);
                        }
                    }
                    else
                    {
                        this.main.Alert("대상 프로젝트 루트에 web.config 파일을 찾을 수 없습니다.");
                    }
                }
                else
                {
                    this.main.Alert("대상 위치가 올바르지 않습니다.");
                }
            }
            else
            {
                this.main.Alert("대상을 먼저 지정해 주세요.");
            }
        }


        private void TB_SQL_TextChanged(object sender, EventArgs e)
        {
            if (IsProc)
            {
                if (newDB == null)
                {
                    newDB = new SqlConnectionStringBuilder();
                }

                newDB.InitialCatalog = TB_Container.Text;
                newDB.DataSource = TB_IP.Text;
                newDB.UserID = TB_ID.Text;
                newDB.Password = TB_Password.Text;
                newDB.ApplicationName = TB_App.Text;
                TB_Conn.Text = newDB.ToString();
            }
        }

        private void btn_db_copy_Click(object sender, EventArgs e)
        {
            try
            {
                string originalPath = TB_Location.Text;
                string targetPath = TB_Path.Text;

                FileInfo fi = new FileInfo(System.IO.Path.Combine(targetPath, "web.config"));
                if (fi.Exists)
                {
                    newDB.InitialCatalog = TB_Container.Text;
                    newDB.DataSource = TB_IP.Text;
                    newDB.UserID = TB_ID.Text;
                    newDB.Password = TB_Password.Text;
                    newDB.ApplicationName = TB_App.Text;

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fi.FullName);
                        XmlNodeList elements = doc.ChildNodes;
                        XmlNodeList connectionStrings = elements.Item(1).SelectNodes("connectionStrings").Item(0).SelectNodes("add");

                        if (connectionStrings != null && connectionStrings.Count > 0)
                        {
                            connectionStrings[0].Attributes["connectionString"].Value = newDB.ToString();
                            doc.Save(fi.FullName);
                        }
                        else
                        {
                            this.main.Alert("대상 프로젝트에 접속 정보가 비어 있습니다.");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Current.Error(ex);
                        this.main.Alert(ex.Message);
                        return;
                    }
                }

                using (SqlConnection agoConn = new SqlConnection(AgoDB.ConnectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    agoConn.Open();
                    cmd.Connection = agoConn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select [filename] from sys.sysdatabases where [name] = '{AgoDB.InitialCatalog}'";
                    string tmp = Convert.ToString(cmd.ExecuteScalar());
                    if (!string.IsNullOrWhiteSpace(tmp))
                    {
                        string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                        fi = new FileInfo(tmp);
                        string path = fi.Directory.FullName;
                        cmd.CommandText =
$@"
backup database {AgoDB.InitialCatalog} 
to disk='{path}\{AgoDB.InitialCatalog}_{timeStamp}.bak';
";
                        cmd.ExecuteNonQuery();
                        Logger.Current.Debug(cmd.CommandText);

                        cmd.CommandText =
$@"
restore database {newDB.InitialCatalog}
from disk='{path}\{AgoDB.InitialCatalog}_{timeStamp}.bak'
WITH move '{AgoDB.InitialCatalog}' to  '{path}\{newDB.InitialCatalog}.mdf',
move '{AgoDB.InitialCatalog}_log' to  '{path}\{newDB.InitialCatalog}_log.ldf';
";
                        cmd.ExecuteNonQuery();
                        Logger.Current.Debug(cmd.CommandText);
                    }
                    else
                    {
                        this.main.Alert("대상이 없습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                this.main.Alert(ex.Message);
            }
        }
    }
}
