using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.Windows;
using System.Windows.Forms;

namespace Server_Installer_Forms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class WorkFunc
    {
        public static void MainFunction()
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string serverFilesPath = currentDir + @"\Server Files";
            string steamcmdZipPath = serverFilesPath + @"\steamcmd.zip";
            string steamcmdExePath = serverFilesPath + @"\steamcmd.exe";
            string scriptPath = serverFilesPath + @"\script.txt";

            if (!Directory.Exists(serverFilesPath))
                Directory.CreateDirectory(serverFilesPath);

            WebClient wcIstall = new WebClient();

            if (!File.Exists(steamcmdZipPath))
                wcIstall.DownloadFile("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip", steamcmdZipPath);

            if (!File.Exists(steamcmdExePath))
                ZipFile.ExtractToDirectory(steamcmdZipPath, serverFilesPath);

            if (!File.Exists(scriptPath))
            {
                string script = "@ShutdownOnFailedCommand 0" +
                    Environment.NewLine + "login anonymous" +
                    Environment.NewLine + @"force_install_dir .\server\" +
                    Environment.NewLine + "app_update 10" +
                    Environment.NewLine + "app_update 70" +
                    Environment.NewLine + "app_update 90 -beta beta" +
                    Environment.NewLine + "quit";

                StreamWriter swScript = new StreamWriter(scriptPath, true, System.Text.Encoding.Default);
                swScript.WriteLine(script);
                swScript.Close();
            }

            Process processSteamCmd = new Process();
            processSteamCmd = Process.Start(steamcmdExePath, "+runscript script.txt");
            processSteamCmd.WaitForExit();

            if (processSteamCmd.HasExited)
            {
                if (MetamodBox.MetamodStatus)
                {
                    WebClient wc = new WebClient();
                    wcIstall.DownloadFile("https://sourceforge.net/projects/metamod-p/files/latest/download?source=files", serverFilesPath + @"\metamod.zip");

                    ZipFile.ExtractToDirectory(serverFilesPath + @"\metamod.zip", serverFilesPath + @"\server\cstrike\addons\metamod\");

                    if (AmxBox.Version != 0)
                    {
                        StreamWriter swMetamodIni = new StreamWriter(serverFilesPath + @"\server\cstrike\addons\metamod\plugins.ini", true, System.Text.Encoding.Default);
                        swMetamodIni.WriteLine(@"addons\amxmodx\dlls\amxmodx_mm.dll");
                        swMetamodIni.Close();
                    }

                    StreamReader srLiblist = new StreamReader(serverFilesPath + @"\server\cstrike\liblist.gam");
                    string oldLiblist = "";
                    string newLiblist = "";

                    oldLiblist = srLiblist.ReadToEnd();
                    srLiblist.Close();

                    if (oldLiblist.Contains(@"gamedll ""dlls\mp.dll"""))
                        newLiblist = oldLiblist.Replace(@"gamedll ""dlls\mp.dll""", @"gamedll ""addons\metamod\metamod.dll""");

                    File.Delete(serverFilesPath + @"\server\cstrike\liblist.gam");
                    File.WriteAllText(serverFilesPath + @"\server\cstrike\liblist.gam", newLiblist);
                }

                if (AmxBox.Version != 0)
                {
                    string amxBaseZipPath = serverFilesPath + @"\amxmodx_base.zip";
                    string amxCstrikeZipPath = serverFilesPath + @"\amxmodx_cstrike.zip";
                    string cstrikePath = serverFilesPath + @"\server\cstrike\";

                    WebClient wc = new WebClient();

                    Stream wcStream = wc.OpenRead("https://www.amxmodx.org/amxxdrop/1.8/");
                    StreamReader wcStreamReader = new StreamReader(wcStream);

                    string webPageContent = wcStreamReader.ReadToEnd();
                    wcStream.Close();

                    string lastAmxBaseVer = "";
                    string lastAmxCstrikeVer = "";

                    if (AmxBox.Version == 1)
                    {
                        lastAmxBaseVer = "https://www.amxmodx.org/release/amxmodx-1.8.2-base-windows.zip";
                        lastAmxCstrikeVer = "https://www.amxmodx.org/release/amxmodx-1.8.2-cstrike-windows.zip";
                    }
                    else if (AmxBox.Version == 2)
                    {
                        for (int i = 60; i < 100; i++)
                        {
                            if (webPageContent.Contains("amxmodx-1.8.2-dev-hg" + i.ToString() + "-cstrike-windows.zip"))
                            {
                                lastAmxBaseVer = "https://www.amxmodx.org/amxxdrop/1.8/" + "amxmodx-1.8.2-dev-hg" + i.ToString() + "-base-windows.zip";
                                lastAmxCstrikeVer = "https://www.amxmodx.org/amxxdrop/1.8/" +  "amxmodx-1.8.2-dev-hg" + i.ToString() + "-cstrike-windows.zip";
                            }
                        }
                    }
                    else if (AmxBox.Version == 3)
                    {
                        for (int i = 5000; i < 10000; i++)
                        {
                            if (webPageContent.Contains("amxmodx-1.8.3-dev-git" + i.ToString() + "-cstrike-windows.zip"))
                            {
                                lastAmxBaseVer = "https://www.amxmodx.org/amxxdrop/1.8/" + "amxmodx-1.8.3-dev-git" + i.ToString() + "-base-windows.zip";
                                lastAmxCstrikeVer = "https://www.amxmodx.org/amxxdrop/1.8/" + "amxmodx-1.8.3-dev-git" + i.ToString() + "-cstrike-windows.zip";
                            }
                        }
                    }

                    wcIstall.DownloadFile(lastAmxBaseVer, amxBaseZipPath);
                    wcIstall.DownloadFile(lastAmxCstrikeVer, amxCstrikeZipPath);

                    ZipFile.ExtractToDirectory(amxBaseZipPath, cstrikePath);
                    ZipArchive zipCstrike = ZipFile.OpenRead(amxCstrikeZipPath);

                    foreach (ZipArchiveEntry entry in zipCstrike.Entries)
                    {
                        if (!entry.FullName.EndsWith("/"))
                            entry.ExtractToFile(cstrikePath + entry.FullName, true);
                    }
                }

                MessageBox.Show("Установка сервера успешно завершена!");
            }
        }
    }
}
