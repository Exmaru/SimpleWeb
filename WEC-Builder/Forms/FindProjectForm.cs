using OctopusV3.Core;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace WEC_Builder.Forms
{
    public partial class FindProjectForm : Form
    {
        protected MainForm main { get; set; }

        protected JavaScriptSerializer ser { get; set; } = new JavaScriptSerializer();

        protected SqlConnectionStringBuilder SQL { get; set; }

        private bool IsProc = true;

        public FindProjectForm(MainForm _main)
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
                                    SQL = new SqlConnectionStringBuilder(connStr);
                                    TB_Container.Text = SQL.InitialCatalog;
                                    TB_IP.Text = SQL.DataSource;
                                    TB_ID.Text = SQL.UserID;
                                    TB_Password.Text = SQL.Password;
                                    TB_App.Text = SQL.ApplicationName;
                                    TB_Conn.Text = SQL.ToString();
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

        private void btn_copy_Click(object sender, EventArgs e)
        {
            string originalPath = TB_Location.Text;
            string targetPath = TB_Path.Text;

            if (string.IsNullOrWhiteSpace(originalPath))
            {
                this.main.Alert("대상 프로젝트를 지정해 주세요.");
            }
            else if (string.IsNullOrWhiteSpace(targetPath))
            {
                this.main.Alert("복사할 위치를 지정해 주세요.");
            }
            else
            {
                DirectoryInfo de = new DirectoryInfo(originalPath);
                DirectoryInfo di = new DirectoryInfo(targetPath);
                if (de.Exists)
                {
                    if (!di.Exists)
                    {
                        if (this.main.Confirm("대상 폴더가 존재하지 않습니다.  만드시겠습니까?"))
                        {
                            di.Create();
                        }
                        else
                        {
                            return;
                        }
                    }

                    this.main.ProcessXcopy(de.FullName, di.FullName, new Action(() => {
                        FileInfo fi = new FileInfo(System.IO.Path.Combine(targetPath, "web.config"));
                        if (fi.Exists)
                        {
                            if (SQL == null)
                            {
                                SQL = new SqlConnectionStringBuilder();
                            }

                            SQL.InitialCatalog = TB_Container.Text;
                            SQL.DataSource = TB_IP.Text;
                            SQL.UserID = TB_ID.Text;
                            SQL.Password = TB_Password.Text;
                            SQL.ApplicationName = TB_App.Text;

                            try
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(fi.FullName);
                                XmlNodeList elements = doc.ChildNodes;
                                XmlNodeList connectionStrings = elements.Item(1).SelectNodes("connectionStrings").Item(0).SelectNodes("add");

                                if (connectionStrings != null && connectionStrings.Count > 0)
                                {
                                    connectionStrings[0].Attributes["connectionString"].Value = SQL.ToString();
                                    doc.Save(fi.FullName);
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

                        foreach (FileInfo fe in fi.Directory.GetFiles())
                        {
                            if (fe.Extension.Contains("wep"))
                            {
                                fe.Delete();
                            }
                        }

                        ProjectInfo info = new ProjectInfo();
                        info.Title = TB_App.Text;
                        info.Path = TB_Path.Text;

                        FileHelper.WriteFile(info.ProjectFile, ser.Serialize(info), Encoding.UTF8, false);

                        this.main.Alert("복사가 완료되었습니다.");
                    }));


                    this.main.Alert("복사가 진행중입니다. 콘솔창을 닫지 마세요.");
                }
                else
                {
                    this.main.Alert("대상 프로젝트가 존재하지 않습니다.");
                }
            }
        }

        private void TB_SQL_TextChanged(object sender, EventArgs e)
        {
            if (IsProc)
            {
                SQL.InitialCatalog = TB_Container.Text;
                SQL.DataSource = TB_IP.Text;
                SQL.UserID = TB_ID.Text;
                SQL.Password = TB_Password.Text;
                SQL.ApplicationName = TB_App.Text;
                TB_Conn.Text = SQL.ToString();
            }
        }
    }
}
