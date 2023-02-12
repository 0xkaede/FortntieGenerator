using FortniteGenerator.Generator.Skins;
using FortniteGenerator.Util;
using System;
using System.Diagnostics;
using FortniteGenerator.Generator.Emotes;
using MyApp.Generator.BackBlings;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FortniteGenerator // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await RunAsync();

        async static Task RunAsync()
        {
            Directory.CreateDirectory(Constants.BasePath);
            Directory.CreateDirectory(Constants.ItemsPath);
            
            Console.Write("1) Skins \n2) Backblings\n3) Emotes\nPlease select as option you want to generate:");
            var num = Console.ReadLine();
            
            
            Console.Clear();

            if (num == "1")
            {
                Logger.Log("Generating Skins in Skins.Json!");
                await SkinsAsync();
            }
            
            if (num == "2")
            {
                Logger.Log("Generating Backblings in Backblings.Json!");
                await BackblingAsync();
            }
            
            if (num == "3")
            {
                Logger.Log("Generating Emotes in Emotes.Json!");
                await EmoteAsync();
            }
            
            Console.WriteLine("\nPress enter to continute...");
            Console.ReadKey();
        }

        async static Task SkinsAsync()
        {
            await KaedeProvider.Init();
            
            var sw = Stopwatch.StartNew();
            await GenerateSkins.GenerateIds();

            foreach (var id in GenerateSkins.Id)
                await GenerateSkins.GenerateBase(id);

            await GenerateSkins.Save();
            
            Logger.Log($"Done in {sw.Elapsed.Minutes}m and {sw.Elapsed.Seconds}s");
        }
        
        async static Task BackblingAsync()
        {
            await KaedeProvider.Init();
            
            var sw = Stopwatch.StartNew();
            await BackblingGenerator.GenerateIds();

            foreach (var id in BackblingGenerator.Id)
                await BackblingGenerator.GenerateBase(id);

            await BackblingGenerator.Save();
            
            Logger.Log($"Done in {sw.Elapsed.Minutes}m and {sw.Elapsed.Seconds}s");
        }
        
        async static Task EmoteAsync()
        {
            await KaedeProvider.Init();
            
            var sw = Stopwatch.StartNew();
            await GenerateEmote.GenerateIds();

            foreach (var id in GenerateEmote.Id)
                await GenerateEmote.GenerateBase(id);

            await GenerateEmote.Save();
            
            Logger.Log($"Done in {sw.Elapsed.Minutes}m and {sw.Elapsed.Seconds}s");
        }
    }
}