using UnityEngine;

public class FollowTextToCharacter : MonoBehaviour
{
    [SerializeField] private Shark _characterShark;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _characterShark.transform.position;
    }

    private void Update()
    {
        Vector3 targetPosition = _characterShark.transform.position + _offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 50f);
    }
}
