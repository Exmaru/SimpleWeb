using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WEC_Builder.Forms
{
    public partial class DbCheckForm : Form
    {
        protected MainForm main { get; set; }

        protected SqlConnectionStringBuilder SQL { get; set; }

        public DbCheckForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;

            if (main.info != null && !string.IsNullOrWhiteSpace(main.ConnectionString))
            {
                SQL = new SqlConnectionStringBuilder(main.ConnectionString);
                TB_Container.Text = SQL.InitialCatalog;
                TB_Path.Text = SQL.DataSource;
                TB_ID.Text = SQL.UserID;
                TB_Password.Text = SQL.Password;
                TB_App.Text = SQL.ApplicationName;
                TB_Conn.Text = SQL.ToString();

                if (main.SqlConn != null)
                {
                    LB_Status.Text = "현재 접속된 상태입니다.";
                }
                else
                {
                    LB_Status.Text = "현재 접속이 불가능한 상태입니다.";
                }
            }
        }

        private void TB_Container_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox target = sender as TextBox;
            if (target.Name.Equals("TB_Path", StringComparison.OrdinalIgnoreCase))
            {
                SQL.DataSource = target.Text;
            }
            else if (target.Name.Equals("TB_ID", StringComparison.OrdinalIgnoreCase))
            {
                SQL.UserID = target.Text;
            }
            else if (target.Name.Equals("TB_Password", StringComparison.OrdinalIgnoreCase))
            {
                SQL.Password = target.Text;
            }
            else if (target.Name.Equals("TB_App", StringComparison.OrdinalIgnoreCase))
            {
                SQL.ApplicationName = target.Text;
            }
            else if (target.Name.Equals("TB_Container", StringComparison.OrdinalIgnoreCase))
            {
                SQL.InitialCatalog = target.Text;
            }

            TB_Conn.Text = SQL.ToString();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            ConfigHelper.SetConnection("DBConn", SQL.ToString());
        }
    }
}
