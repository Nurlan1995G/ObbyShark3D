using Assets.Project.CodeBase.SharkEnemy;
using Assets.Project.CodeBase.SharkEnemy.Static;
using UnityEngine;
using UnityEngine.AI;

public class AgentBotSharkMoveToPlayer : MonoBehaviour
{
    private NavMeshAgent _agent;
    private SharkModel _sharkModel;
    private SharkStaticData _sharkStaticData;
    private PlayerView _player;

    private float _chaseDuration = 10f; // Продолжительность преследования в секундах
    private float _timeLastDetected; // Время последнего обнаружения игрока

    private bool _isAllAdded = false;

    public void Construct(PlayerView player, NavMeshAgent agent, SharkModel sharkModel, SharkStaticData sharkStaticData)
    {
        _player = player;
        _agent = agent;
        _sharkModel = sharkModel;
        _sharkStaticData = sharkStaticData;

        _isAllAdded = true;
    }

    private void Update()
    {
        if(_isAllAdded)
            FindLogic();
    }

    private void FindLogic()
    {
        if (IsHeroNotReached() && _player.ScoreLevel < _sharkModel.ScoreLevel)
        {
            Debug.Log("Акуле боту интересен игрок");

            if (_timeLastDetected <= _chaseDuration)
            {
                Debug.Log("Акуле боту начинает преследование игрока");
                Debug.Log(_timeLastDetected += Time.time);

                _agent.destination = _player.transform.position;
                _timeLastDetected += Time.time;
            }
            else
            {   
                _timeLastDetected = 0;
                Debug.Log("произошло обнуление");
            }
        }
    }

    private bool IsHeroNotReached() =>
        Vector3.Distance(_agent.transform.position, _player.transform.position) <= _sharkStaticData.MinimalDistanceToObject;
}

public static class DataExtension
{
    public static float SqrMagnitudeTo(this Vector3 from, Vector3 to) =>
            Vector3.SqrMagnitude(to - from);
}
