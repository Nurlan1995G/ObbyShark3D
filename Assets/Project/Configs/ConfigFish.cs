using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Fish", menuName = "ConfigFish")]
public class ConfigFish : ScriptableObject
{
    public FishCountData FishCountData;
    public SpawnerFishData SpawnerFishData;
}

[Serializable]
public class SpawnerFishData
{
    public float SpawnCooldown = 0.1f;
    public int MaxCountFish = 150;
}

[Serializable]
public class FishCountData
{
    public int MaxCountLunaFish = 2;
    public int MaxCountPicassoFish = 5;
    public int MaxCountNapoleonFish = 8;
    public int MaxCountAngelFish = 12;
    public int MaxCountHedgehogFish = 15;
    public int MaxCountBelugaFish = 20;
    public int MaxCountParrotFish = 24;
    public int MaxCountClounFish = 30;
    public int MaxCountBlueSergeonFish = 34;
}
