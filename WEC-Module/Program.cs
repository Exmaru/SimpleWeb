using System;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Xml;

namespace WEC_Module
{
    class Program
    {
        private static string repo_site = null;

        static string DownloadURL
        {
            get
            {
                return $"{repo_site}/Content/Download";
            }
        }

        static ConcurrentDictionary<string, string> List = new ConcurrentDictionary<string, string>();

        static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

        static void Main(string[] args)
        {
            try
            {
                string settingsFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");

                if (!File.Exists(settingsFilePath))
                {
                    System.Xml.Linq.XDocument _fileSettings = new System.Xml.Linq.XDocument(
                        new System.Xml.Linq.XElement("config.xml",
                        new System.Xml.Linq.XElement("Setting", new System.Xml.Linq.XElement("Repository", "http://simpleweb.exmaru.com")))
                    );

                    _fileSettings.Save(settingsFilePath);
                }

                System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
                Doc.Load(settingsFilePath);
                System.Xml.XmlNode element = Doc.DocumentElement.SelectSingleNode("Setting");
                if (element["Repository"] != null)
                {
                    System.Xml.XmlNode node = node = element["Repository"];
                    repo_site = node.InnerText;
                }

                if (args != null && args.Length > 0)
                {
                    string command = args[0].Trim();
                    bool IsProc = true;

                    switch (command.ToUpper())
                    {
                        case "/?":
                        case "/HELP":
                            Help();
                            break;
                        default:
                            int i = 0;
                            do
                            {
                                if (args[i] != null && args[i].Trim().Substring(0, 1) == "-")
                                {
                                    if (args.Length > i + 1 && args[i + 1] != null)
                                    {
                                        if (args[i + 1].Trim().Substring(0, 1) != "-")
                                        {
                                            List.AddOrUpdate(args[i].ToUpper(), args[i + 1], (oldKey, oldValue) => args[i + 1]);
                                            i = i + 2;
                                        }
                                        else
                                        {
                                            List.AddOrUpdate(args[i].ToUpper(), "", (oldKey, oldValue) => "");
                                            i++;
                                        }
                                    }
                                    else
                                    {
                                        List.AddOrUpdate(args[i].ToUpper(), "", (oldKey, oldValue) => "");
                                        i++;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            } while (i < args.Length);
                            break;
                    }

                    if (List.Count > 0)
                    {
                        string targetPath = string.Empty;
                        string targetVersion = string.Empty;
                        string targetModule = string.Empty;
                        string downloadURL = string.Empty;

                        if (List.ContainsKey("-I") || List.ContainsKey("-INSTALL"))
                        {
                            if (List.TryGetValue("-I", out targetModule))
                            {
                                IsProc = true;
                            }
                            else if (List.TryGetValue("-INSTALL", out targetModule))
                            {
                                IsProc = true;
                            }
                            else
                            {
                                IsProc = false;
                                Console.WriteLine("The option is missing.");
                            }

                            if (IsProc && (List.ContainsKey("-V") || List.ContainsKey("-VERSION")))
                            {
                                if (List.TryGetValue("-V", out targetVersion))
                                {
                                }
                                else if (List.TryGetValue("-VERSION", out targetVersion))
                                {
                                }
                                else
                                {
                                    targetVersion = "latest";
                                }
                            }
                            else
                            {
                                targetVersion = "latest";
                            }

                            if (IsProc && (List.ContainsKey("-P") || List.ContainsKey("-POSITION")))
                            {
                                if (List.TryGetValue("-P", out targetPath))
                                {
                                    IsProc = true;
                                }
                                else if (List.TryGetValue("-POSITION", out targetPath))
                                {
                                    IsProc = true;
                                }
                                else
                                {
                                    IsProc = false;
                                    Console.WriteLine("The position is missing.");
                                }
                            }

                            if (IsProc)
                            {
                                Console.WriteLine("Downloading... Hold on a moment, please.");
                                DirectoryInfo di = new DirectoryInfo(System.IO.Path.Combine(targetPath, targetModule));
                                if (di.Exists)
                                {
                                    foreach(FileInfo dfi in di.GetFiles())
                                    {
                                        dfi.Delete();
                                    }
                                }
                                else
                                {
                                    di.Create();
                                }

                                using (var wc = new WebClient())
                                {
                                    downloadURL = $"{DownloadURL}/{targetModule}/{targetVersion}.zip";
                                    Console.WriteLine(downloadURL);
                                    wc.DownloadFile(downloadURL, System.IO.Path.Combine(di.FullName, $"{targetModule}.zip"));
                                    Console.WriteLine("Download Complete.");
                                    FileInfo fi = new FileInfo(System.IO.Path.Combine(di.FullName, $"{targetModule}.zip"));
                                    if (fi.Exists)
                                    {
                                        Console.WriteLine("UnZip...");
                                        ZipFile.ExtractToDirectory(fi.FullName, di.FullName);
                                        Console.WriteLine("Unzip Complete.");
                                        fi.Delete();
                                    }
                                    fi = new FileInfo(System.IO.Path.Combine(di.FullName, $"init.sql"));
                                    if (fi.Exists)
                                    {
                                        string conn = ConnectionString(targetPath);
                                        if (!string.IsNullOrWhiteSpace(conn))
                                        {
                                            try
                                            {
                                                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(conn);
                                                builder.ConnectTimeout = 3;
                                                Console.WriteLine($"Try Connection Database : {builder.DataSource} {builder.InitialCatalog}");
                                                using (SqlConnection SqlConn = new SqlConnection(builder.ConnectionString))
                                                using (SqlCommand cmd = new SqlCommand())
                                                {
                                                    SqlConn.Open();
                                                    cmd.Connection = SqlConn;
                                                    cmd.CommandType = System.Data.CommandType.Text;

                                                    int rtn = 0;
                                                    string sqls = "select count(1) from sys.all_objects where [type_desc] = 'USER_TABLE' and [name] = 'Categories'";
                                                    cmd.CommandText = sqls;
                                                    rtn = Convert.ToInt32(cmd.ExecuteScalar());

                                                    if (rtn > 0)
                                                    {
                                                        sqls = $"select count(1) from sys.all_objects where [type_desc] = 'USER_TABLE' and [name] Like '{targetModule}%'";
                                                        cmd.CommandText = sqls;
                                                        rtn = Convert.ToInt32(cmd.ExecuteScalar());

                                                        if (rtn > 0)
                                                        {
                                                            Console.WriteLine("Already Database Initialize.");
                                                        }
                                                        else
                                                        {
                                                            sqls = File.ReadAllText(fi.FullName);
                                                            if (!string.IsNullOrWhiteSpace(sqls))
                                                            {

                                                                foreach (string sql in sqls.Split('/'))
                                                                {
                                                                    if (!string.IsNullOrWhiteSpace(sql))
                                                                    {
                                                                        cmd.CommandText = sql;
                                                                        cmd.ExecuteNonQuery();
                                                                    }
                                                                }
                                                            }

                                                            Console.WriteLine("Database Initialize Complete.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("The default database must be set first.");
                                                    }

                                                    SqlConn.Close();
                                                }
                                            }
                                            catch (SqlException sqlex)
                                            {
                                                Console.WriteLine(sqlex.Message);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                        fi.Delete();
                                    }
                                }
                                Console.WriteLine("");
                                Console.WriteLine($"Install Complete : {targetModule} {targetVersion}");
                            }
                        }
                        else if (List.ContainsKey("-U") || List.ContainsKey("-UPDATE"))
                        {
                            if (List.TryGetValue("-U", out targetModule))
                            {
                                IsProc = true;
                            }
                            else if (List.TryGetValue("-UPDATE", out targetModule))
                            {
                                IsProc = true;
                            }
                            else
                            {
                                IsProc = false;
                                Console.WriteLine("The option is missing.");
                            }

                            if (!string.IsNullOrWhiteSpace(targetModule))
                            {
                                if (IsProc && (List.ContainsKey("-V") || List.ContainsKey("-VERSION")))
                                {
                                    if (List.TryGetValue("-V", out targetVersion))
                                    {
                                    }
                                    else if (List.TryGetValue("-VERSION", out targetVersion))
                                    {
                                    }
                                    else
                                    {
                                        targetVersion = string.Empty;
                                    }
                                }

                                if (IsProc && (List.ContainsKey("-P") || List.ContainsKey("-POSITION")))
                                {
                                    if (List.TryGetValue("-P", out targetPath))
                                    {
                                        IsProc = true;
                                    }
                                    else if (List.TryGetValue("-POSITION", out targetPath))
                                    {
                                        IsProc = true;
                                    }
                                    else
                                    {
                                        IsProc = false;
                                        Console.WriteLine("The position is missing.");
                                    }
                                }

                                if (IsProc)
                                {
                                    Console.Write("Downloading... Hold on a moment, please.");
                                    DirectoryInfo di = new DirectoryInfo(targetPath);
                                    if (di.Exists)
                                    {
                                        di = new DirectoryInfo(System.IO.Path.Combine(targetPath, targetModule));
                                        if (di.Exists)
                                        {
                                            foreach (FileInfo dfi in di.GetFiles())
                                            {
                                                dfi.Delete();
                                            }
                                        }
                                        else
                                        {
                                            di.Create();
                                        }

                                        using (var wc = new WebClient())
                                        {
                                            downloadURL = $"{DownloadURL}/{targetModule}/{targetVersion}.zip";

                                            wc.DownloadFile(downloadURL, System.IO.Path.Combine(di.FullName, $"{targetModule}.zip"));
                                            Console.WriteLine("Download Complete.");
                                            FileInfo fi = new FileInfo(System.IO.Path.Combine(di.FullName, $"{targetModule}.zip"));
                                            if (fi.Exists)
                                            {
                                                Console.WriteLine("UnZip...");
                                                ZipFile.ExtractToDirectory(fi.FullName, di.FullName);
                                                Console.WriteLine("Unzip Complete.");
                                                fi.Delete();
                                            }
                                        }

                                        Console.WriteLine("");
                                        Console.WriteLine($"Update Complete : {targetModule} {targetVersion}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The option is missing.");
                                    }
                                }
                            }
                        }
                        else if (List.ContainsKey("-E") || List.ContainsKey("-ERASE"))
                        {
                            if (List.TryGetValue("-E", out targetModule))
                            {
                                IsProc = true;
                            }
                            else if (List.TryGetValue("-ERASE", out targetModule))
                            {
                                IsProc = true;
                            }
                            else
                            {
                                IsProc = false;
                                Console.WriteLine("The option is missing.");
                            }

                            if (!string.IsNullOrWhiteSpace(targetModule))
                            {
                                if (IsProc && (List.ContainsKey("-P") || List.ContainsKey("-POSITION")))
                                {
                                    if (List.TryGetValue("-P", out targetPath))
                                    {
                                        IsProc = true;
                                    }
                                    else if (List.TryGetValue("-POSITION", out targetPath))
                                    {
                                        IsProc = true;
                                    }
                                    else
                                    {
                                        IsProc = false;
                                        Console.WriteLine("The position is missing.");
                                    }
                                }

                                if (IsProc)
                                {
                                    DirectoryInfo di = new DirectoryInfo(targetPath);
                                    if (di.Exists)
                                    {
                                        di = new DirectoryInfo(System.IO.Path.Combine(targetPath, targetModule));
                                        if (di.Exists)
                                        {
                                            foreach(FileInfo fi in di.GetFiles())
                                            {
                                                fi.Delete();
                                            }
                                            di.Delete();
                                        }

                                        Console.WriteLine($"Erase Complete : {targetModule} {targetVersion}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The option is missing.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Unknown command : {command}");
                            Console.WriteLine("Please refer to Help. (/help or /?)");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Welcome SimpleWeb WebEngine-Module Command (v1.0)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Help()
        {
            Console.WriteLine("WebEngine-Module Installer Helper Command Guide");
            Console.WriteLine("");
            Console.WriteLine("/?, /Help : You can see instructions on how to use it.");
            Console.WriteLine("");
            Console.WriteLine("-i {module}, -install {module}: Install the latest version of Module.");
            Console.WriteLine("-u {module}, -update {module}: update the latest version of Module.");
            Console.WriteLine("-e {module}, -erase {module}: erase the Module.");
            Console.WriteLine("-v {version}, -version {version} + install or update : Installing with a specific version.");
            Console.WriteLine("-p {project root}, -position {project root} : Initialize Target Project.");
            Console.WriteLine("");
            Console.WriteLine("Welcome WebEngine-Module Installer Helper Command.");
        }


        static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }

        private static void ProcessXcopy(string SolutionDirectory, string TargetDirectory)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            //Give the name as Xcopy
            startInfo.FileName = "xcopy";
            //make the window Hidden
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //Send the Source and destination as Arguments to the process
            startInfo.Arguments = "\"" + SolutionDirectory + "\"" + " " + "\"" + TargetDirectory + "\"" + @" /E /C /H /Y /Q /d";

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        private static string ConnectionString(string path)
        {
            string result = string.Empty;

            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                throw new Exception($"Not found path : {path}");
            }
            FileInfo fi = new FileInfo(System.IO.Path.Combine(di.FullName, "web.config"));
            if (fi.Exists)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fi.FullName);
                XmlNodeList elements = doc.ChildNodes;
                XmlNodeList connectionStrings = elements.Item(1).SelectNodes("connectionStrings").Item(0).SelectNodes("add");

                string firstKey = string.Empty;
                int num = 0;

                foreach (XmlNode node in connectionStrings)
                {
                    if (num == 0) firstKey = node.Attributes["name"].Value;
                    Connections.AddOrUpdate(node.Attributes["name"].Value, node.Attributes["connectionString"].Value, (oldkey, oldValue) => node.Attributes["connectionString"].Value);
                    num++;
                }

                

                if (Connections != null && Connections.Count > 0)
                {
                    if (Connections.ContainsKey("DBConn"))
                    {
                        if (Connections.TryGetValue("DBConn", out result))
                        {
                        }
                    }
                    else
                    {
                        if (Connections.TryGetValue(firstKey, out result))
                        {
                        }
                    }
                }
            }

            return result;
        }

    }

}
