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
using MyApp.Generator;

namespace FortniteGenerator.Generator.Skins
{
    public static class GenerateSkins
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


                var skin = new Items
                {
                    Name = displayName.Text,
                    Description = description.Text,
                    Id = assetPath.Split("/").LastOrDefault(),
                    Options = new List<Options>()
                };

                if (!asset.TryGetValue(out UObject[] characterParts, "BaseCharacterParts"))
                    Logger.Log($"Failed to get BaseCharacterParts for {assetPath}", LogLevel.Error);

                foreach (var option in OptionsBase.GetSkins())
                {
                    bool isPosible = true;
                    foreach (var optionasset in option.Assets)
                    {
                        if (optionasset.ParentAsset.Contains("Bodies"))
                        {
                            var characterAssetPath = characterParts
                                .FirstOrDefault(x => x.GetPathName().Contains("Bodies"))
                                .GetPathName();

                            if (!_provider.TryLoadObject(characterAssetPath.Split('.').FirstOrDefault(),
                                    out var characterAsset))
                                Logger.Log($"Failed to get {characterAssetPath}", LogLevel.Error);

                            foreach (var swap in optionasset.Swaps)
                            {
                                if (swap.SwapType == SwapTypes.SkeletalMesh)
                                {
                                    if (!characterAsset.TryGetValue(out FSoftObjectPath skeletalMesh, "SkeletalMesh"))
                                        swap.Replace = "/Game/kaede.kaede";
                                    else
                                        swap.Replace = skeletalMesh.AssetPathName.Text;
                                }

                                if (swap.SwapType == SwapTypes.MasterSkeletalMeshes)
                                {
                                    if (!characterAsset.TryGetValue(out FSoftObjectPath[] masterSkeletalMeshes,
                                            "MasterSkeletalMeshes"))
                                        swap.Replace = "/Game/kaede.kaede";
                                    else
                                        swap.Replace = masterSkeletalMeshes.FirstOrDefault().AssetPathName.Text;
                                }

                                if (swap.SwapType == SwapTypes.MaterialOverrides)
                                {
                                    if (!characterAsset.TryGetValue(out FStructFallback[] materialOverrides,
                                            "MaterialOverrides"))
                                    {
                                        swap.Replace = "/Game/kaede.kaede";
                                        continue;
                                    }

                                    if (!materialOverrides.FirstOrDefault()
                                            .TryGetValue(out FSoftObjectPath overrideMaterial, "OverrideMaterial"))
                                        swap.Replace = "/Game/kaede.kaede";
                                    else
                                        swap.Replace = overrideMaterial.AssetPathName.Text;
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
                            }
                        }

                        if (optionasset.ParentAsset.Contains("Heads"))
                        {
                            var characterAssetPath = characterParts
                                .FirstOrDefault(x => x.GetPathName().Contains("Heads"))
                                .GetPathName();

                            if (!_provider.TryLoadObject(characterAssetPath.Split('.').FirstOrDefault(),
                                    out var characterAsset))
                                Logger.Log($"Failed to get {characterAssetPath}", LogLevel.Error);

                            foreach (var swap in optionasset.Swaps)
                            {
                                if (swap.SwapType == SwapTypes.HairColorSwatch)
                                {
                                    if (!characterAsset.TryGetValue(out UObject additionalData, "AdditionalData"))
                                        Logger.Log($"Cant get AddtionalData for {characterAsset.GetFullName()}",
                                            LogLevel.Error);

                                    if (!additionalData.TryGetValue(out FSoftObjectPath hairColorSwatch,
                                            "HairColorSwatch"))
                                        swap.Replace = "/Game/Kaede.Kaede";
                                    else
                                        swap.Replace = hairColorSwatch.AssetPathName.Text;
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

                                if (swap.SwapType == SwapTypes.SkeletalMesh)
                                {
                                    if (!characterAsset.TryGetValue(out FSoftObjectPath skeletalMesh, "SkeletalMesh"))
                                        swap.Replace = "/Game/kaede.kaede";
                                    else
                                        swap.Replace = skeletalMesh.AssetPathName.Text;
                                }

                                if (swap.SwapType == SwapTypes.MaterialOverrides)
                                {
                                    if (!characterAsset.TryGetValue(out FStructFallback[] materialOverrides,
                                            "MaterialOverrides"))
                                    {
                                        swap.Replace = "/Game/kaede.kaede";
                                        continue;
                                    }

                                    if (!materialOverrides.FirstOrDefault()
                                            .TryGetValue(out FSoftObjectPath overrideMaterial, "OverrideMaterial"))
                                        swap.Replace = "/Game/kaede.kaede";
                                    else
                                        swap.Replace = overrideMaterial.AssetPathName.Text;
                                }
                            }
                        }

                        if (optionasset.ParentAsset.Contains("Hats") ||
                            optionasset.ParentAsset.Contains("FaceAccessories"))
                        {
                            var characterAssetPath = string.Empty;
                            try
                            {
                                characterAssetPath = characterParts
                                    .FirstOrDefault(x => x.GetPathName().Contains("Hats"))
                                    .GetPathName();
                            }
                            catch
                            {
                                try
                                {
                                    characterAssetPath = characterParts
                                        .FirstOrDefault(x => x.GetPathName().Contains("FaceAccessories"))
                                        .GetPathName();
                                }
                                catch (Exception e)
                                {
                                    return;
                                }
                            }

                            if (optionasset.ParentAsset.Contains("Hats"))
                                if (characterAssetPath.Contains("FaceAccessories"))
                                    isPosible = false;

                            if (optionasset.ParentAsset.Contains("FaceAccessories"))
                                if (characterAssetPath.Contains("Hats"))
                                    isPosible = false;

                            if (characterAssetPath == null)
                                characterAssetPath = characterParts
                                    .FirstOrDefault(x => x.GetPathName().Contains("FaceAccessories")).GetPathName();

                            if (!_provider.TryLoadObject(characterAssetPath.Split('.').FirstOrDefault(),
                                    out var characterAsset))
                                Logger.Log($"Failed to get {characterAssetPath}", LogLevel.Error);

                            foreach (var swap in optionasset.Swaps)
                            {
                                if (swap.SwapType == SwapTypes.AnimClass)
                                {
                                    if (!characterAsset.TryGetValue(out UObject additionalData, "AdditionalData"))
                                        swap.Replace = swap.Search;

                                    if (!additionalData.TryGetValue(out FSoftObjectPath animClass, "AnimClass"))
                                        swap.Replace = swap.Search;
                                    else
                                        swap.Replace = animClass.AssetPathName.Text;
                                }

                                if (swap.SwapType == SwapTypes.SkeletalMesh)
                                {
                                    if (!characterAsset.TryGetValue(out FSoftObjectPath skeletalMesh, "SkeletalMesh"))
                                        swap.Replace = "/Game/kaede.kaede";
                                    else
                                        swap.Replace = skeletalMesh.AssetPathName.Text;
                                }

                                if (swap.SwapType == SwapTypes.MaterialOverrides)
                                {
                                    if (!characterAsset.TryGetValue(out FStructFallback[] materialOverrides,
                                            "MaterialOverrides"))
                                    {
                                        swap.Replace = "/Game/kaede.kaede";
                                        continue;
                                    }

                                    if (!materialOverrides.FirstOrDefault()
                                            .TryGetValue(out FSoftObjectPath overrideMaterial, "OverrideMaterial"))
                                        swap.Replace = "/Game/kaede.kaede";
                                    else
                                        swap.Replace = overrideMaterial.AssetPathName.Text;
                                }
                            }
                        }
                    }

                    if (isPosible)
                        skin.Options.Add(option);
                }

                items.Add(skin);

                Logger.Log($"Item: {skin.Id} was generated with {skin.Options.Count} option's");

                File.WriteAllText("skins.json", JsonConvert.SerializeObject(skin, Formatting.Indented));
            }
            catch
            {
                Logger.Log($"Cant do {assetPath} for reason", LogLevel.Error);
            }
        }

        public async static Task GenerateIds()
        {
            foreach (var asset in _provider.Files)
                if(!asset.Key.Contains("/Tandem/"))
                    if (asset.Key.Contains("FortniteGame/Content/Athena/Items/Cosmetics/Characters/"))
                        Id.Add(asset.Key.Split(".").FirstOrDefault());
            
            Id.Sort();
        }

        public async static Task Save()
        {
            await File.WriteAllTextAsync("Skins.Json", JsonConvert.SerializeObject(items, Formatting.Indented));
        }
    }
}