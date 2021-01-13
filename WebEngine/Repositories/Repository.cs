using OctopusV3.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WebEngine
{
    public class Repository : BaseRepository
    {
        public string Query { get; set; } = string.Empty;

		protected SqlCommand Cmd { get; set; }

        public Repository() : base()
        {
            this.Open(Global.ConnectionString);
        }

        public Repository(string query, CommandType type = CommandType.Text) : base()
        {
            this.Open(Global.ConnectionString);
            this.Query = query;
			this.Cmd = new SqlCommand(this.Query, this.SqlConn);
			this.Cmd.CommandType = type;
        }

		public SqlCommand Command
        {
			get
            {
				return this.Cmd;
            }
        }

		public virtual void AddInput(string Name, string type, object obj, int size = -1)
        {
			if (type.Equals("int", StringComparison.OrdinalIgnoreCase))
            {
				this.Cmd.AddParameterInput(Name, SqlDbType.Int, obj, 4);
			}
			else if (type.Equals("long", StringComparison.OrdinalIgnoreCase) || type.Equals("BigInt", StringComparison.OrdinalIgnoreCase) || type.Equals("number", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterInput(Name, SqlDbType.BigInt, obj, 8);
			}
			else if (type.Equals("float", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterInput(Name, SqlDbType.Float, obj, 8);
			}
			else if (type.Equals("datetime", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterInput(Name, SqlDbType.DateTime2, obj, 8);
			}
			else if (type.Equals("char", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterInput(Name, SqlDbType.Char, obj, size);
			}
			else if (type.Equals("nchar", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterInput(Name, SqlDbType.NChar, obj, size);
			}
			else if (type.Equals("varchar", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterInput(Name, SqlDbType.VarChar, obj, size);
			}
			else if (type.Equals("nvarchar", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterInput(Name, SqlDbType.NVarChar, obj, size);
			}
			else
            {
				this.Cmd.AddParameterInput(Name, SqlDbType.Variant, obj, size);
			}
		}

		public virtual void AddOutput(string Name, string type, int size = -1)
		{
			if (type.Equals("int", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterOutput(Name, SqlDbType.Int, 4);
			}
			else if (type.Equals("long", StringComparison.OrdinalIgnoreCase) || type.Equals("BigInt", StringComparison.OrdinalIgnoreCase) || type.Equals("number", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterOutput(Name, SqlDbType.BigInt, 8);
			}
			else if (type.Equals("float", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterInput(Name, SqlDbType.Float, 8);
			}
			else if (type.Equals("datetime", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterOutput(Name, SqlDbType.DateTime2, 7);
			}
			else if (type.Equals("char", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterOutput(Name, SqlDbType.Char, size);
			}
			else if (type.Equals("nchar", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterOutput(Name, SqlDbType.NChar, size);
			}
			else if (type.Equals("varchar", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterOutput(Name, SqlDbType.VarChar, size);
			}
			else if (type.Equals("nvarchar", StringComparison.OrdinalIgnoreCase))
			{
				this.Cmd.AddParameterOutput(Name, SqlDbType.NVarChar, size);
			}
			else
			{
				this.Cmd.AddParameterOutput(Name, SqlDbType.Variant, size);
			}
		}

		public virtual object GetOutput(string Name)
        {
			return this.Cmd.GetValue(Name);
        }

		public virtual DataTable ExecuteTable()
		{
			DataTable result = null;

			result = this.Cmd.ExecuteTable();
			

			return result;
		}

		public virtual object ExecuteScalar()
        {
			return this.Cmd.ExecuteScalar();
		}


		public virtual int ExecuteCount()
		{
			int result = 0;

			result = Convert.ToInt32(this.Cmd.ExecuteScalar());

			return result;
		}

		public DbResult ExecuteDbResult()
		{
			DbResult result = new DbResult();
			result.Data = this.ExecuteTable();
			return result;
		}

		public DbResult ExecuteDbResult(string query)
		{
			DbResult result = new DbResult();
			result.Data = this.ExecuteTable(query);
			return result;
		}

		public override void Dispose()
        {
			if (this.Cmd != null)
            {
				this.Cmd.Dispose();
				this.Cmd = null;
            }
            base.Dispose();
        }
    }
}