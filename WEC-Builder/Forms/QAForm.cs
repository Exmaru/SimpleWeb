using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;
using System.IO.Compression;

namespace WEC_Builder.Forms
{
    public partial class QAForm : Form
    {
        protected JavaScriptSerializer ser { get; set; } = new JavaScriptSerializer();

        protected MainForm main { get; set; }

        public QAForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void Btn_Path_Search_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog di = new FolderBrowserDialog();
            if (di.ShowDialog() == DialogResult.OK)
            {
                TB_Path.Text = di.SelectedPath;
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            ProjectInfo info = new ProjectInfo();
            info.Title = TB_Title.Text;
            info.Path = TB_Path.Text;

            if (string.IsNullOrWhiteSpace(info.Title))
            {
                MessageBox.Show("프로젝트명을 입력해 주세요.");
                TB_Title.Focus();
            }
            else if (string.IsNullOrWhiteSpace(info.Path))
            {
                MessageBox.Show("프로젝트 경로를 입력해 주세요.");
                TB_Path.Focus();
            }
            else
            {
                FileInfo fi = new FileInfo(info.ProjectFile);
                if (fi.Exists)
                {
                    MessageBox.Show("이미 해당 프로젝트가 있습니다.");
                }
                else
                {
                    if (FileHelper.WriteFile(fi.FullName, ser.Serialize(info), Encoding.UTF8, false))
                    {
                        main.ProjectLoad(info);

                        fi = new FileInfo(System.IO.Path.Combine(fi.DirectoryName, "web.config"));
                        if (!fi.Exists)
                        {
                            if (main.Confirm("해당 폴더에는 WEC가 설정되지 않았습니다.  지금 설정하시겠습니까?"))
                            {
                                using (var wc = new WebClient())
                                {
                                    wc.DownloadFile(main.url_package, System.IO.Path.Combine(fi.DirectoryName, "release.zip"));
                                    fi = new FileInfo(System.IO.Path.Combine(fi.DirectoryName, "release.zip"));
                                    if (fi.Exists)
                                    {
                                        ZipFile.ExtractToDirectory(fi.FullName, fi.DirectoryName);
                                        fi.Delete();
                                    }
                                }
                            }
                        }


                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("프로젝트 파일을 생성하지 못했습니다.");
                    }
                }
            }
        }
    }
}
