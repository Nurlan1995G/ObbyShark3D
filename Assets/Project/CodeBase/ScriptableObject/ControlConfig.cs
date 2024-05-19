using UnityEngine;

[CreateAssetMenu(fileName = "ControlConfig")]
public class ControlConfig : ScriptableObject
{
    [field: SerializeField] public float SpeedMoving;
    [field: SerializeField] public float SpeedRotation;
}
