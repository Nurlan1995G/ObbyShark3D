using UnityEngine;

namespace Assets.Project.CodeBase.SharkEnemy
{
    public class SharkModel : Shark
    {
        [SerializeField] private TriggerSharkEnemy _triggerSharkEnemy;
        [SerializeField] private BoxCollider _boxCollider;
        private string _nickName;

        private float _centerZ = -0.35f;
        private float _sizeX = 0.8f;
        private float _sizeZ = 1.5f;

        private void Awake()
        {
            _boxCollider.center = new Vector3(0, 0, _centerZ);
            _boxCollider.size = new Vector3(_sizeX, 0.3f, _sizeZ);
        }

        public void Destroys() =>
            Destroy(gameObject);

        public void SetNickName(string name)
        {
            _nickName = name;
            NickName.NickNameText.text = _nickName;
        }

        public override string GetSharkName()
        {
            return _nickName ?? "Unknown Shark";
        }

        public override void SetBoxCollider()
        {
            _centerZ -= 0.3f;
            _sizeX += 0.5f;
            _sizeZ += 1f;

            _boxCollider.center = new Vector3(0, 0, _centerZ);
            _boxCollider.size = new Vector3(_sizeX, 0, _sizeZ);
        }
    }
}
