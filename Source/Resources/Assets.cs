using Foster.Framework;

namespace Platformer.Resources;

public static class Assets {
    public static Dictionary<string, Texture> Textures = new();

    private const string ASSETS_PATH = "Assets";
    private static string? m_Path = null!;

    public static string AssetsPath {
        get {
            if(m_Path == null){
                var up = "";
                while(!Directory.Exists(Path.Join(up, ASSETS_PATH)) && up.Length < 10){
                    up = Path.Join(up, "..");
                }

                m_Path = Path.Join(up, ASSETS_PATH);
            }

            return m_Path ?? throw new Exception("Unable to find assets path");
        }
    }

    public static void Load(){
        var texturesPath = Path.Join(AssetsPath, "Textures");
        
        foreach(var tex in Directory.EnumerateFiles(texturesPath, "*.png", SearchOption.AllDirectories)){
            var name = Path.ChangeExtension(Path.GetRelativePath(texturesPath, tex), null);

            var fullAssetsPath = Path.GetFullPath(Path.Combine(AssetsPath, @"..\"));
            var fullPath = Path.Join(fullAssetsPath, tex);

            var img = new Image(fullPath);
            Textures.Add(name, new Texture(img));
        }
        
    }
}