using FortniteGenerator.Enums;
using FortniteGenerator.Models;

namespace FortniteGenerator.Generator.Emotes;

public class BoogieDownSwap
{
    public static Options Get()
    {
        return new Options
        {
            Name = "Boogie Down",
            Description = "Boogie Down with Populotus.",
            Id = "EID_BoogieDown",
            Assets = new List<Assets>
            {
                new Assets()
                {
                    ParentAsset =
                        "FortniteGame/Content/Athena/Items/Cosmetics/Dances/EID_BoogieDown",
                    Swaps = new List<Swaps>
                    {
                        new Swaps()
                        {
                            Search =
                                "/Game/Animation/Game/MainPlayer/Emotes/Boogie_Down/Emote_Boogie_Down_CMM.Emote_Boogie_Down_CMM",
                            SwapType = SwapTypes.Animation
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/Animation/Game/MainPlayer/Emotes/Boogie_Down/Emote_Boogie_Down_CMF.Emote_Boogie_Down_CMF",
                            SwapType = SwapTypes.AnimationFemaleOverride
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/UI/Foundation/Textures/Icons/Emotes/T-Icon-Emotes-E-BoogieDown-L.T-Icon-Emotes-E-BoogieDown-L",
                            SwapType = SwapTypes.LargePreviewImage
                        },
                        new Swaps()
                        {
                            Search =
                                "/Game/UI/Foundation/Textures/Icons/Emotes/T-Icon-Emotes-E-BoogieDown.T-Icon-Emotes-E-BoogieDown",
                            SwapType = SwapTypes.SmallPreviewImage
                        }
                    }
                }

            }
        };
    }
}