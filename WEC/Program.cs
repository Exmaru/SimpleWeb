using System;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace WEC
{
    class Program
    {
        const string wecURL = "http://simpleweb.exmaru.com/Content/release/wec.zip";

        const string LatestDownload = "http://simpleweb.exmaru.com/Content/release/latest.zip";

        const string d1_0_0 = "http://simpleweb.exmaru.com/Content/release/latest.zip";

        const string v1_0_0 = "http://simpleweb.exmaru.com/Content/release/v1/v1_0_0/WebEngine.dll";

        const string LatestVersion = v1_0_0;

        static ConcurrentDictionary<string, string> List = new ConcurrentDictionary<string, string>();

        static void Main(string[] args)
        {
            try
            {
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
                        case "/TEST":
                            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                            break;
                        default:
                            int i = 0;
                            do
                            {
                                if (args[i] != null && args[i].Trim().Substring(0, 1) == "-")
                                {
                                    if (args.Length > i+1 && args[i + 1] != null)
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
                        string url = string.Empty;

                        if (List.ContainsKey("-I") || List.ContainsKey("-INSTALL"))
                        {
                            if (List.TryGetValue("-I", out targetPath))
                            {
                                IsProc = true;
                            }
                            else if (List.TryGetValue("-INSTALL", out targetPath))
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
                                    IsProc = true;
                                }
                                else if (List.TryGetValue("-VERSION", out targetVersion))
                                {
                                    IsProc = true;
                                }
                                else
                                {
                                    IsProc = true;
                                    targetVersion = string.Empty;
                                }
                            }

                            if (IsProc)
                            {
                                switch (targetVersion)
                                {
                                    case "1":
                                    case "1.0":
                                    case "1.0.0":
                                        url = d1_0_0;
                                        break;
                                    default:
                                        url = LatestDownload;
                                        break;
                                }

                                Console.Write("Downloading... Hold on a moment, please.");
                                DirectoryInfo di = new DirectoryInfo(targetPath);
                                if (!di.Exists)
                                {
                                    di.Create();
                                }

                                using (var wc = new WebClient())
                                {
                                    wc.DownloadFile(url, System.IO.Path.Combine(di.FullName, "release.zip"));
                                    Console.Write("\rDownload Complete.                                                           ");
                                    FileInfo fi = new FileInfo(System.IO.Path.Combine(di.FullName, "release.zip"));
                                    if (fi.Exists)
                                    {
                                        Console.Write("\rUnZip...                                                   ");
                                        ZipFile.ExtractToDirectory(fi.FullName, di.FullName);
                                        Console.Write("\rUnzip Complete.                                                       ");
                                        fi.Delete();
                                    }
                                }
                                Console.WriteLine("");
                                Console.WriteLine("Welcome to SimpleWeb.Net");
                            }
                        }
                        else if (List.ContainsKey("-U") || List.ContainsKey("-UPDATE"))
                        {
                            if (List.TryGetValue("-U", out targetPath))
                            {
                                IsProc = true;
                            }
                            else if (List.TryGetValue("-UPDATE", out targetPath))
                            {
                                IsProc = true;
                            }
                            else
                            {
                                IsProc = false;
                                Console.WriteLine("The option is missing.");
                            }

                            if (!string.IsNullOrWhiteSpace(targetPath))
                            {
                                if (IsProc && (List.ContainsKey("-V") || List.ContainsKey("-VERSION")))
                                {
                                    if (List.TryGetValue("-V", out targetVersion))
                                    {
                                        IsProc = true;
                                    }
                                    else if (List.TryGetValue("-VERSION", out targetVersion))
                                    {
                                        IsProc = true;
                                    }
                                    else
                                    {
                                        IsProc = true;
                                        targetVersion = string.Empty;
                                    }
                                }

                                if (IsProc)
                                {
                                    switch (targetVersion)
                                    {
                                        case "1":
                                        case "1.0":
                                        case "1.0.0":
                                            url = v1_0_0;
                                            break;
                                        default:
                                            url = LatestVersion;
                                            break;
                                    }

                                    Console.Write("Downloading... Hold on a moment, please.");
                                    DirectoryInfo di = new DirectoryInfo(System.IO.Path.Combine(targetPath, "bin"));
                                    if (di.Exists)
                                    {
                                        using (var wc = new WebClient())
                                        {
                                            wc.DownloadFile(url, System.IO.Path.Combine(di.FullName, "WebEngine.dll"));
                                            Console.Write("\rUpdate Complete.                                                           ");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The option is missing.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("WEC Update.");
                                targetPath = AppDomain.CurrentDomain.BaseDirectory;
                                DirectoryInfo di = new DirectoryInfo(System.IO.Path.Combine(targetPath, "update"));
                                if (di.Exists)
                                {
                                    foreach(FileInfo fi in di.GetFiles())
                                    {
                                        fi.Delete();
                                    }
                                }
                                if (!di.Exists)
                                {
                                    di.Create();
                                }


                                using (var wc = new WebClient())
                                {
                                    Console.WriteLine(System.IO.Path.Combine(di.FullName, "wec.zip"));
                                    wc.DownloadFile(wecURL, System.IO.Path.Combine(di.FullName, "wec.zip"));
                                    Console.Write("\rDownload Complete.                                                           ");
                                    FileInfo fi = new FileInfo(System.IO.Path.Combine(di.FullName, "wec.zip"));
                                    if (fi.Exists)
                                    {
                                        Console.Write("\rUnZip...                                                   ");
                                        ZipFile.ExtractToDirectory(fi.FullName, di.FullName);
                                        fi.Delete();
                                    }
                                }

                                string filePath = System.IO.Path.Combine(targetPath, "wec-update.bat");
                                System.IO.File.WriteAllText(filePath, BatchFile(targetPath), Encoding.Default);
                                Console.Write("\rRun at wec-update.bat.                                                       ");
                            }
                        }
                        else if (List.ContainsKey("-V") || List.ContainsKey("-VERSION"))
                        {
                            Console.WriteLine("Latest Version is 1.0.0");
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
                    Console.WriteLine("Welcome SimpleWeb WebEngine Helper Command (v1.0)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Help()
        {
            Console.WriteLine("WebEngine Helper Command Guide");
            Console.WriteLine("");
            Console.WriteLine("/?, /Help : You can see instructions on how to use it.");
            Console.WriteLine("");
            Console.WriteLine("-i {install path}, -install {install path}: Install the latest version of WebEngine.");
            Console.WriteLine("-u {install path}, -update {install path}: update the latest version of WebEngine.");
            Console.WriteLine("-v, -version: Display latest version of WebEngine.");
            Console.WriteLine("-v {version}, -version {version} + install or update : Installing with a specific version.");
            Console.WriteLine("");
            Console.WriteLine("Welcome WebEngine Helper Command.");
        }

        static string BatchFile(string path)
        {
            StringBuilder builder = new StringBuilder(200);
            builder.AppendLine("@echo off");
            builder.AppendLine("echo Updating...");
            builder.AppendLine($"@xcopy {path}update\\*.* {path} /E /C /H /Y /Q /d");
            builder.AppendLine($"@del {path}update\\*.* /Q");
            builder.AppendLine($"@rmdir {path}update");
            builder.AppendLine("echo Update Complete");
            builder.AppendLine($"@del {path}wec-update.bat /Q");
            return builder.ToString();
        }
    }
}
