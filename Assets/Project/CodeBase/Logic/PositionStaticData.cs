using UnityEngine;

[CreateAssetMenu(fileName = "PositionLevel")]
public class PositionStaticData : ScriptableObject
{
    [Header("Sharks position")]
    [field: SerializeField] public Vector3 InitSharkOnePosition;
    [field: SerializeField] public Vector3 InitSharkTwoPosition;
    [Header("Player position")]
    [field: SerializeField] public Vector3 InitPlayerPosition;
}
