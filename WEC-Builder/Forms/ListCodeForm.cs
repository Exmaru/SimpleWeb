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
using OctopusV3.Core;
using OctopusV3.Data;

namespace WEC_Builder.Forms
{
    public partial class ListCodeForm : Form
    {
        protected MainForm main { get; set; }

        public ListCodeForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LB_Table.Items.Clear();

            using (var cmd = new SqlCommand(QueryHelper.TableViewSelect, main.SqlConn))
            {
                var data = cmd.ExecuteList<ObjectEntity>();
                if (data != null && data.Count > 0)
                {
                    foreach (var table in data)
                    {
                        LB_Table.Items.Add(table.name);
                    }
                }
            }
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

        public string Tags
        {
            get
            {
                StringBuilder builder = new StringBuilder(200);
                string entityName = LB_Table.SelectedItem.ToString();
                bool isAdmin = IsAdmin.Checked;

                if (!String.IsNullOrWhiteSpace(entityName))
                {
                    List<DbTableInfo> tableinfos = new List<DbTableInfo>();

                    try
                    {
                        using (var cmd = new SqlCommand(QueryHelper.TableInfo(entityName), this.main.SqlConn))
                        {
                            cmd.CommandType = CommandType.Text;
                            tableinfos = cmd.ExecuteList<DbTableInfo>();
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgWrite(ex.Message);
                    }

                    if (tableinfos != null && tableinfos.Count > 0)
                    {
                        var identityColumn = tableinfos.Where(x => x.is_identity).FirstOrDefault();

                        if (identityColumn != null)
                        {
                            builder.AppendLine("@using WebEngine;");
                            builder.AppendLine("@{");
                            builder.AppendLine("    Global.Init(this);");
                            if (isAdmin)
                            {
                                builder.AppendLine("    string Root = Html.GetFolderName();");
                                builder.AppendLine("    string Token = GlobalSite.Utility.CookieGet($\"{Global.AppID}_Manager\");");
                                builder.AppendLine("    if (string.IsNullOrWhiteSpace(Token))");
                                builder.AppendLine("    {");
                                builder.AppendLine("        Response.Redirect($\"~/{Root}/Index\");");
                                builder.AppendLine("    }");
                            }
                            builder.AppendLine("");
                            builder.AppendLine("    ");
                            builder.AppendLine("    int PageSize = 10;");
                            builder.AppendLine("");
                            builder.AppendLine("    int CurPage = Request.GetInt(\"CurPage\", 1);");
                            builder.AppendLine("    string Keyword = Request.GetString(\"Keyword\",\"\");");
                            builder.AppendLine("    string Keyfield = Request.GetString(\"Keyfield\",\"\");");
                            builder.AppendLine("");
                            builder.AppendLine("    var where = new WhereString();");
                            builder.AppendLine("    var paging = new PagingParameter(PageSize, CurPage);");
                            builder.AppendLine("    paging.LinkURL = \"List\";");
                            builder.AppendLine("    paging.OtherParamaters = $\"Keyword={Keyword}&Keyfield={Keyfield}\";");
                            builder.AppendLine("");
                            builder.AppendLine("    DbResult List = new DbResult();");
                            builder.AppendLine("");
                            builder.AppendLine("    using(var db  = new DbHelper())");
                            builder.AppendLine("    {");
                            builder.AppendLine("        where.Append($\"IsEnabled=1\");");
                            builder.AppendLine("");
                            builder.AppendLine("        if (!string.IsNullOrWhiteSpace(Keyword) && !string.IsNullOrWhiteSpace(Keyfield))");
                            builder.AppendLine("        {");
                            builder.AppendLine("            where.Append($\"{Keyfield} Like '%{Keyword}%'\");");
                            builder.AppendLine("        }");
                            builder.AppendLine("");
                            builder.AppendLine("        var query1 = db.ExecuteQuery($\"SELECT TOP { PageSize} A.* FROM (SELECT TOP({ PageSize} * @CurPage) ROW_NUMBER() OVER(ORDER BY " + identityColumn.ColumnName + " DESC) AS rownumber, *FROM [" + entityName + "] with (nolock) {where.Result}) AS A WHERE rownumber > (@CurPage - 1) * {PageSize}\");");
                            builder.AppendLine("        query1.AddInput(\"@CurPage\", \"int\", CurPage);");
                            builder.AppendLine("        List = query1.ExecuteDbResult();");
                            builder.AppendLine("");
                            builder.AppendLine("        var query2 = db.ExecuteQuery($\"Select Count(1) from [" + entityName + "] with (nolock) {where.Result}\");");
                            builder.AppendLine("        paging.SetTotalCount(Convert.ToInt32(query2.ExecuteScalar()));");
                            builder.AppendLine("    }");
                            builder.AppendLine("");
                            if (isAdmin)
                            {
                                builder.AppendLine("    Layout = $\"~/{Root}/Layout/_Default.cshtml\";");
                            }
                            else
                            {
                                builder.AppendLine("    Layout = $\"~/Layout/_Default.cshtml\";");
                            }
                            builder.AppendLine("}");
                        }
                        else
                        {
                            //builder.AppendLine("<< Identity Column is not Found >>");
                        }
                    }
                }




                return builder.ToString();
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
            using (var saveFileDialog = new SaveFileDialog())
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
    }
}
