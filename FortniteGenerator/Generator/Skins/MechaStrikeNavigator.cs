using FortniteGenerator.Enums;
using FortniteGenerator.Models;

namespace FortniteGenerator.Generator.Skins;

public class MechaStrikeNavigator
{
    public static Options Get()
    {
        return new Options
        {
            Name = "Mecha Strike Navigator",
            Description = "Mecha Strike Command needs you.",
            Id = "CID_A_416_Athena_Commando_M_Armadillo",
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
                },

                new Assets()
                {
                    ParentAsset =
                        "/Game/Characters/CharacterParts/FaceAccessories/CP_F_MED_SportsFashion_Winter_FaceAcc",
                    Swaps = new List<Swaps>
                    {
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Sports_Fashion/Meshes/Parts/F_MED_Sports_Fashion_FaceAcc_AnimBP.F_MED_Sports_Fashion_FaceAcc_AnimBP_C",
                            SwapType = SwapTypes.AnimClass
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Sports_Fashion/Meshes/Parts/F_MED_Sports_Fashion_FaceAcc.F_MED_Sports_Fashion_FaceAcc",
                            SwapType = SwapTypes.SkeletalMesh
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Characters/Player/Female/Medium/Bodies/F_MED_Sports_Fashion/Skins/Winter/Materials/F_MED_SportsFashion_Winter_FaceAcc.F_MED_SportsFashion_Winter_FaceAcc",
                            SwapType = SwapTypes.MaterialOverrides
                        }
                    }
                }
            }
        };
    }
}