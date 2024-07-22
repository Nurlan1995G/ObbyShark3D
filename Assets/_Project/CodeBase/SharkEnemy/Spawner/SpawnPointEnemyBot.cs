using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using UnityEngine;

public class SpawnPointEnemyBot : MonoBehaviour
{
    private FactoryShark _factoryShark;
    private PositionStaticData _sharkPositionStaticData;
    private PlayerView _playerView;
    private SpawnerFish _spawnerFish;
    private SharkBotData _sharkBotData;
    private TopSharksManager _topSharkManager;
    private Language _language;

    public void Construct(FactoryShark factoryShark, PositionStaticData sharkPositionStaticData,
        PlayerView playerView, SpawnerFish spawnerFish, GameConfig gameConfig, TopSharksManager topSharksManager, Language language)
    {
        _factoryShark = factoryShark;
        _sharkPositionStaticData = sharkPositionStaticData;
        _playerView = playerView;
        _spawnerFish = spawnerFish;
        _sharkBotData = gameConfig.SharkBotData;
        _topSharkManager = topSharksManager;
        _language = language;
    }

    private void Update()
    {
        FindMissingSharks();
    }

    private void FindMissingSharks()
    {
        foreach (var sharkTag in AssetAdress.SharkBotsTag)
        {
            GameObject shark = StaticClassLogic.FindObject(sharkTag);

            if (shark == null)
                RespawnBotShark(sharkTag);
        }
    }

    private void RespawnBotShark(string sharkTag)
    {
        Vector3 position;
        string sharkEnemy;
        string nickName;

        if (sharkTag == "Shark1")
        {
            position = _sharkPositionStaticData.InitSharkOnePosition;
            sharkEnemy = AssetAdress.SharkEnemy1;
            nickName = GetNickname(1);
        }
        else if (sharkTag == "Shark2")
        {
            position = _sharkPositionStaticData.InitSharkTwoPosition;
            sharkEnemy = AssetAdress.SharkEnemy2;
            nickName = GetNickname(2);
        }
        else if (sharkTag == "Shark3")
        {
            position = _sharkPositionStaticData.InitSharkThreePosition;
            sharkEnemy = AssetAdress.SharkEnemy3;
            nickName = GetNickname(3);
        }
        else if (sharkTag == "Shark4")
        {
            position = _sharkPositionStaticData.InitSharkFourPosition;
            sharkEnemy = AssetAdress.SharkEnemy4;
            nickName = GetNickname(4);
        }
        else if (sharkTag == "Shark5")
        {
            position = _sharkPositionStaticData.InitSharkFivePosition;
            sharkEnemy = AssetAdress.SharkEnemy5;
            nickName = GetNickname(5);
        }
        else if (sharkTag == "Shark6")
        {
            position = _sharkPositionStaticData.InitSharkSixPosition;
            sharkEnemy = AssetAdress.SharkEnemy6;
            nickName = GetNickname(6);
        }
        else if (sharkTag == "Shark7")
        {
            position = _sharkPositionStaticData.InitSharkSevenPosition;
            sharkEnemy = AssetAdress.SharkEnemy7;
            nickName = GetNickname(7);
        }
        else
            return;

        BotSharkView botShark = CreateSharkScene(position, sharkEnemy);
        botShark.Construct(_spawnerFish, _sharkBotData, _playerView, _topSharkManager);
        botShark.SetNickname(nickName);
    }

    private string GetNickname(int index)
    {
        if (_language == Language.Russian)
        {
            return index switch
            {
                1 => AssetAdress.NickBotRu1,
                2 => AssetAdress.NickBotRu2,
                3 => AssetAdress.NickBotRu3,
                4 => AssetAdress.NickBotRu4,
                5 => AssetAdress.NickBotRu5,
                6 => AssetAdress.NickBotRu6,
                7 => AssetAdress.NickBotRu7,
                _ => "Unknown"
            };
        }
        else
        {
            return index switch
            {
                1 => AssetAdress.NickBotEn1,
                2 => AssetAdress.NickBotEn2,
                3 => AssetAdress.NickBotEn3,
                4 => AssetAdress.NickBotEn4,
                5 => AssetAdress.NickBotEn5,
                6 => AssetAdress.NickBotEn6,
                7 => AssetAdress.NickBotEn7,
                _ => "Unknown"
            };
        }
    }

    private BotSharkView CreateSharkScene(Vector3 positionShark, string sharkEnemy)
    {
        BotSharkView botShark = _factoryShark.CreateSharkEnemy(sharkEnemy, positionShark);
        return botShark;
    }
}
