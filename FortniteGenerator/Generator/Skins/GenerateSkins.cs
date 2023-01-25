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

namespace FortniteGenerator.Generator.Skins
{
    public static class GenerateSkins
    {
        private static DefaultFileProvider _provider = KaedeProvider._provider;

        private static List<Items> items = new List<Items>();

        public async static Task GenerateBase()
        {
            var assetPath = "FortniteGame/Content/Athena/Items/Cosmetics/Characters/CID_028_Athena_Commando_F";

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

            foreach (var option in options)
            {
                bool isPosible = true;
                foreach (var optionasset in option.Assets)
                {
                    if (optionasset.ParentAsset.Contains("Bodies"))
                    {
                        var characterAssetPath = characterParts.FirstOrDefault(x => x.GetPathName().Contains("Bodies"))
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
                        var characterAssetPath = characterParts.FirstOrDefault(x => x.GetPathName().Contains("Heads"))
                            .GetPathName();

                        if (!_provider.TryLoadObject(characterAssetPath.Split('.').FirstOrDefault(),
                                out var characterAsset))
                            Logger.Log($"Failed to get {characterAssetPath}", LogLevel.Error);

                        foreach (var swap in optionasset.Swaps)
                        {
                            if (swap.SwapType == SwapTypes.HairColorSwatch)
                            {
                                if (!characterAsset.TryGetValue(out UObject additionalData, "AdditionalData"))
                                    Logger.Log($"Cant get AddtionalData for {characterAsset.GetFullName()}", LogLevel.Error);

                                if (!additionalData.TryGetValue(out FSoftObjectPath hairColorSwatch, "HairColorSwatch"))
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

                    if (optionasset.ParentAsset.Contains("Hats") || optionasset.ParentAsset.Contains("FaceAccessories"))
                    {
                        var characterAssetPath = characterParts.FirstOrDefault(x => x.GetPathName().Contains("Hats"))
                            .GetPathName();

                        if (characterAssetPath == null)
                            characterAssetPath = characterParts
                                .FirstOrDefault(x => x.GetPathName().Contains("FaceAccessories")).GetPathName();
                        
                        if (!_provider.TryLoadObject(characterAssetPath.Split('.').FirstOrDefault(),
                                out var characterAsset))
                            Logger.Log($"Failed to get {characterAssetPath}", LogLevel.Error);

                        foreach (var swap in optionasset.Swaps)
                        {
                            if(!characterAsset.TryGetValue(out UObject additionalData, "AdditionalData"))
                                Logger.Log($"Cant get AddtionalData for {characterAsset.GetFullName()}");

                            additionalData.GetOrDefault("HatType",
                                CustomHatType.ECustomHatType_None, StringComparison.OrdinalIgnoreCase);
                                swap.Replace = animClass.AssetPathName.Text;
                        }
                    }
                }

                if (isPosible)
                    skin.Options.Add(option);
            }


            File.WriteAllText("skins.json", JsonConvert.SerializeObject(skin, Formatting.Indented));
        }

        public static List<Options> options = new List<Options>
        {
            new Options
            {
                Name = "Arctic Adeline",
                Description = "Tis the season for fashion.",
                Id = "Character_SportsFashion_Winter",
                Assets = new List<Assets>
                {
                    new Assets()
                    {
                        ParentAsset =
                            "/Game/Athena/Heroes/Meshes/Bodies/CP_Body_Commando_F_SportsFashion_Winter",
                        Swaps = new List<Swaps>
                        {
                            new Swaps()
                            {
                                Search =
                                    "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Sports_Fashion/Meshes/F_MED_Sports_Fashion.F_MED_Sports_Fashion",
                                SwapType = SwapTypes.SkeletalMesh
                            },
                            new Swaps()
                            {
                                Search =
                                    "/Game/Characters/Player/Female/Medium/Base/SK_M_Female_Base_Skeleton.SK_M_Female_Base_Skeleton",
                                SwapType = SwapTypes.MasterSkeletalMeshes
                            },
                            new Swaps()
                            {
                                Search =
                                    "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Sports_Fashion/Skins/Winter/Materials/F_MED_SportsFashion_Winter_Body.F_MED_SportsFashion_Winter_Body",
                                SwapType = SwapTypes.MaterialOverrides
                            },
                            new Swaps()
                            {
                                Search =
                                    "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Sports_Fashion/Meshes/F_MED_Sports_Fashion_AnimBP.F_MED_Sports_Fashion_AnimBP_C",
                                SwapType = SwapTypes.AnimClass
                            },
                        }
                    },

                    new Assets()
                    {
                        ParentAsset =
                            "/Game/Characters/CharacterParts/Female/Medium/Heads/CP_Head_F_SportsFashion_Winter",
                        Swaps = new List<Swaps>
                        {
                            new Swaps()
                            {
                                Search = "/Game/Characters/CharacterColorSwatches/Hair/HairColor_01.HairColor_01",
                                SwapType = SwapTypes.HairColorSwatch
                            },
                            new Swaps()
                            {
                                Search =
                                    "/Game/Characters/Player/Female/Medium/Heads/F_MED_Handler_Head_01/Meshes/F_MED_Handler_Head_AnimBP_Child.F_MED_Handler_Head_AnimBP_Child_C",
                                SwapType = SwapTypes.AnimClass
                            },
                            new Swaps()
                            {
                                Search =
                                    "/Game/Characters/Player/Female/Medium/Heads/F_MED_Handler_Head_01/Meshes/Female_Medium_Handler_Head_02.Female_Medium_Handler_Head_02",
                                SwapType = SwapTypes.SkeletalMesh
                            },
                            new Swaps()
                            {
                                Search =
                                    "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Sports_Fashion/Skins/Winter/Materials/F_MED_SportsFashion_Head.F_MED_SportsFashion_Head",
                                SwapType = SwapTypes.MaterialOverrides
                            },
                        }
                    }
                }
            }
        };
    }
}