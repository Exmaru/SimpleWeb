using System.Collections.Generic;

namespace WebEngine
{
    public class NotificationResponseParameter
    {
        public string multicast_id { get; set; } = string.Empty;

        public int success { get; set; } = 0;

        public int failure { get; set; } = 0;

        public int canonical_ids { get; set; } = 0;

        public List<NotificationResponseResult> results { get; set; } = new List<NotificationResponseResult>();

        public NotificationResponseParameter()
        {
        }

        public string ErrorMessage
        {
            get
            {
                if (results != null && results.Count > 0)
                {
                    return results[0].error;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }

    public class NotificationResponseResult
    {
        public string error { get; set; } = string.Empty;

        public NotificationResponseResult()
        {
        }
    }
}