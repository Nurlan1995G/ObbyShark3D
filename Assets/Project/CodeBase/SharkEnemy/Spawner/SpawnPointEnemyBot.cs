using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointEnemyBot : MonoBehaviour
{
    private FactoryShark _factoryShark;
    private PositionStaticData _sharkPositionStaticData;
    private PlayerView _playerView;
    private SpawnerFish _spawnerFish;
    private SharkBotData _sharkBotData;

    private List<string> _sharkTags = new List<string>()
    {
        "Shark1",
        "Shark2",
    };

    public void Construct(FactoryShark factoryShark, PositionStaticData sharkPositionStaticData,
        PlayerView playerView, SpawnerFish spawnerFish, GameConfig gameConfig)
    { 
        _factoryShark = factoryShark;
        _sharkPositionStaticData = sharkPositionStaticData;
        _playerView = playerView;
        _spawnerFish = spawnerFish;
        _sharkBotData = gameConfig.SharkBotData;
    }

    private void Update()
    {
        FindMissingSharks();
    }

    private void FindMissingSharks()
    {
        foreach (var sharkTag in _sharkTags)
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

        if (sharkTag == "Shark1")
        {
            position = _sharkPositionStaticData.InitSharkOnePosition;
            sharkEnemy = AssetAdress.SharkEnemy1;
        }
        else if (sharkTag == "Shark2")
        {
            position = _sharkPositionStaticData.InitSharkTwoPosition;
            sharkEnemy = AssetAdress.SharkEnemy2;
        }
        else
            return;

        BotSharkView botShark = CreateSharkScene(position, sharkEnemy);
        botShark.Construct(_spawnerFish, _sharkBotData, _playerView);
    }

    private BotSharkView CreateSharkScene(Vector3 positionShark, string sharkEnemy)
    {
        BotSharkView botShark = _factoryShark.CreateSharkEnemy(sharkEnemy, positionShark);
        return botShark;
    }
}
