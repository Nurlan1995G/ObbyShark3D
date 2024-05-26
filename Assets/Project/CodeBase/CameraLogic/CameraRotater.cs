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

        [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;

        private Vector3 _currentMousePosition;

        private void Awake()
        {
            _rotateInput = new RotateInput();
            _rotateInput.Enable();
        }

        private void OnEnable()
        {
            _rotateInput.Mouse.RightButton.performed += OnTouchPerformed;
            _rotateInput.Mouse.MouseSrollWheel.performed += OnTouchMouseScrollWheel;
        }

        private void Update()
        {
            if(Application.isMobilePlatform)
                HandleTouchInput();
            else
                ControlRotation();
        }

        private void OnDisable()
        {
            _rotateInput.Disable();

            _rotateInput.Mouse.RightButton.performed -= OnTouchPerformed;
            _rotateInput.Mouse.MouseSrollWheel.performed -= OnTouchMouseScrollWheel;
        }

        private void ControlRotation()
        {
            if (_variableJoystick.enabled && _currentMousePosition != Input.mousePosition)
            {

                _cinemachineFreeLook.m_XAxis.m_InputAxisValue = _variableJoystick.Horizontal;
                _cinemachineFreeLook.m_YAxis.m_InputAxisValue = _variableJoystick.Vertical;
            }
            else
            {
                _cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0;
                _cinemachineFreeLook.m_YAxis.m_InputAxisValue = 0;
            }

            _currentMousePosition = Input.mousePosition;
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (_variableJoystick.enabled)
                {
                    Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                    Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

                    float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
                    float touchDeltaMag = (touch1.position - touch2.position).magnitude;

                    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                    OnTouchZoom(deltaMagnitudeDiff);
                }
            }
        }

        private void OnTouchMouseScrollWheel(InputAction.CallbackContext context)
        {
            float scrollDelta = context.ReadValue<float>();

            OnTouchZoom(scrollDelta);
        }

        private void OnTouchZoom(float deltaMagnitudeDiff)
        {
            for (int i = 0; i < _cinemachineFreeLook.m_Orbits.Length; i++)
            {
                var orbit = _cinemachineFreeLook.m_Orbits[i];
                orbit.m_Radius = Mathf.Clamp(orbit.m_Radius - deltaMagnitudeDiff * _zoomStep, _minZoomDistance, _maxZoomDistance);
                orbit.m_Height = Mathf.Clamp(orbit.m_Height - deltaMagnitudeDiff * _zoomStep, _minZoomDistance / 2, _maxZoomDistance / 2);
                _cinemachineFreeLook.m_Orbits[i] = orbit;
            }
        }

        /*private void OnTouchMouseScrollWheel(InputAction.CallbackContext context)
        {
            if (Application.isMobilePlatform)
            {
                Debug.Log("Mobile");
            }
            else
            {
                Debug.Log("Computer");
            }

            float scrollDelta = context.ReadValue<float>();

            for (int i = 0; i < _cinemachineFreeLook.m_Orbits.Length; i++)
            {
                var orbit = _cinemachineFreeLook.m_Orbits[i];
                orbit.m_Radius = Mathf.Clamp(orbit.m_Radius - scrollDelta * _zoomStep, _minZoomDistance, _maxZoomDistance);
                orbit.m_Height = Mathf.Clamp(orbit.m_Height - scrollDelta * _zoomStep, _minZoomDistance / 2, _maxZoomDistance / 2);
                _cinemachineFreeLook.m_Orbits[i] = orbit;
            }
        }*/

        public void OnTouchPerformed(InputAction.CallbackContext context) =>
            Rotate(context.ReadValue<Vector2>());

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
