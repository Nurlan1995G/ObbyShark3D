using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameConfig", menuName = "GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    public PlayerData PlayerData;
    public SharkBotData SharkBotData;

    //[FoldoutGroup("Player")] public float MoveSpeed;
    //[FoldoutGroup("Player")] public float RotateSpeed;
}

[Serializable]
public class PlayerData
{
    public float MoveSpeed;
    public float RotateSpeed;
    public float Gravity;
}

[Serializable]
public class SharkBotData
{
    public float MoveSpeed;
    public float RotateSpeed;
    public float MinimalDistanceToObject;
}

