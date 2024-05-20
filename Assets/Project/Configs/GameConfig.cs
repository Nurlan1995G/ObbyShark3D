using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameConfig", menuName = "GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [FoldoutGroup("Player")] public float MoveSpeed;
    [FoldoutGroup("Player")] public float RotateSpeed;
}