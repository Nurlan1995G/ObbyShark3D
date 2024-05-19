using UnityEngine;
using UnityEngine.AI;

public class BotSharkMover
{
    private NavMeshAgent _agent;
    private Transform _transform;

    public BotSharkMover(NavMeshAgent meshAgent, Transform transform)
    {
       _agent = meshAgent;
       _transform = transform;
    }

    public void MoveTo(Vector3 position, Transform transform, float _rotateSpeed)
    {
        _agent.destination = position;
        RotateCharacter(position, transform, _rotateSpeed);
    }

    private void RotateCharacter(Vector3 targetPosition, Transform transform, float rotateSpeed)
    {
        Vector3 targetDirection = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
