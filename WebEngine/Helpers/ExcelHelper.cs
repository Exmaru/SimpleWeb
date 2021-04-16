using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace WebEngine
{
    public class ExcelHelper : IDisposable
    {
        private string path = string.Empty;

        private bool disposedValue;

        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                if (File.Exists(value))
                {
                    this.path = value;
                }
                else
                {
                    throw new FileNotFoundException("해당 경로에 파일을 찾을 수 없습니다.");
                }
            }
        }

        public string ConnectionString
        {
            get
            {
                string result = string.Empty;

                if (!string.IsNullOrWhiteSpace(this.Path))
                {
                    if (this.Path.IndexOf("xlsx", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        result = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={this.Path};Extended Properties='Excel 8.0;HDR=No'";
                    }
                    else
                    {
                        result = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={this.Path};Extended Properties='Excel 8.0;HDR=No'";
                    }
                }

                return result;
            }
        }

        public OleDbConnection Conn { get; set; }

        public ExcelHelper()
        {
        }

        public void Open()
        {
            if (!string.IsNullOrWhiteSpace(this.ConnectionString))
            {
                this.Conn = new OleDbConnection(this.ConnectionString);
                this.Conn.Open();
            }
            else
            {
                throw new NullReferenceException("ConnectionString is null or empty.");
            }
        }

        public ReturnValues<DataSet> ExecuteData(string Query)
        {
            var result = new ReturnValues<DataSet>();
            DataSet ds = new DataSet();

            try
            {
                using (var cmd = new OleDbCommand(Query, this.Conn))
                using (var adp = new OleDbDataAdapter(cmd))
                {
                    adp.Fill(ds);
                }

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    result.Success(ds.Tables.Count, ds);
                }
                else
                {
                    result.Error("데이터가 없습니다.");
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        public ReturnValue ExecuteNoneQuery(string Query)
        {
            var result = new ReturnValue();

            try
            {
                using (var cmd = new OleDbCommand(Query, this.Conn))
                {
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        result.Success(num);
                    }
                    else
                    {
                        result.Error("처리하지 못했습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }



        public void Close()
        {
            if (this.Conn != null)
            {
                if (this.Conn.State == System.Data.ConnectionState.Open)
                {
                    this.Conn.Close();
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this.Conn != null)
                    {
                        if (this.Conn.State == System.Data.ConnectionState.Open)
                        {
                            this.Conn.Close();
                        }
                        this.Conn.Dispose();
                    }
                    this.Conn = null;
                }

                disposedValue = true;
            }
        }


        ~ExcelHelper()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            this.Close();
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}