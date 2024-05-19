using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Fish.Factory;
using Assets.Project.CodeBase.Logic.Respawn;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using Assets.Project.CodeBase.SharkEnemy.Static;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private SpawnerFish _spawner;
    [SerializeField] private FishStaticData _fishStaticData;
    [SerializeField] private PositionStaticData _positionStaticData;
    [SerializeField] private SharkStaticData _sharkStaticData;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private RespawnObject _respawnObject;
    [SerializeField] private SpawnPointEnemyBot _spawnPointEnemys;
    [SerializeField] private SpawnPointEnemyBot _spawnPointEnemy;

    private void Awake() 
    {
        AssetProvider assetProvider = new AssetProvider();
        RandomServer random = new RandomServer(_spawner);

        _spawner.Construct(new FishFactory(_fishStaticData, assetProvider), random);

        FactoryShark factoryShark = new FactoryShark(assetProvider);

        _spawnPointEnemy.Construct(factoryShark, _positionStaticData, _playerView, _spawner, _sharkStaticData);
        _spawnPointEnemys.Construct(factoryShark, _positionStaticData, _playerView, _spawner, _sharkStaticData);

        _playerView.Construct(_positionStaticData);
    }
}