using CUE4Parse.FileProvider;
using CUE4Parse.GameTypes.FN.Enums;
using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Objects.Core.i18N;
using CUE4Parse.UE4.Objects.UObject;
using CUE4Parse;
using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider;
using CUE4Parse.MappingsProvider;
using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Objects.Core.i18N;
using CUE4Parse.UE4.Objects.Core.Misc;
using CUE4Parse.UE4.Versions;
using FortniteGenerator.Enums;
using FortniteGenerator.Models;
using FortniteGenerator.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUE4Parse.Utils;
using FortniteGenerator.Generator;

namespace MyApp.Generator.BackBlings;

public class BackblingGenerator
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

            var backbling = new Items
            {
                Name = displayName.Text,
                Description = description.Text,
                Id = assetPath.Split("/").LastOrDefault(),
                Options = new List<Options>()
            };

            if (!asset.TryGetValue(out UObject[] characterParts, "CharacterParts"))
                Logger.Log($"Failed to get BaseCharacterParts for {assetPath}", LogLevel.Error);


            foreach (var option in OptionsBase.GetBackBling())
            {
                foreach (var optionasset in option.Assets)
                {
                    var characterAssetPath = characterParts.FirstOrDefault().GetPathName();
                    
                    
                    if (!_provider.TryLoadObject(characterAssetPath.Split('.').FirstOrDefault(),
                            out var characterAsset))
                        Logger.Log($"Failed to get {characterAssetPath}", LogLevel.Error);

                    foreach (var swap in optionasset.Swaps)
                    {
                        if (swap.SwapType == SwapTypes.SkeletalMesh)
                        {
                            if (!characterAsset.TryGetValue(out FSoftObjectPath skeletalMesh, "SkeletalMesh"))
                                swap.Replace = Constants.FallbackString;
                            else
                                swap.Replace = skeletalMesh.AssetPathName.Text;
                        }
                        
                        if (swap.SwapType == SwapTypes.AnimClass)
                        {
                            if (!characterAsset.TryGetValue(out UObject additionalData, "AdditionalData"))
                                swap.Replace = swap.Search;

                            if (!additionalData.TryGetValue(out FSoftObjectPath animClass, "AnimClass"))
                                swap.Replace = swap.Search;
                            else
                                swap.Replace = animClass.AssetPathName.Text;
                        }
                        
                        if (swap.SwapType == SwapTypes.MaterialOverrides)
                        {
                            if (!characterAsset.TryGetValue(out FStructFallback[] materialOverrides,
                                    "MaterialOverrides"))
                            {
                                swap.Replace = Constants.FallbackString;
                                continue;
                            }

                            if (!materialOverrides.FirstOrDefault()
                                    .TryGetValue(out FSoftObjectPath overrideMaterial, "OverrideMaterial"))
                                swap.Replace = Constants.FallbackString;
                            else
                                swap.Replace = overrideMaterial.AssetPathName.Text;
                        }
                    }
                    
                }
                
                backbling.Options.Add(option);
            }
            
            items.Add(backbling);

            Logger.Log($"Item: {backbling.Id} was generated with {backbling.Options.Count} option's");
        }
        catch (Exception ex)
        {
            Logger.Log($"Cant do {assetPath} for reason", LogLevel.Error);
        }
        
    }

    public async static Task GenerateIds()
    {
        foreach (var asset in _provider.Files)
            if (!asset.Key.Contains("/Tandem/"))
                if (asset.Key.Contains("FortniteGame/Content/Athena/Items/Cosmetics/Backpacks/"))
                    Id.Add(asset.Key.Split(".").FirstOrDefault());

        Id.Sort();
    }
    
    public async static Task Save()
    {
        await File.WriteAllTextAsync(Constants.BackBlingsFile, JsonConvert.SerializeObject(items, Formatting.Indented));
        await File.WriteAllTextAsync(Constants.BackBlingsFileCompressed,
            FileUtil.Compress(await File.ReadAllTextAsync(Constants.BackBlingsFile)));
    }
}