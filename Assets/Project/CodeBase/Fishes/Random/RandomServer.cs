using System.Collections.Generic;
using UnityEngine;

public class RandomServer
{
    private const int MaxCountLunaFish = 1;
    private const int MaxCountPicassoFish = 3;
    private const int MaxCountNapoleonFish = 5;
    private const int MaxCountAngelFish = 7;
    private const int maxCountHedgehogFish = 10;
    private const int MaxCountBelugaFish = 14;
    private const int MaxCountParrotFish = 17;
    private const int MaxCountClounFish = 20;
    private const int MaxCountBlueSergeonFish = 24;

    private SpawnerFish _spawner;
    
    private float _nextSpawn;
    private float _randomSpawnX;
    private float _randomSpawnZ;
    private Vector3 _whereToSpawn;
    private float _spawnCooldown;

    private int _lunaFish = 0;
    private int _napoleonFish = 0;
    private int _parrotFish = 0;
    private int _picassoFish = 0;
    private int _belugaFish = 0;
    private int _angelFish = 0;
    private int _hedgehogFish = 0;
    private int _blueSergeon = 0;
    private int _clounFish = 0;

    public Vector3 WhereToSpawn => _whereToSpawn;

    private readonly Dictionary<int, int> _fishProbabilities = new Dictionary<int, int>
    {
        { 1, 26 },
        { 2, 20 },
        { 4, 17 },
        { 8, 14 },
        { 16, 10 },
        { 32, 7 },
        { 64, 5 },
        { 128, 2 }
    };

    public RandomServer(SpawnerFish spawner)
    {
        _spawner = spawner;
    }

    public TypeFish SpawnFishes()
    {
        TypeFish typeFish;

        while (true)
        {
            if (_lunaFish < MaxCountLunaFish)
            {
                _lunaFish++;
                return typeFish = TypeFish.Luna;
            }

            if (_picassoFish < MaxCountPicassoFish)
            {
                _picassoFish++;
                return typeFish = TypeFish.Picasso;
            }

            if (_napoleonFish < MaxCountNapoleonFish)
            {
                _napoleonFish++;
                return typeFish = TypeFish.Napoleon;
            }

            if (_angelFish < MaxCountAngelFish)
            {
                _angelFish++;
                return typeFish = TypeFish.Angel;
            }

            if (_hedgehogFish < maxCountHedgehogFish)
            {
                _hedgehogFish++;
                return typeFish = TypeFish.Hedgehog;
            }

            if (_belugaFish < MaxCountBelugaFish)
            {
                _belugaFish++;
                return typeFish = TypeFish.Beluga;
            }

            if (_parrotFish < MaxCountParrotFish)
            {
                _parrotFish++;
                return typeFish = TypeFish.Parrot;
            }

            if (_clounFish < MaxCountClounFish)
            {
                _clounFish++;
                return typeFish = TypeFish.Cloun;
            }

            if (_blueSergeon < MaxCountBlueSergeonFish)
            {
                _blueSergeon++;
                return typeFish = TypeFish.BlueSergeon;
            }
        }
    }

    public void RemoveFish(Fish fish)
    {
        TypeFish fishType;

        if (fish is LunaFish)
            fishType = TypeFish.Luna;
        else if (fish is PicassoFish)
            fishType = TypeFish.Picasso;
        else if (fish is NapoleonFish)
            fishType = TypeFish.Napoleon;
        else if (fish is AngelFish)
            fishType = TypeFish.Angel;
        else if (fish is HedgehogFish)
            fishType = TypeFish.Hedgehog;
        else if (fish is BelugaFish)
            fishType = TypeFish.Beluga;
        else if (fish is ParrotFish)
            fishType = TypeFish.Parrot;
        else if (fish is ClounFish)
            fishType = TypeFish.Cloun;
        else if (fish is BlueSergeonFish)
            fishType = TypeFish.BlueSergeon;
        else
        {
            Debug.LogWarning("Неизвестный вид рыбы!");
            return;
        }

        switch (fishType)
        {
            case TypeFish.Luna:
                _lunaFish--;
                break;
            case TypeFish.Picasso:
                _picassoFish--;
                break;
            case TypeFish.Napoleon:
                _napoleonFish--;
                break;
            case TypeFish.Angel:
                _angelFish--;
                break;
            case TypeFish.Hedgehog:
                _hedgehogFish--;
                break;
            case TypeFish.Beluga:
                _belugaFish--;
                break;
            case TypeFish.Parrot:
                _parrotFish--;
                break;
            case TypeFish.Cloun:
                _clounFish--;
                break;
            case TypeFish.BlueSergeon:
                _blueSergeon--;
                break;
        }

    }

    public int GetScoreToFish()
    {
        int randomValue = UnityEngine.Random.Range(1, 129); 

        int cumulativeProbability = 0;

        foreach (var fishProbab in _fishProbabilities)
        {
            cumulativeProbability += fishProbab.Value;

            if (randomValue <= cumulativeProbability)
            {
                return fishProbab.Key; 
            }
        }

        return 1;
    }

    public void GetRandomPositionFish()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnCooldown;

            _randomSpawnX = UnityEngine.Random.Range(-40, 40);
            _randomSpawnZ = UnityEngine.Random.Range(-40, 40);

            _whereToSpawn = new Vector3(_randomSpawnX, 0.2f, _randomSpawnZ);
        }
    }

    public Vector3 GetRandomPosition()
    {
        _randomSpawnX = UnityEngine.Random.Range(-40, 40);
        _randomSpawnZ = UnityEngine.Random.Range(-40, 40);

        return _whereToSpawn = new Vector3(_randomSpawnX, 0.2f, _randomSpawnZ);
    }
}
