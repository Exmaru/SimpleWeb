using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace WEC_Builder.Forms
{
    public partial class LoadForm : Form
    {
        protected JavaScriptSerializer ser { get; set; } = new JavaScriptSerializer();

        protected MainForm main { get; set; }

        public LoadForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void Btn_Path_Search_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "project files (*.wep)|*.wep";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TB_Path.Text = openFileDialog.FileName;
                }
            }
        }

        private async void btn_Load_Click(object sender, EventArgs e)
        {
            string filePath = TB_Path.Text;

            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("프로젝트 파일을 지정해 주세요.");
            }
            else
            {
                string tmp = await FileHelper.ReadFileAsync(filePath, Encoding.UTF8);
                if (!string.IsNullOrWhiteSpace(tmp))
                {
                    ProjectInfo info = ser.Deserialize<ProjectInfo>(tmp);
                    if (info == null)
                    {
                        MessageBox.Show("잘못된 파일입니다[E032].");
                    }
                    else if (string.IsNullOrWhiteSpace(info.Title))
                    {
                        MessageBox.Show("잘못된 파일입니다[E033].");
                    }
                    else if (string.IsNullOrWhiteSpace(info.Path))
                    {
                        MessageBox.Show("잘못된 파일입니다[E034].");
                    }
                    else
                    {
                        main.ProjectLoad(info);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("잘못된 파일입니다[E031].");
                }
            }
        }
    }
}
