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
using OctopusV3.Data;

namespace WEC_Builder.Forms
{
    public partial class SPForm : Form
    {
        protected MainForm main { get; set; }

        public SPForm(MainForm _main)
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

        private void LB_Table_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            MsgClear();
            MsgWrite(this.Query);
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.Query);
            MessageBox.Show("복사했습니다.");
        }

        public string Query
        {
            get
            {
                StringBuilder builder = new StringBuilder(200);

                string entityName = LB_Table.SelectedItem.ToString();
                string rtnType = CB_TYPE.SelectedItem.ToString();  //ReturnValue,Select
                string roleType = string.Empty;
                if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                {
                    roleType = "Save";
                }
                else if (rtnType.Equals("Select", StringComparison.OrdinalIgnoreCase))
                {
                    roleType = "Select";
                }
                else
                {
                    return "";
                }

                bool IsTran = IsTransaction.Checked;

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
                            builder.AppendLine($"CREATE PROCEDURE [dbo].[ESP_{entityName}_{roleType}]");
                            builder.AppendLine("(");
                            int num = 0;
                            foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false).OrderBy(x => x.is_nullable))
                            {
                                switch (info.ColumnType.ToLower())
                                {
                                    case "date":
                                    case "datetime":
                                    case "datetime2":
                                    case "smalldatetime":
                                        break;
                                    default:
                                        if (num > 0) builder.Append(",");
                                        builder.AppendLine($"	@{info.ColumnName}					{this.ColumnTypeString(info)}");
                                        num++;
                                        break;
                                }
                            }
                            if (tableinfos.Where(x => x.is_identity == false).Count() > 0)
                            {
                                builder.Append(",");
                            }
                            builder.AppendLine($"	@{identityColumn.ColumnName}					{identityColumn.ColumnType}     = -1");
                            if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                            {
                                builder.AppendLine(",	@Code					bigint				output");
                                builder.AppendLine(",	@Value					varchar(100)		output");
                                builder.AppendLine(",	@Msg					nvarchar(100)	output");
                            }
                            builder.AppendLine(")");
                            builder.AppendLine("AS");
                            builder.AppendLine("");
                            builder.AppendLine("SET NOCOUNT ON");
                            builder.AppendLine("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                            builder.AppendLine("");
                            builder.AppendLine("Declare @Err int");
                            builder.AppendLine("SET @Err = 0");
                            builder.AppendLine("");
                            if (IsTran)
                            {
                                builder.AppendLine("BEGIN TRAN");
                            }
                            if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                            {
                                builder.AppendLine("SET @Code = 0");
                                builder.AppendLine("SET @Value = ''");
                                builder.AppendLine("SET @Msg = ''");
                                builder.AppendLine("");

                                builder.AppendLine("BEGIN TRY");
                            }
                            //BODY
                            switch (roleType.ToUpper())
                            {
                                case "SELECT":
                                    builder.AppendLine($"select * from [{entityName}]");
                                    break;
                                case "SAVE":
                                    builder.AppendLine($"IF Exists(select [{identityColumn.ColumnName}] from [{entityName}] where [{identityColumn.ColumnName}] = @{identityColumn.ColumnName})");
                                    builder.AppendLine("	BEGIN");
                                    builder.AppendLine($"update [{entityName}] set ");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        switch (info.ColumnType.ToLower())
                                        {
                                            case "date":
                                            case "datetime":
                                            case "datetime2":
                                            case "smalldatetime":
                                                builder.AppendLine($"[{info.ColumnName}] = getdate()");
                                                break;
                                            default:
                                                builder.AppendLine($"[{info.ColumnName}] = @{info.ColumnName}");
                                                break;
                                        }
                                        num++;
                                    }
                                    builder.Append("where ");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity))
                                    {
                                        if (num > 0) builder.Append(" and ");
                                        builder.AppendLine($"[{info.ColumnName}] = @{info.ColumnName}");
                                        num++;
                                    }
                                    builder.AppendLine("");
                                    builder.AppendLine("SET @Err = @Err + @@Error");
                                    if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                    {
                                        builder.AppendLine("");
                                        builder.AppendLine("IF IsNull(@Err,0) = 0");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = @{identityColumn.ColumnName}");
                                        builder.AppendLine("    END");
                                        builder.AppendLine("ELSE");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = -1");
                                        builder.AppendLine($"        SET @Msg = '수정하지 못했습니다.'");
                                        builder.AppendLine("    END");
                                    }
                                    builder.AppendLine("	END");
                                    builder.AppendLine("ELSE");
                                    builder.AppendLine("	BEGIN");
                                    builder.AppendLine($"insert into [{entityName}] (");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        builder.AppendLine($"[{info.ColumnName}]");
                                        num++;
                                    }
                                    builder.AppendLine(") values (");

                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        switch (info.ColumnType.ToLower())
                                        {
                                            case "date":
                                            case "datetime":
                                            case "datetime2":
                                            case "smalldatetime":
                                                builder.AppendLine("getdate()");
                                                break;
                                            default:
                                                builder.AppendLine($"@{info.ColumnName}");
                                                break;
                                        }
                                        num++;
                                    }
                                    builder.AppendLine(")");
                                    builder.AppendLine("");
                                    builder.AppendLine("SET @Err = @Err + @@Error");
                                    if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                    {
                                        builder.AppendLine("");
                                        builder.AppendLine("IF IsNull(@Err,0) = 0");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = @@IDENTITY");
                                        builder.AppendLine("    END");
                                        builder.AppendLine("ELSE");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = -1");
                                        builder.AppendLine($"        SET @Msg = '저장하지 못했습니다.'");
                                        builder.AppendLine("    END");
                                    }
                                    builder.AppendLine("	END");
                                    builder.AppendLine("");
                                    break;
                            }

                            //END BODY
                            if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                            {
                                builder.AppendLine("END TRY");
                                builder.AppendLine("BEGIN CATCH");
                                builder.AppendLine("    SET @Code = -1");
                                builder.AppendLine("    SET @Err = @Err + 1");
                                builder.AppendLine("    SET @Msg = ERROR_MESSAGE()");
                                builder.AppendLine("END CATCH");
                            }

                            if (IsTran)
                            {
                                builder.AppendLine("");
                                builder.AppendLine("IF IsNull(@Err,0) = 0");
                                builder.AppendLine("    BEGIN");
                                builder.AppendLine("        COMMIT TRAN");
                                builder.AppendLine("    END");
                                builder.AppendLine("ELSE");
                                builder.AppendLine("    BEGIN");
                                builder.AppendLine("        ROLLBACK TRAN");
                                if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                {
                                    builder.AppendLine("        SET @Code = -1");
                                    builder.AppendLine("        SET @Msg = '처리하지 못했습니다.'");
                                }
                                builder.AppendLine("    END");
                            }
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Query))
            {
                try
                {
                    using (var cmd = new SqlCommand(this.Query, this.main.SqlConn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("반영되었습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("실패하였습니다." + ex.Message);
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

        private string ColumnTypeString(DbTableInfo info)
        {
            StringBuilder builder = new StringBuilder(50);
            builder.Append(info.ColumnType);
            switch (info.ColumnType.ToLower())
            {
                case "varchar":
                case "char":
                case "nvarchar":
                case "nchar":
                    if (info.max_length == -1)
                    {
                        builder.Append("(max)");
                    }
                    else
                    {
                        builder.Append($"({info.max_length})");
                    }
                    if (info.is_nullable)
                    {
                        builder.Append(" = ''");
                    }
                    break;
            }
            return builder.ToString();
        }
    }
}
