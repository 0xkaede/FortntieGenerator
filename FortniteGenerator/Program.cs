using FortniteGenerator.Generator.Skins;
using FortniteGenerator.Util;
using System;
using System.Diagnostics;
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
            Console.Write("1) Skins \nPlease select as option you want to generate:");
            var num = Console.ReadLine();
            
            Console.Clear();
            
            await KaedeProvider.Init();

            if (num == "1")
            {
                Logger.Log("Generating Skins in Skins.Json!");
                await SkinsAsync();
            }
        }

        async static Task SkinsAsync()
        {
            var sw = Stopwatch.StartNew();
            await GenerateSkins.GenerateIds();

            foreach (var id in GenerateSkins.Id)
                await GenerateSkins.GenerateBase(id);

            await GenerateSkins.Save();
            
            Logger.Log($"Done in {sw.Elapsed.Minutes}m and {sw.Elapsed.Seconds}s");
        }
    }
}