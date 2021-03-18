using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WEC_Builder.Forms;

namespace WEC_Builder
{
    public partial class MainForm : Form
    {
        public const string url_root = "http://simpleweb.exmaru.com";

        public readonly string url_package = $"{url_root}/Content/release/latest.zip";

        protected ProjectInfo info { get; set; }

        public MainForm()
        {
            InitializeComponent();
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
            }
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
    }
}
