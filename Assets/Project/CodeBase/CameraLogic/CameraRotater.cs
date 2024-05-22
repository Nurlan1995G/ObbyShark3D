using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.CodeBase.CameraLogic
{
    public class CameraRotater : MonoBehaviour
    {
        [SerializeField] private float _speedRotate;
        [SerializeField] private float _zoomSpeed;

        [SerializeField] private float _minZoomDistance = 5;
        [SerializeField] private float _maxZoomDistance = 20;

        [SerializeField] private VariableJoystick _variableJoystick;
        [SerializeField] private float _zoomStep = 0.1f;

        private RotateInput _rotateInput;
        private Vector2 _lastDirection;

        private float _currentXRotation;
        private float _currentYRotation;

        private CinemachineVirtualCamera _cinemachine;

        private void Awake()
        {
            _rotateInput = new RotateInput();
            _rotateInput.Enable();

            _cinemachine = GetComponent<CinemachineVirtualCamera>();
        }

        private void OnEnable()
        {
            _rotateInput.Mouse.RightButton.performed += OnTouchPerformed;
            _rotateInput.Mouse.MouseSrollWheel.performed += OnTouchMouseScrollWheel;
        }

        private void Update()
        {
            Vector2 jostickDirection = _variableJoystick.JostickDirection;

            if (jostickDirection != Vector2.zero)
                Rotate(jostickDirection);
        }

        private void OnDisable()
        {
            _rotateInput.Disable();

            _rotateInput.Mouse.RightButton.performed -= OnTouchPerformed;
            _rotateInput.Mouse.MouseSrollWheel.performed -= OnTouchMouseScrollWheel;
        }

        private void OnTouchMouseScrollWheel(InputAction.CallbackContext context)
        {
            float scrollDelta = context.ReadValue<float>();

            var framingTransposer = _cinemachine.GetCinemachineComponent<CinemachineFramingTransposer>();

            if (framingTransposer != null)
            {
                float targetDistance = framingTransposer.m_CameraDistance - scrollDelta * _zoomStep;
                targetDistance = Mathf.Clamp(targetDistance, _minZoomDistance, _maxZoomDistance);
                framingTransposer.m_CameraDistance = Mathf.Lerp(framingTransposer.m_CameraDistance, targetDistance, _zoomSpeed * Time.deltaTime);
            }
        }

        public void OnTouchPerformed(InputAction.CallbackContext context)
        {
            Rotate(context.ReadValue<Vector2>());
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

                transform.rotation = rotationX * rotationY;
                _lastDirection = direction;
            }
        }
    }
}
