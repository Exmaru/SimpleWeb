using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace WEC_Module
{
    class Program
    {
        private static string repo_site = null;

        static string DownloadURL
        {
            get
            {
                return $"{repo_site}/Module/Download";
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
                                DirectoryInfo di = new DirectoryInfo(System.IO.Path.Combine(targetPath,"temp"));
                                if (!di.Exists)
                                {
                                    di.Create();
                                }

                                using (var wc = new WebClient())
                                {
                                    downloadURL = $"{DownloadURL}/module={targetModule}&v={targetVersion}";

                                    wc.DownloadFile(DownloadURL, System.IO.Path.Combine(di.FullName, $"{targetModule}.zip"));
                                    Console.WriteLine("Download Complete.                                                           ");
                                    FileInfo fi = new FileInfo(System.IO.Path.Combine(di.FullName, $"{targetModule}.zip"));
                                    if (fi.Exists)
                                    {
                                        Console.WriteLine("UnZip...                                                   ");
                                        ZipFile.ExtractToDirectory(fi.FullName, di.FullName);
                                        Console.WriteLine("Unzip Complete.                                                       ");
                                        fi.Delete();
                                    }
                                }
                                Console.WriteLine("");

                                ProcessXcopy(di.FullName, System.IO.Path.Combine(targetPath, targetModule));

                                foreach(FileInfo fi in di.GetFiles())
                                {
                                    fi.Delete();
                                }
                                di.Delete();

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
                                        di = new DirectoryInfo(System.IO.Path.Combine(targetPath, "temp"));
                                        if (!di.Exists)
                                        {
                                            di.Create();
                                        }

                                        using (var wc = new WebClient())
                                        {
                                            downloadURL = $"{DownloadURL}/module={targetModule}&v={targetVersion}";

                                            wc.DownloadFile(DownloadURL, System.IO.Path.Combine(di.FullName, $"{targetModule}.zip"));
                                            Console.WriteLine("Download Complete.                                                           ");
                                            FileInfo fi = new FileInfo(System.IO.Path.Combine(di.FullName, $"{targetModule}.zip"));
                                            if (fi.Exists)
                                            {
                                                Console.WriteLine("UnZip...                                                   ");
                                                ZipFile.ExtractToDirectory(fi.FullName, targetPath);
                                                Console.WriteLine("Unzip Complete.                                                       ");
                                                fi.Delete();
                                            }
                                        }

                                        Console.WriteLine("");

                                        ProcessXcopy(di.FullName, System.IO.Path.Combine(targetPath, targetModule));

                                        foreach (FileInfo fi in di.GetFiles())
                                        {
                                            fi.Delete();
                                        }
                                        di.Delete();

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
    }

}
