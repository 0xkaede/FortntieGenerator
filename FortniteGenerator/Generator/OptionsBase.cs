using FortniteGenerator.FortniteApi;
using FortniteGenerator.Generator.BackBlings;
using FortniteGenerator.Generator.Emotes;
using FortniteGenerator.Generator.Skins;
using FortniteGenerator.Models;

namespace FortniteGenerator.Generator;

public class OptionsBase
{
    public static List<Options> GetSkins()
    {
        List<Options> options = new List<Options>();
        
        options.Add(ArcticAdelineSwap.Get());
        options.Add(MechaStrikeNavigator.Get());
        options.Add(BlazeSwap.Get());
        return options;
    }
    
    public static List<Options> GetBackBling()
    {
        List<Options> options = new List<Options>();
        
        options.Add(FrozenRedShieldSwap.Get());
        return options;
    }
    
    public static List<Options> GetEmotes()
    {
        List<Options> options = new List<Options>();
        
        options.Add(BoogieDownSwap.Get());
        return options;
    }
}