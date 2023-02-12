using FortniteGenerator.Enums;
using FortniteGenerator.Models;

namespace FortniteGenerator.Generator.Skins;

public class BlazeSwap
{
    public static Options Get()
    {
        return new Options
        {
            Name = "Blaze",
            Description = "Fill the world with flames.",
            Id = "CID_784_Athena_Commando_F_RenegadeRaiderFire",
            Assets = new List<Assets>
            {
                new Assets()
                {
                    ParentAsset =
                        "/Game/Athena/Heroes/Meshes/Bodies/CP_Athena_Body_F_RenegadeRaiderFire",
                    Swaps = new List<Swaps>
                    {
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_Med_Soldier_01/Meshes/F_Med_Soldier_01.F_Med_Soldier_01",
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
                                "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_Body.MI_F_MED_Renegade_Raider_Fire_Body",
                            SwapType = SwapTypes.MaterialOverrides
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_Med_Soldier_01/Meshes/F_Med_Soldier_01_Skeleton_AnimBP.F_Med_Soldier_01_Skeleton_AnimBP_C",
                            SwapType = SwapTypes.AnimClass
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Effects/Fort_Effects/Effects/Characters/Athena_Parts/RenegadeRaider_Fire/NS_RenegadeRaider_Fire.NS_RenegadeRaider_Fire",
                            Replace = "/Game/Kaede.Kaede",
                            SwapType = SwapTypes.None
                        },
                    }
                },

                new Assets()
                {
                    ParentAsset =
                        "/Game/Characters/CharacterParts/Female/Medium/Heads/CP_Head_F_RenegadeRaiderFire",
                    Swaps = new List<Swaps>
                    {
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Heads/F_MED_ASN_Sarah_Head_01/Meshes/F_MED_ASN_Sarah_Head_01.F_MED_ASN_Sarah_Head_01",
                            SwapType = SwapTypes.SkeletalMesh
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_Head.MI_F_MED_Renegade_Raider_Fire_Head",
                            SwapType = SwapTypes.MaterialOverrides
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Heads/F_MED_ASN_Sarah_Head_01/Meshes/F_MED_ASN_Sarah_Head_01_AnimBP_Child.F_MED_ASN_Sarah_Head_01_AnimBP_Child_C",
                            SwapType = SwapTypes.AnimClass
                        }
                    }
                },

                new Assets()
                {
                    ParentAsset =
                        "/Game/Characters/CharacterParts/Hats/CP_Hat_F_Commando_RenegadeRaiderFire",
                    Swaps = new List<Swaps>
                    {
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Holiday/Meshes/Parts/F_MED_Renegade_Raider_Holiday.F_MED_Renegade_Raider_Holiday",
                            SwapType = SwapTypes.SkeletalMesh
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Fire/Materials/MI_F_MED_Renegade_Raider_Fire_FaceAcc.MI_F_MED_Renegade_Raider_Fire_FaceAcc",
                            SwapType = SwapTypes.MaterialOverrides
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Renegade_Raider_Holiday/Meshes/Parts/F_MED_Renegade_Raider_Holiday_AnimBP.F_MED_Renegade_Raider_Holiday_AnimBP_C",
                            SwapType = SwapTypes.AnimClass
                        }
                    }
                }
            }
        };
    }
}