using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Fish.Factory;
using Assets.Project.CodeBase.Logic.Respawn;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using Assets.Project.CodeBase.SharkEnemy.Static;
using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private SpawnerFish _spawner;
    [SerializeField] private FishStaticData _fishStaticData;
    [SerializeField] private PositionStaticData _positionStaticData;
    [SerializeField] private SharkStaticData _sharkStaticData;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private List<SpawnPointEnemyBot> _spawnPoints;

    private void Awake()
    {
        Debug.Log("Hey, yofv");

        AssetProvider assetProvider = new AssetProvider();
        RandomServer random = new RandomServer(_spawner);

        _spawner.Construct(new FishFactory(_fishStaticData, assetProvider), random);

        FactoryShark factoryShark = new FactoryShark(assetProvider);
        
        WriteSpawnPoint(factoryShark);

        _playerView.Construct(_positionStaticData);
    }

    private void WriteSpawnPoint(FactoryShark factoryShark)
    {
        foreach (SpawnPointEnemyBot spawnPoint in _spawnPoints)
            spawnPoint.Construct(factoryShark, _positionStaticData, _playerView, _spawner, _sharkStaticData);
    }
}