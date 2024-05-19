using UnityEngine;

namespace Assets.Project.CodeBase.SharkEnemy.Static
{
    [CreateAssetMenu(fileName = "SharkStaticData")]
    public class SharkStaticData : ScriptableObject
    {
        [field: SerializeField] public float SpeedMove;
        [field: SerializeField] public float RotateSpeed;
        [field: SerializeField] public float MinimalDistanceToObject;
    }
}
