using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.CodeBase.CameraLogic
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private float _speedRotate = 5f;
        [SerializeField] private float _zoomSpeed = 2f;
        [SerializeField] private float _smoothTime = 0.3f;
        [SerializeField] private float _fixedYPosition = 10f;
        [SerializeField] private float _rotationDelay = 1f; 

        private RotateInput _rotateInput;
        private Vector2 _lastDirection;

        private float _currentXRotation;
        private float _currentYRotation;

        private Transform _playerTransform;
        private Coroutine _rotateCoroutine;
        private bool _isManualRotation;

        private void Awake()
        {
            _rotateInput = new RotateInput();
            _rotateInput.Enable();

            _playerTransform = GameObject.FindWithTag("Player").transform;

            _rotateInput.Mouse.RightButton.performed += OnTouchPerformed;
            _rotateInput.Mouse.RightButton.canceled += OnTouchCanceled;
        }

        private void OnDisable()
        {
            _rotateInput.Disable();

            _rotateInput.Mouse.RightButton.performed -= OnTouchPerformed;
            _rotateInput.Mouse.RightButton.canceled -= OnTouchCanceled;
        }

        private void Update()
        {
            if (_rotateCoroutine == null && !_isManualRotation)
            {
                _rotateCoroutine = StartCoroutine(RotateToPlayerAfterDelay());
            }

            Vector3 fixedPosition = transform.position;
            fixedPosition.y = _fixedYPosition;
            transform.position = fixedPosition;
        }

        private IEnumerator RotateToPlayerAfterDelay()
        {
            yield return new WaitForSeconds(_rotationDelay);

            while (!_isManualRotation)
            {
                Vector3 targetDirection = _playerTransform.forward;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, targetRotation, _smoothTime * Time.deltaTime);

                Vector3 smoothedEulerAngles = smoothedRotation.eulerAngles;
                smoothedEulerAngles.x = transform.rotation.eulerAngles.x;
                smoothedEulerAngles.z = transform.rotation.eulerAngles.z;

                transform.rotation = Quaternion.Euler(smoothedEulerAngles);

                yield return null;
            }

            _rotateCoroutine = null;
        }

        public void OnTouchPerformed(InputAction.CallbackContext context)
        {
            _isManualRotation = true;
            Rotate(context.ReadValue<Vector2>());
        }

        public void OnTouchCanceled(InputAction.CallbackContext context)
        {
            _isManualRotation = false;
            _rotateCoroutine = StartCoroutine(RotateToPlayerAfterDelay());
        }

        private void Rotate(Vector2 direction)
        {
            if (_lastDirection != direction)
            {
                _currentXRotation += direction.x * _speedRotate * Time.deltaTime;
                _currentYRotation += -direction.y * _speedRotate * Time.deltaTime;

                _currentYRotation = Mathf.Clamp(_currentYRotation, -45f, 90f);

                Quaternion rotationX = Quaternion.Euler(0, _currentXRotation, 0);
                Quaternion rotationY = Quaternion.Euler(_currentYRotation, 0, 0);

                Quaternion targetRotation = rotationX * rotationY;
                Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, targetRotation, _smoothTime * Time.deltaTime);

                Vector3 smoothedEulerAngles = smoothedRotation.eulerAngles;
                smoothedEulerAngles.x = transform.rotation.eulerAngles.x;
                smoothedEulerAngles.z = transform.rotation.eulerAngles.z;

                transform.rotation = Quaternion.Euler(smoothedEulerAngles);
                _lastDirection = direction;
            }
        }
    }
}
