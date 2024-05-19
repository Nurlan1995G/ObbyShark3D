using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.CodeBase.CameraLogic
{
    public class CameraRotater : MonoBehaviour
    {
        [SerializeField] private float _speedRotate;
        [SerializeField] private float _zoomSpeed;

        [SerializeField] private PlayerView _playerView;
        [SerializeField] private float _smoothTime = 0.3f;

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

            _rotateInput.Mouse.RightButton.performed += OnTouchPerformed;
            _rotateInput.Mouse.MouseSrollWheel.performed += OnTouchMouseScrollWheel;
        }

        private void OnEnable()
        {
        }

        private void Update()
        {
            NewMethod();
        }

        private void NewMethod()
        {
            Vector3 targetDirection = _playerView.transform.forward;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _smoothTime * Time.deltaTime);
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

            float zoomAmount = scrollDelta * _zoomSpeed * Time.deltaTime;

            _cinemachine.m_Lens.OrthographicSize += zoomAmount; 

            Vector3 newPosition = transform.position + transform.forward * zoomAmount;

            transform.position = newPosition;
        }

        private void ZoomMouseScroolWheel(Vector2 scrollDelta)
        {
            float zoomAmount = scrollDelta.y * _zoomSpeed * Time.deltaTime;

            Vector3 newPosition = transform.position + transform.forward * zoomAmount;

            transform.position = newPosition;
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
