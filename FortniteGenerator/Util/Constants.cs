namespace FortniteGenerator.Util;

public class Constants
{
    public static readonly string BasePath = Directory.GetCurrentDirectory();

    public static readonly string ItemsPath = @$"{BasePath}\Items";

    public static readonly string SkinFile = $@"{ItemsPath}\Skins.Json";
    public static readonly string BackBlingsFile = $@"{ItemsPath}\Backbling.Json";
    public static readonly string PickaxeFile= $@"{ItemsPath}\Pickaxe.Json";
    public static readonly string EmoteFile = $@"{ItemsPath}\Emotes.Json";
    
    public static readonly string SkinFileCompressed = $@"{ItemsPath}\Skins.Compressed";
    public static readonly string BackBlingsFileCompressed = $@"{ItemsPath}\Backbling.Compressed";
    public static readonly string PickaxeFileCompressed= $@"{ItemsPath}\Pickaxe.Compressed";
    public static readonly string EmoteFileCompressed = $@"{ItemsPath}\Emotes.Compressed";

    public static readonly string FallbackString = "/Game/Kaede.Kaede";
}