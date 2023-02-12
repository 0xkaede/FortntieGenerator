using CUE4Parse.FileProvider;
using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Objects.Core.i18N;
using CUE4Parse.UE4.Objects.UObject;
using FortniteGenerator.Enums;
using FortniteGenerator.Models;
using FortniteGenerator.Util;
using Newtonsoft.Json;

namespace FortniteGenerator.Generator.Emotes
{
    public static class GenerateEmote
    {
        private static DefaultFileProvider _provider = KaedeProvider._provider;

        public static List<string> Id = new List<string>();

        private static List<Items> items = new List<Items>();

        public async static Task GenerateBase(string assetPath)
        {
            try
            {
                if (!_provider.TryLoadObject(assetPath, out var asset))
                    Logger.Log($"Failed to export {assetPath}", LogLevel.Error);

                if (!asset.TryGetValue(out FText displayName, "DisplayName"))
                    Logger.Log($"Failed to get displayName for {assetPath}", LogLevel.Error);

                if (!asset.TryGetValue(out FText description, "Description"))
                    Logger.Log($"Failed to get description for {assetPath}", LogLevel.Error);


                var emote = new Items
                {
                    Name = displayName.Text,
                    Description = description.Text,
                    Id = assetPath.Split("/").LastOrDefault(),
                    Options = new List<Options>()
                };

                foreach (var option in OptionsBase.GetEmotes())
                {
                    foreach (var optionAsset in option.Assets)
                    {
                        foreach (var swap in optionAsset.Swaps)
                        {
                            if (swap.SwapType == SwapTypes.Animation)
                            {
                                if(!asset.TryGetValue(out FSoftObjectPath CMM, "Animation"))
                                    swap.Replace = Constants.FallbackString;
                                else
                                    swap.Replace = CMM.AssetPathName.Text;
                            }
                            
                            if (swap.SwapType == SwapTypes.AnimationFemaleOverride)
                            {
                                if(!asset.TryGetValue(out FSoftObjectPath CMF, "AnimationFemaleOverride"))
                                    swap.Replace = Constants.FallbackString;
                                else
                                    swap.Replace = CMF.AssetPathName.Text;
                            }
                            
                            if (swap.SwapType == SwapTypes.SmallPreviewImage)
                            {
                                if(!asset.TryGetValue(out FSoftObjectPath SmallPreviewImage, "SmallPreviewImage"))
                                    swap.Replace = Constants.FallbackString;
                                else
                                    swap.Replace = SmallPreviewImage.AssetPathName.Text;
                            }
                            
                            if (swap.SwapType == SwapTypes.LargePreviewImage)
                            {
                                if(!asset.TryGetValue(out FSoftObjectPath LargePreviewImage, "LargePreviewImage"))
                                    swap.Replace = Constants.FallbackString;
                                else
                                    swap.Replace = LargePreviewImage.AssetPathName.Text;
                            }
                        }
                    }
                    emote.Options.Add(option);
                }

                items.Add(emote);

                Logger.Log($"Item: {emote.Id} was generated with {emote.Options.Count} option's");
            }
            catch
            {
                Logger.Log($"Cant do {assetPath} for reason", LogLevel.Error);
            }
        }

        public async static Task GenerateIds()
        {
            foreach (var asset in _provider.Files)
                if (!asset.Key.Contains("/Tandem/"))
                    if (asset.Key.Contains("FortniteGame/Content/Athena/Items/Cosmetics/Dances/"))
                        Id.Add(asset.Key.Split(".").FirstOrDefault());

            Id.Sort();
        }

        public async static Task Save()
        {
            await File.WriteAllTextAsync(Constants.EmoteFile, JsonConvert.SerializeObject(items, Formatting.Indented));
            await File.WriteAllTextAsync(Constants.EmoteFileCompressed,
                FileUtil.Compress(await File.ReadAllTextAsync(Constants.EmoteFile)));
        }
    }
}