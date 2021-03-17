using OctopusV3.Core;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace WebEngine
{
    public class FCM_Client : IDisposable
    {
        private bool disposedValue;

        public string ServerKey { get; set; } = string.Empty;

        protected JavaScriptSerializer ser { get; set; } = new JavaScriptSerializer();

        public async Task<ReturnValue> sendMessageAsync(string title, string msg, string instanceIdToken)
        {
            var result = new ReturnValue();


            try
            {
                //1. 전송정보 생성
                string serverKey = $"key={ServerKey}";
                string url = "https://fcm.googleapis.com/fcm/send";
                NotificationParameter noti = new NotificationParameter();
                noti.data.title = title;
                noti.data.body = msg;
                noti.to = instanceIdToken;

                string postJson = ser.Serialize(noti); //.Replace("\t", "").Replace("\r\n", "")

                //2. Firebase 서버에 REST 전송
                using (HttpClient client = new HttpClient() { BaseAddress = new Uri(url) })
                {
                    //1) 요청
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", serverKey);
                    StringContent postEncoded = new StringContent(postJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage httpResponse = await client.PostAsync("", postEncoded).ConfigureAwait(false);

                    //2) 응답분석
                    string responseText = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (httpResponse.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(responseText))
                    {
                        Logger.Current.Debug(responseText);
                        NotificationResponseParameter rtn = ser.Deserialize<NotificationResponseParameter>(responseText);
                        if (rtn != null && rtn.success > 0)
                        {
                            result.Success(rtn.success);
                        }
                        else
                        {
                            result.Error("메시지 발송 실패 : " + rtn.ErrorMessage);
                        }
                    }
                    else
                    {
                        result.Error("메시지 발송 실패 : Results is Empty!");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        public ReturnValue sendMessage(string title, string msg, string instanceIdToken)
        {
            return sendMessageAsync(title, msg, instanceIdToken).Result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }

        ~FCM_Client()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}