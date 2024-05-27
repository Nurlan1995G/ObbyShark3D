using Assets.CodeBase.CameraLogic;
using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Fish.Factory;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private SpawnerFish _spawner;
    [SerializeField] private FishStaticData _fishStaticData;
    [SerializeField] private PositionStaticData _positionStaticData;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private List<SpawnPointEnemyBot> _spawnPoints;
    [SerializeField] private CameraRotater _cameraRotater;
    [SerializeField] private ConfigFish _configFish;

    private void Awake()
    {
        AssetProvider assetProvider = new AssetProvider();
        ServesSelectTypeFish random = new ServesSelectTypeFish(_configFish);

        _spawner.Construct(new FishFactory(_fishStaticData, assetProvider), random, _playerView, _configFish);

        FactoryShark factoryShark = new FactoryShark(assetProvider);
        
        WriteSpawnPoint(factoryShark);

        _playerView.Construct(_positionStaticData, _gameConfig);

        _cameraRotater.Construct(_gameConfig);
    }

    private void WriteSpawnPoint(FactoryShark factoryShark)
    {
        foreach (SpawnPointEnemyBot spawnPoint in _spawnPoints)
            spawnPoint.Construct(factoryShark, _positionStaticData, _playerView, _spawner, _gameConfig);
    }
}