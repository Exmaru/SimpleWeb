using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebEngine
{
    public class AppData
    {
        private static readonly Lazy<AppData> lazy = new Lazy<AppData>(() => new AppData());
        public static AppData Current { get { return lazy.Value; } }

        public AppData()
        {
        }

        public void Init()
        {
            if (Global.XmlData.Count() > 0)
            {
                FileInfo fi = null;
                foreach(var xml in Global.XmlData)
                {
                    fi = new FileInfo(xml.Value);
                    if (!fi.Exists)
                    {
                        CreateFileSettingsDefault(fi.Name, fi.FullName);
                    }
                }
            }
        }

        public AppItem Read(string file, string field)
        {
            AppItem result = new AppItem();
            string filePath = string.Empty;

            if (Global.XmlData.ContainsKey(file) && Global.XmlData.TryGetValue(file, out filePath))
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
                    Doc.Load(filePath);
                    System.Xml.XmlElement element = Doc.DocumentElement;
                    if (element[field] == null)
                    {
                        result = new AppItem(element.ChildNodes[0]);
                    }
                    else
                    {
                        System.Xml.XmlNode node = element[field];
                        result = new AppItem(node);
                    }
                    result.Key = file;
                }
            }

            return result;
        }

        public List<AppItem> Read(string file)
        {
            List<AppItem> result = new List<AppItem>();
            string filePath = string.Empty;

            if (Global.XmlData.ContainsKey(file) && Global.XmlData.TryGetValue(file, out filePath))
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
                    Doc.Load(filePath);
                    System.Xml.XmlElement element = Doc.DocumentElement;
                    foreach(System.Xml.XmlNode node in element.ChildNodes)
                    {
                        result.Add(new AppItem(node));
                    }
                }
            }

            return result;
        }

        public bool Update(string file, string key, string value)
        {
            try
            {
                string filePath = string.Empty;

                if (Global.XmlData.ContainsKey(file) && Global.XmlData.TryGetValue(file, out filePath))
                {
                    System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
                    Doc.Load(filePath);
                    System.Xml.XmlElement element = Doc.DocumentElement;
                    if (element[key] != null)
                    {
                        System.Xml.XmlNode node = node = element[key];
                        node.InnerText = value;
                        Doc.Save(filePath);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        private static void CreateFileSettingsDefault(string file, string settingsFilePath)
        {
            try
            {
                if (file.IndexOf(".") > -1)
                {
                    file = file.Substring(0, file.IndexOf(".")).Replace(".", "");
                }


                System.Xml.Linq.XDocument _fileSettings = new System.Xml.Linq.XDocument(
                   new System.Xml.Linq.XElement(file, new System.Xml.Linq.XElement("Key", "Value"))
                );

                _fileSettings.Save(settingsFilePath);
            }
            catch
            {
                //do some error            

            }
        }
    }

    public class AppItem
    {
        public System.Xml.XmlNode Node { get; set; }

        protected string key { get; set; } = string.Empty;

        public string Key
        {
            get
            {
                return (!string.IsNullOrWhiteSpace(this.key)) ? this.key : (this.Node == null) ? string.Empty : this.Node.Name;
            }
            set
            {
                this.key = value;
            }
        }

        public AppItem()
        {

        }

        public AppItem(System.Xml.XmlNode node)
        {
            this.Node = node;
        }

        public bool IsExists
        {
            get
            {
                return (Node == null) ? false : true;
            }
        }

        public string Value
        {
            get
            {
                return (this.Node == null) ? string.Empty : this.Node?.InnerText;
            }
        }
    }
}