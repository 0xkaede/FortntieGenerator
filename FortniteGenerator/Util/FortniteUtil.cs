using FortniteGenerator.Models;
using K4os.Compression.LZ4;
using Newtonsoft.Json;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteGenerator.Util
{
    internal class FortniteUtil
    {
        public static string PakPath => Path.Combine(GetFortniteInstallation().InstallLocation, "FortniteGame\\Content\\Paks");

        public static EpicInstallation GetFortniteInstallation()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat");

            return !File.Exists(path) ? null : JsonConvert.DeserializeObject<EpicInstalled>(File.ReadAllText(path)).InstallationList.FirstOrDefault(x => x.AppName == "Fortnite");
        }

        public static void LaunchFortnite()
            => Process.Start(new ProcessStartInfo
            {
                FileName = "com.epicgames.launcher://apps/Fortnite?action=launch&silent=true",
                UseShellExecute = true
            });

        public static void VerifyFortnite()
            => Process.Start(new ProcessStartInfo
            {
                FileName = "com.epicgames.launcher://apps/Fortnite?action=verify&silent=false",
                UseShellExecute = true
            });

        public static void KillEpicProcesses()
        {
            var processes = Process.GetProcesses().Where(x => x.ProcessName.Contains("Fortnite") || x.ProcessName.Contains("Epic"));
            foreach (var proc in processes)
                proc.Kill();
        }
    }
}
