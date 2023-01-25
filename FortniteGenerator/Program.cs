using FortniteGenerator.Generator.Skins;
using FortniteGenerator.Util;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class FortniteGenerator
    {
        public static async Task Main(string[] args)
            => await RunAsync();

        async static Task RunAsync()
        {
            await KaedeProvider.Init();

            await GenerateSkins.GenerateBase();
        }
    }
}