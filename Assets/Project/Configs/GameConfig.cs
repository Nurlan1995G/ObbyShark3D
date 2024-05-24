using Sirenix.OdinInspector;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameConfig", menuName = "GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [SerializeField] public PlayerData playerData;

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

