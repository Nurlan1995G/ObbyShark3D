using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private PlayerInput _input;
    private PlayerData _playerData;

    private void Awake() =>
        _input = new PlayerInput();

    private void OnEnable() => 
        _input.Enable();

    private void Update()
    {
        Vector2 moveDirection = _input.Player.Move.ReadValue<Vector2>();
        MoveAgent(moveDirection);
    }

    private void OnDisable() =>
        _input.Disable();

    public void Construct(PlayerData playerData) =>
        _playerData = playerData;

    public void AgentEnable() =>
        _agent.enabled = true;

    public void AgentDisable() =>
        _agent.enabled = false;

    private void Move(Vector2 direction)
    {
        Vector3 newDirection = new Vector3(direction.x, 0, direction.y);

        Quaternion cameraRotationY = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        MoveCharacter(newDirection, cameraRotationY);

        RotateCharacter(newDirection, cameraRotationY);
    }

    private void MoveAgent(Vector2 direction)
    {
        Vector3 newDirection = new Vector3(direction.x, 0, direction.y);
        Quaternion cameraRotationY = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        MoveCharacter(newDirection, cameraRotationY);
        RotateCharacter(newDirection, cameraRotationY);
    }

    private void MoveCharacter(Vector3 moveDirection, Quaternion cameraRotation)
    {
        Vector3 finalDirection = (cameraRotation * moveDirection).normalized;

        _agent.Move(finalDirection * _playerData.MoveSpeed * Time.deltaTime);

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
