using FortniteGenerator.FortniteApi;
using FortniteGenerator.Generator.Skins;
using FortniteGenerator.Models;

namespace MyApp.Generator;

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
}