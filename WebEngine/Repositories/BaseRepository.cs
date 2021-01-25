using OctopusV3.Core;
using OctopusV3.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebEngine
{
	public abstract class BaseRepository : IDisposable
	{
		private bool disposedValue = false;
		public SqlConnection SqlConn { get; set; }

		public ILogHelper Logger { get; set; }

		public BaseRepository()
		{
		}

		public SqlConnection Connection { get { return this.SqlConn; } set { this.SqlConn = value; } }

		public virtual void Set(SqlConnection sqlconn)
        {
			this.SqlConn = sqlconn;
        }

		public void Open(string connStr)
		{
			this.SqlConn = new SqlConnection(connStr);
			this.SqlConn.Open();
		}

		public void Close()
		{
			if (this.SqlConn != null && this.SqlConn.State == System.Data.ConnectionState.Open)
			{
				this.SqlConn.Close();
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (this.SqlConn != null)
					{
						if (this.SqlConn.State == System.Data.ConnectionState.Open)
                        {
							this.SqlConn.Close();
						}
						this.SqlConn.Dispose();
					}
				}
			}
		}

		~BaseRepository()
		{
			Dispose(false);
		}

		public virtual void Dispose()
		{
			Dispose(true);
		}

		public virtual DataTable ExecuteTable(string query)
		{
			DataTable result = null;

			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = CommandType.Text;
				result = cmd.ExecuteTable();
			}

			return result;
		}

		public virtual int ExecuteCount(string query)
		{
			int result = 0;

			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = CommandType.Text;
				result = Convert.ToInt32(cmd.ExecuteScalar());
			}

			return result;
		}

	}
}