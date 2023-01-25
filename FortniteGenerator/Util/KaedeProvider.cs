using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider;
using CUE4Parse.MappingsProvider;
using CUE4Parse.UE4.Objects.Core.Misc;
using CUE4Parse.UE4.Versions;
using FortniteGenerator.FortniteApi;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteGenerator.Util
{
    public class KaedeProvider
    {
        public static DefaultFileProvider _provider;

        public async static Task Init()
        {
            var aes = await FortniteAPI.GetAESKeys();

            _provider = new DefaultFileProvider(FortniteUtil.PakPath, SearchOption.TopDirectoryOnly, false, new VersionContainer(EGame.GAME_UE5_2));
            _provider.Initialize();

            var keys = new List<KeyValuePair<FGuid, FAesKey>>
            {
                new KeyValuePair<FGuid, FAesKey>(new FGuid(), new FAesKey(aes.MainKey))
            };

            keys.AddRange(aes.DynamicKeys.Select(x => new KeyValuePair<FGuid, FAesKey>(new FGuid(x.PakGuid), new FAesKey(x.Key))));
            _provider.SubmitKeys(keys);

            var latestUsmapInfo = new DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles("*_oo.usmap").FirstOrDefault();

            _provider.MappingsContainer =
                new FileUsmapTypeMappingsProvider(latestUsmapInfo.FullName);

            Logger.Log($"Mappings pulled from file: {latestUsmapInfo.Name}");

            Logger.Log($"File provider initialized with {_provider.Keys.Count} keys");
        }
    }
}
