using System.Collections.Generic;
using UnityEngine;

public class SpawnerFish : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown = 0.1f;
    [SerializeField] private int _maxCountFish = 100;

    private FishFactory _fishFactory;
    private RandomServer _random;

    private PlayerView _playerView;

    private float _nextSpawnTime;
    [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
    [SerializeField] private List<Fish> _fishes = new List<Fish>();

    public List<Fish> Fishes => _fishes;
    
    private void Awake()
    {
        _nextSpawnTime = Time.time + _spawnCooldown;
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime && _fishes.Count < _maxCountFish)
        {
            _nextSpawnTime = Time.time + _spawnCooldown;
            SpawnFishAtRandomPoint();
        }
    }
    
    public void Construct(FishFactory fishFactory, RandomServer random, PlayerView playerView)
    {
        _fishFactory = fishFactory;
        _random = random;
        _playerView = playerView;
    }

    private void SpawnFishAtRandomPoint()
    {
        List<SpawnPoint> availablePoints = _spawnPoints.FindAll(point => !point.IsBusy);

        if (availablePoints.Count == 0)
        {
            Debug.LogWarning("No available spawn points");
            return;
        }

        SpawnPoint spawnPoint = availablePoints[UnityEngine.Random.Range(0, availablePoints.Count)];

        spawnPoint.IsBusy = true;

        Vector3 spawnPosition = spawnPoint.transform.position;

        Fish fish = _fishFactory.GetFish(_random.SpawnFishes(), spawnPosition);

        fish.Construct(_playerView);
        fish.transform.SetParent(this.transform);

        AddFish(fish);
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
        {
            spawnPoint.IsBusy = false;
        }
    }
}
