using System.Collections.Generic;
using UnityEngine;

public class SpawnerFish : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Fish> _fishes;

    private FishFactory _fishFactory;
    private ServesSelectTypeFish _random;
    private PlayerView _playerView;
    private SpawnerFishData _spawnerFishData;

    private float _nextSpawnTime;

    public List<Fish> Fishes => _fishes;
    
    public void Construct(FishFactory fishFactory, ServesSelectTypeFish random, PlayerView playerView, ConfigFish configFish)
    {
        _fishFactory = fishFactory;
        _random = random;
        _playerView = playerView;
        _spawnerFishData = configFish.SpawnerFishData;
    }

    private void Start()
    {
        _nextSpawnTime = Time.time + _spawnerFishData.SpawnCooldown;
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime && _fishes.Count < _spawnerFishData.MaxCountFish)
        {
            _nextSpawnTime = Time.time + _spawnerFishData.SpawnCooldown;
            SpawnFishAtRandomPoint();
        }
    }
    

    private void SpawnFishAtRandomPoint()
    {
        List<SpawnPoint> availablePoints = _spawnPoints.FindAll(point => !point.IsBusy);

        if (availablePoints.Count == 0)
            return;

        SpawnPoint spawnPoint = availablePoints[UnityEngine.Random.Range(0, availablePoints.Count)];
        spawnPoint.SetBusyTrue();

        Vector3 spawnPosition = spawnPoint.transform.position;

        Fish fish = _fishFactory.GetFish(_random.SpawnFishes(), spawnPosition);
        fish.transform.SetParent(this.transform);

        AddFish(fish);

        fish.Construct(_playerView);
    }

    private void AddFish(Fish fish)
    {
        fish.FishDied += OnFishDied;
        _fishes.Add(fish);
    }

    private void OnFishDied(Fish fish)
    {
        fish.FishDied -= OnFishDied;
        _fishes.Remove(fish);
        _random.RemoveFish(fish);

        SpawnPoint spawnPoint = _spawnPoints.Find(point => point.transform.position == fish.transform.position);
        
        if (spawnPoint != null)
            spawnPoint.SetBusyFalse();
    }
}
