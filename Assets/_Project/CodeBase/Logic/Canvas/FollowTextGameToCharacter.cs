
using UnityEngine;

namespace Assets._Project.CodeBase.Logic.Canvas
{
    public class FollowTextGameToCharacter : MonoBehaviour
    {
        [SerializeField] private Shark _characterObject;

        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - _characterObject.transform.position;
        }

        private void Update()
        {
            Vector3 targetPosition = _characterObject.transform.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 50f);
        }
    }
}
