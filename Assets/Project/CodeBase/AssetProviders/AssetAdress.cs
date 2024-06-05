using System.Collections.Generic;

namespace Assets.Project.AssetProviders
{
    public static class AssetAdress
    {
        public const string ScoreLevel = "Score/Level";
        public const string PlayerShark = "Player/Shark";
        public const string SharkEnemy1 = "SharkEnemy/SharkEnemy1";
        public const string SharkEnemy2 = "SharkEnemy/SharkEnemy2";
        public const string SharkEnemy3 = "SharkEnemy/SharkEnemy3";
        public const string SharkEnemy4 = "SharkEnemy/SharkEnemy4";

        public static readonly List<string> SharkBotsTag = new List<string> { "Shark1", "Shark2", "Shark3", "Shark4" };
        public const string PlayerTag = "Player";
    }
}