using FortniteGenerator.Enums;
using FortniteGenerator.Models;

namespace FortniteGenerator.Generator.BackBlings;

public class FrozenRedShieldSwap
{
    public static Options Get()
    {
        return new Options
        {
            Name = "Frozen Red Shield",
            Description = "The Red Knight's legendary frozen shield.",
            Id = "BID_167_RedKnightWinterFemale",
            Assets = new List<Assets>
            {
                new Assets()
                {
                    ParentAsset =
                        "/Game/Characters/CharacterParts/Backpacks/CP_Backpack_RedKnightWinterFemale",
                    Swaps = new List<Swaps>
                    {
                        new Swaps()
                        {
                            Search =
                                "/Game/Accessories/FORT_Backpacks/Mesh/SK_Shield_Blackknight.SK_Shield_Blackknight",
                            SwapType = SwapTypes.SkeletalMesh
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Accessories/FORT_Backpacks/Materials/Female_Commando_RedKnight_Winter.Female_Commando_RedKnight_Winter",
                            SwapType = SwapTypes.MaterialOverrides
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Accessories/FORT_Backpacks/M_MED_Wegame_Backpack/Meshes/SK_Backpack_Wegame_Skeleton_AnimBlueprint.SK_Backpack_Wegame_Skeleton_AnimBlueprint_C",
                            SwapType = SwapTypes.AnimClass
                        }
                    }
                }
            }
        };
    }
}