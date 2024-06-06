﻿using Assets.Project.AssetProviders;
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

    public void Construct(FactoryShark factoryShark, PositionStaticData sharkPositionStaticData,
        PlayerView playerView, SpawnerFish spawnerFish, GameConfig gameConfig, TopSharksManager topSharksManager)
    { 
        _factoryShark = factoryShark;
        _sharkPositionStaticData = sharkPositionStaticData;
        _playerView = playerView;
        _spawnerFish = spawnerFish;
        _sharkBotData = gameConfig.SharkBotData;
        _topSharkManager = topSharksManager;
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
        else if (sharkTag == "Shark3")
        {
            position = _sharkPositionStaticData.InitSharkThreePosition;
            sharkEnemy = AssetAdress.SharkEnemy3;
        }
        else if (sharkTag == "Shark4")
        {
            position = _sharkPositionStaticData.InitSharkFourPosition;
            sharkEnemy = AssetAdress.SharkEnemy4;
        }
        else
            return;

        BotSharkView botShark = CreateSharkScene(position, sharkEnemy);
        botShark.Construct(_spawnerFish, _sharkBotData, _playerView, _topSharkManager);
    }

    private BotSharkView CreateSharkScene(Vector3 positionShark, string sharkEnemy)
    {
        BotSharkView botShark = _factoryShark.CreateSharkEnemy(sharkEnemy, positionShark);
        return botShark;
    }
}
