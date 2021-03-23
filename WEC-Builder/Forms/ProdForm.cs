using OctopusV3.Core;
using OctopusV3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEC_Builder.Forms
{
    public partial class ProdForm : Form
    {
        protected MainForm main { get; set; }

        public ProdForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        public void MsgClear()
        {
            if (TB_Content.InvokeRequired)
            {
                TB_Content.BeginInvoke(new Action(() => {
                    TB_Content.Clear();
                }));
            }
            else
            {
                TB_Content.Clear();
            }
        }

        public void MsgWrite(string msg)
        {
            if (TB_Content.InvokeRequired)
            {
                TB_Content.BeginInvoke(new Action(() => {
                    TB_Content.AppendText(msg);
                    TB_Content.AppendText(Environment.NewLine);
                }));
            }
            else
            {
                TB_Content.AppendText(msg);
                TB_Content.AppendText(Environment.NewLine);
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LB_SP.Items.Clear();

            using (var cmd = new SqlCommand(QueryHelper.SPSelect, main.SqlConn))
            {
                var data = cmd.ExecuteList<SPEntity>();

                if (data != null && data.Count > 0)
                {
                    foreach (var table in data)
                    {
                        LB_SP.Items.Add(table.name);
                    }
                }
            }

        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            MsgClear();
            MsgWrite(this.Tags);
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.Tags);
            MessageBox.Show("복사했습니다.");
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            using(var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "저장경로를 지정하세요.";
                saveFileDialog.OverwritePrompt = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (FileHelper.WriteFile(fileName, this.Tags, Encoding.UTF8, true))
                    {
                        MessageBox.Show("저장했습니다.");
                    }
                }
            }
        }



        public string Tags
        {
            get
            {
                StringBuilder builder = new StringBuilder(200);

                if (LB_SP.SelectedItem != null && CB_TYPE.SelectedItem != null)
                {
                    string spName = LB_SP.SelectedItem.ToString();
                    string rtnType = CB_TYPE.SelectedItem.ToString();  //ReturnValue, Select
                    bool isAdmin = IsAdmin.Checked;

                    if (!String.IsNullOrWhiteSpace(spName))
                    {
                        List<ExSpInfo> spinfos = new List<ExSpInfo>();

                        using (var cmd = new SqlCommand(SPInfo.CreateSPInfoQuery(spName), main.SqlConn))
                        {
                            spinfos = cmd.ExecuteList<ExSpInfo>();
                        }

                        builder.AppendLine("@using WebEngine;");
                        builder.AppendLine("@{");
                        builder.AppendLine("    Global.Init(this);");
                        builder.AppendLine("    bool proc = true;");
                        builder.AppendLine("");
                        if (isAdmin)
                        {
                            builder.AppendLine("    string Root = Html.GetFolderName();");
                            builder.AppendLine("    string Token = GlobalSite.Utility.CookieGet($\"{Global.AppID}_Manager\");");

                        }
                        if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.AppendLine("    ReturnValue result = new ReturnValue();");
                            if (isAdmin)
                            {
                                builder.AppendLine("    if (string.IsNullOrWhiteSpace(Token))");
                                builder.AppendLine("    {");
                                builder.AppendLine("        result.Error(\"로그인 후 이용해 주세요.\");");
                                builder.AppendLine("        proc = false;");
                                builder.AppendLine("    }");
                            }
                        }
                        else
                        {
                            builder.AppendLine("    DbResult result = new DbResult();");
                            if (isAdmin)
                            {
                                builder.AppendLine("    if (string.IsNullOrWhiteSpace(Token))");
                                builder.AppendLine("    {");
                                builder.AppendLine("        proc = false;");
                                builder.AppendLine("    }");
                            }
                        }
                        builder.AppendLine("");
                        foreach(var spinfo in spinfos)
                        {
                            if (!spinfo.is_output)
                            {
                                builder.AppendLine($"    {spinfo.ObjectType} {spinfo.ColumnName} = Request.{spinfo.RequestMethod}(\"{spinfo.ColumnName}\");");
                            }
                        }

                        builder.AppendLine("");
                        builder.AppendLine("if (proc)");
                        builder.AppendLine("{");
                        builder.AppendLine("    using(var db  = new DbHelper())");
                        builder.AppendLine("    {");
                        builder.AppendLine($"        var query = db.ExecuteSP(\"{spName}\");");
                        foreach (var info in spinfos)
                        {
                            if (info.is_output)
                            {
                                if ((rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase)
                                        && (info.name.Equals("@Code", StringComparison.OrdinalIgnoreCase) ||
                                                info.name.Equals("@Value", StringComparison.OrdinalIgnoreCase) ||
                                                info.name.Equals("@Msg", StringComparison.OrdinalIgnoreCase))) == false)
                                {
                                    builder.AppendLine($"        query.AddOutput(\"{info.name}\", System.Data.SqlDbType.{info.SqlType.ToString()}, {info.max_length});");
                                }
                            }
                            else
                            {
                                builder.Append($"        query.AddInput(\"{info.name}\", \"{info.SqlType.ToString()}\", {info.ColumnName}, ");
                                switch (info.SqlType)
                                {
                                    case SqlDbType.NVarChar:
                                    case SqlDbType.NChar:
                                        if (info.max_length > 0)
                                        {
                                            builder.AppendLine($" {info.max_length / 2});");
                                        }
                                        else
                                        {
                                            builder.AppendLine($" -1);");
                                        }
                                        break;
                                    default:
                                        builder.AppendLine($" {info.max_length});");
                                        break;
                                }

                            }
                        }

                        builder.AppendLine("");
                        if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.AppendLine("        result = query.ExecuteReturnValue();");
                        }
                        else
                        {
                            builder.AppendLine("        result = query.ExecuteDbResult();");

                            builder.AppendLine("        List<dynamic> list = new List<dynamic>();");
                            builder.AppendLine("        foreach(var item in result.List)");
                            builder.AppendLine("        {");
                            builder.AppendLine("        	list.Add(new {");
                            builder.AppendLine("        		{Your ColumnName} = item.GetString(\"{Your ColumnName}\"),");
                            builder.AppendLine("        	});");
                            builder.AppendLine("        }");
                        }
                        
                        builder.AppendLine("    }");
                        builder.AppendLine("}");
                        builder.AppendLine("");
                        builder.AppendLine("    Layout = null;");
                        builder.AppendLine("}");
                        if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.AppendLine("@Response.Json(result)");
                        }
                        else
                        {
                            builder.AppendLine("@Response.Json(new { data = list })");
                        }
                    }
                }

                return builder.ToString();
            }
        }
    }
}
