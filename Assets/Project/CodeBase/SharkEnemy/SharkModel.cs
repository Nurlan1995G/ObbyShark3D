using UnityEngine;

namespace Assets.Project.CodeBase.SharkEnemy
{
    public class SharkModel : Shark
    {
        [SerializeField] private TriggerSharkEnemy _triggerSharkEnemy;

        public void Destroys() =>
            Destroy(gameObject);
    }
}
