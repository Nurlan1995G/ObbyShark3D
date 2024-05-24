using UnityEngine;

public class RotateScoreToCameras : MonoBehaviour
{
    private Transform _transformCamera;
    private Transform _childTransform; // Дочерний объект, который будет позиционироваться
    private float _speedRotate = 100f;

    private void Start()
    {
        _transformCamera = Camera.main.transform;

        // Создаем дочерний объект
        GameObject childObject = new GameObject("ChildObject");
        _childTransform = childObject.transform;
        _childTransform.parent = transform; // Делаем текущий объект родительским для дочернего
    }

    private void LateUpdate()
    {
        if (_transformCamera == null)
            return;

        // Позиционируем дочерний объект рядом с камерой
        _childTransform.position = _transformCamera.position;

        // Вычисляем направление от дочернего объекта к текущему объекту
        Vector3 directionToTarget = transform.position - _childTransform.position;

        // Поворачиваем дочерний объект в направлении цели
        if (directionToTarget != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            _childTransform.rotation = Quaternion.Lerp(_childTransform.rotation, lookRotation, Time.deltaTime * _speedRotate);
        }
    }
}
