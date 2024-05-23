using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private CharacterController _characterController;

    private PlayerInput _input;
    private PlayerData _playerData;

    private void Awake()
    {
        _input = new PlayerInput();
        _playerData = _gameConfig.playerData;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void Update()
    {
        //Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
        //Debug.Log("Vertical: " + Input.GetAxis("Vertical"));

        Vector2 moveDirection = _input.Player.Move.ReadValue<Vector2>();
        Move(moveDirection);
    }

    private void OnDisable() =>
        _input.Disable();

    public void CharacterControlEnab()
    {
        _characterController.enabled = true;
    }

    public void CharacterControlDis()
    {
        _characterController.enabled = false;
    }

    private void Move(Vector2 direction)
    {
        Vector3 newDirection = new Vector3(direction.x, 0, direction.y);

        Quaternion cameraRotationY = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        MoveCharacter(newDirection, cameraRotationY);

        RotateCharacter(newDirection, cameraRotationY);
    }

    public void MoveCharacter(Vector3 moveDirection, Quaternion cameraRotation)
    {
        Vector3 finalDirection = (cameraRotation * moveDirection).normalized;

        _characterController.Move(_playerData.MoveSpeed * Time.deltaTime * finalDirection);
    }

    public void RotateCharacter(Vector3 moveDirection, Quaternion cameraRotation)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 finalDirection = (cameraRotation * moveDirection).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(finalDirection);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _playerData.RotateSpeed * Time.deltaTime);
        }
    }
}