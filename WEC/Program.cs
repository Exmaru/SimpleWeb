using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace WEC
{
    class Program
    {
        const string LatestDownload = "http://simpleweb.exmaru.com/Content/release/latest.zip";

        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                string command = args[0].Trim();

                if (command.Substring(0, 1) == "/")
                {
                    switch (command.ToUpper())
                    {
                        case "/?":
                        case "/HELP":
                            Help();
                            break;
                        default:
                            Console.WriteLine($"Unknown command : {command}");
                            Console.WriteLine("Please refer to Help. (/help or /?)");
                            break;
                    }
                }
                else if (command.Substring(0, 1) == "-")
                {
                    switch (command.ToUpper())
                    {
                        case "-I":
                        case "-INSTALL":
                            if (args.Length > 1)
                            {
                                try
                                {
                                    string folder = args[1].Trim();
                                    Console.Write("Downloading... Hold on a moment, please.");
                                    DirectoryInfo di = new DirectoryInfo(folder);
                                    if (!di.Exists)
                                    {
                                        di.Create();
                                    }

                                    using (var wc = new WebClient())
                                    {
                                        wc.DownloadFile(LatestDownload, System.IO.Path.Combine(di.FullName, "release.zip"));
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
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("The option is missing.");
                            }
                            break;
                        default:
                            Console.WriteLine($"Unknown command : {command}");
                            Console.WriteLine("Please refer to Help. (/help or /?)");
                            break;
                    }
                }
                else
                {
                    switch (command.ToUpper())
                    {
                        case "":
                            break;
                        default:
                            Console.WriteLine("Unknown command : {command}");
                            Console.WriteLine("Please refer to Help. (/help or /?)");
                            break;
                    }
                }


            }
            else
            {
                Console.WriteLine("Welcome SimpleWeb WebEngine Helper Command (v1.0)");
            }
        }

        static void Help()
        {
            Console.WriteLine("WebEngine Helper Command Guide");
            Console.WriteLine("");
            Console.WriteLine("/?, /Help : You can see instructions on how to use it.");
            Console.WriteLine("");
            Console.WriteLine("-i {install path}, -install {install path}: Install the latest version of WebEngine.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        protected static void WriteProgress(string s, int x)
        {
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;
            // Console.WindowWidth = 10;  // this works. 
            int width = Console.WindowWidth;
            x = x % width;
            try
            {
                Console.SetCursorPosition(x, 1);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {

            }
            finally
            {
                try
                {
                    Console.SetCursorPosition(origRow, origCol);
                }
                catch (ArgumentOutOfRangeException e)
                {
                }
            }
        }
    }
}
