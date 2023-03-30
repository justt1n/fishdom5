public static class C //save path to resources
{
    public static class Scenes
    {
        public const string Game = "game";
    }

    public static class Layer
    {
        // Path start from Resources/UIPrefabs
        // ex: public const string Loading = "Loading/LoadingUI";
        // mean that using LoadingUI in Resources/UIPrefabs/Loading/
        public const string Home = "Home/HomeUI";
    }

    public static class GameConfig
    {
    }

    public static class ResourcePaths
    {
        // ex: public static readonly string LevelDataPath = "data/levels";
    }

    public static class PlayerPrefKeys
    {
        // public const string IsEnableSound = "pf_is_enable_sound";
        // public const string IsEnableMusic = "pf_is_enable_music";
    }

    public static class AudioIds
    {
        public static class Music
        {
            // public const string Gameplay = "bg_gameplay";
        }

        public static class Sound
        {
            // public const string TouchBubble = "touch_bubble";
            
        }
    }
}