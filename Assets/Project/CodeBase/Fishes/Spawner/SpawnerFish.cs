using System.Collections.Generic;
using UnityEngine;

public class SpawnerFish : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown = 0.1f;
    [SerializeField] private int _maxCountFish = 100;

    private FishFactory _fishFactory;
    private RandomServer _random;

    private float _nextSpawnTime;
    [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
    [SerializeField] private List<Fish> _fishes = new List<Fish>();

    public int MaxCountFish => _maxCountFish;
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
    
    public void Construct(FishFactory fishFactory, RandomServer random)
    {
        _fishFactory = fishFactory;
        _random = random;
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
        Vector3 spawnPosition = spawnPoint.transform.position;

        Fish fish = _fishFactory.GetFish(_random.SpawnFishes(), spawnPosition);
        fish.transform.SetParent(this.transform);

        AddFish(fish);
    }

    private void StartSpawn()
    {
        while (_fishes.Count < _maxCountFish)
        {
            Fish fish = SpawnFishes();
            //AddFish(fish);
        }
    }

    private Fish SpawnFishes()
    {
        Fish fish = _fishFactory.GetFish(_random.SpawnFishes(), _random.GetRandomPosition());
        fish.transform.SetParent(this.transform);
        return fish;
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
