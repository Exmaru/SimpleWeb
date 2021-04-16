using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WEC_Builder.Models;

namespace WEC_Builder.Forms
{
    public partial class ApiTestForm : Form
    {
        protected MainForm main { get; set; }

        protected JavaScriptSerializer ser { get; set; } = new JavaScriptSerializer();

        protected List<ApiTestParameters> list { get; set; } = new List<ApiTestParameters>();

        private bool IsProc = true;

        public ApiTestForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void Btn_Add_Params_Click(object sender, EventArgs e)
        {
            var apifrm = new ApiTestParameters();
            list.Add(apifrm);
            apifrm.Location = new Point(0, (list.Count * 30) - 30);
            Layer_Parameters.Controls.Add(apifrm);

        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            ClearMsg();

            string SendType = (CB_Type.SelectedItem == null) ? string.Empty : Convert.ToString(CB_Type.SelectedItem);
            string SendURL = TB_URL.Text;
            string MediaType = (CB_MediaType.SelectedItem == null) ? string.Empty : Convert.ToString(CB_MediaType.SelectedItem);
            bool IsJsonSerialize = Chk_Serialize.Checked;

            if (string.IsNullOrWhiteSpace(SendType))
            {
                this.main.Alert("전송 타입을 지정해 주세요.");
            }
            else if (string.IsNullOrWhiteSpace(MediaType))
            {
                this.main.Alert("미디어 타입을 지정해 주세요.");
            }
            else if (string.IsNullOrWhiteSpace(SendURL))
            {
                this.main.Alert("URL을 입력해 주세요.");
                TB_URL.Focus();
            }
            else
            {
                string result = string.Empty;

                StringBuilder paramString = new StringBuilder(255);
                //var nameValues = new NameValueCollection();
                int num = 0;
                if (list != null && list.Count > 0)
                {
                    foreach (ApiTestParameters item in list)
                    {
                        if (IsJsonSerialize)
                        {
                            if (num > 0) paramString.Append("{");
                            paramString.Append("{ \"" + item.ID + "\" : \"" + item.Value + "\"}");
                            num++;
                        }
                        else
                        {
                            if (num > 0) paramString.Append("&");
                            //nameValues.Add(item.ID, item.Value);
                            paramString.Append($"{item.ID}={item.Value}");
                            num++;
                        }
                    }

                    if (IsJsonSerialize)
                    {
                        if (num > 0) paramString.Append("}");
                    }
                }

                switch (SendType.Trim().ToUpper())
                {
                    case "POST":
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SendURL);
                            request.Method = "POST";
                            request.Timeout = 30 * 1000; // 30초
                            switch (MediaType.Trim().ToUpper())
                            {
                                case "JSON":
                                    request.ContentType = "application/json";
                                    break;
                            }
                            

                            byte[] bytes = Encoding.UTF8.GetBytes(paramString.ToString());
                            request.ContentLength = bytes.Length;

                            using (Stream reqStream = request.GetRequestStream())
                            {
                                reqStream.Write(bytes, 0, bytes.Length);
                            }

                            using (WebResponse resp = request.GetResponse())
                            {
                                Stream respStream = resp.GetResponseStream();
                                using (StreamReader sr = new StreamReader(respStream))
                                {
                                    result = sr.ReadToEnd();
                                }
                            }
                        }
                        catch (WebException webex)
                        {
                            WebResponse errResp = webex.Response;
                            using (Stream respStream = errResp.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(respStream);
                                ShowMsg(reader.ReadToEnd());
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowMsg(ex.Message);
                            ShowMsg(ex.StackTrace);
                        }
                        break;
                    case "POST-BASIC":
                        using (var wc = new WebClient())
                        {
                            try
                            {
                                wc.Encoding = Encoding.UTF8;
                                switch (MediaType.Trim().ToUpper())
                                {
                                    case "JSON":
                                        wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                                        break;
                                }
                                
                                //byte[] temp = wc.UploadData($"{SendURL}", "POST", Encoding.UTF8.GetBytes(paramString.ToString()));
                                //result = Encoding.UTF8.GetString(temp);
                                result = wc.UploadString($"{SendURL}", "POST", paramString.ToString());
                            }
                            catch (WebException webex)
                            {
                                WebResponse errResp = webex.Response;
                                using (Stream respStream = errResp.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(respStream);
                                    ShowMsg(reader.ReadToEnd());
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowMsg(ex.Message);
                                ShowMsg(ex.StackTrace);
                            }
                        }
                        break;
                    case "GET":
                        using (var wc = new WebClient())
                        {
                            try
                            {
                                wc.Encoding = Encoding.UTF8;
                                switch (MediaType.Trim().ToUpper())
                                {
                                    case "JSON":
                                        wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                                        break;
                                }
                                result = wc.DownloadString($"{SendURL}?{paramString.ToString()}");
                            }
                            catch (WebException webex)
                            {
                                WebResponse errResp = webex.Response;
                                using (Stream respStream = errResp.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(respStream);
                                    ShowMsg(reader.ReadToEnd());
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowMsg(ex.Message);
                                ShowMsg(ex.StackTrace);
                            }
                        }
                        break;
                }

                if (!string.IsNullOrWhiteSpace(result))
                {
                    ShowMsg(result);
                }
            }
        }

        protected void ClearMsg()
        {
            if (TB_Result.InvokeRequired)
            {
                TB_Result.BeginInvoke(new Action(() =>
                {
                    TB_Result.Clear();
                }));
            }
            else
            {
                TB_Result.Clear();
            }
        }

        protected void ShowMsg(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (TB_Result.InvokeRequired)
                {
                    TB_Result.BeginInvoke(new Action(() =>
                    {
                        TB_Result.AppendText(message);
                        TB_Result.AppendText(Environment.NewLine);
                    }));
                }
                else
                {
                    TB_Result.AppendText(message);
                    TB_Result.AppendText(Environment.NewLine);
                }
            }
        }
    }
}
