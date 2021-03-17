namespace WebEngine
{
    public class NotificationParameter
    {
        public bool content_available { get; set; } = false;

        public NotificationParameterItemData data { get; set; } = new NotificationParameterItemData();

        public string to { get; set; } = string.Empty;

        public string priority { get; set; } = "high";

        public NotificationParameter()
        {

        }
    }

    public class NotificationParameterItemData
    {
        public string title { get; set; } = string.Empty;

        public string body { get; set; } = string.Empty;

        public string icon { get; set; } = string.Empty;

        public NotificationParameterItemData()
        {
        }
    }
}