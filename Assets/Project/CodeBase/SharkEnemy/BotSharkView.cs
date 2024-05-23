using Assets.Project.CodeBase.SharkEnemy;
using Assets.Project.CodeBase.SharkEnemy.StateMashine;
using Assets.Project.CodeBase.SharkEnemy.Static;
using UnityEngine;
using UnityEngine.AI;

public class BotSharkView : MonoBehaviour   
{   
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private SharkModel _sharkModel;
        
    private SpawnerFish _spawner;
    private SharkStaticData _sharkStaticData;
    private PlayerView _player;
    private SharkBotStateMachine _stateMashine;

    [field: SerializeField] public BotSharkNickName NickName { get; private set; }

    private void Start() =>
        _stateMashine = new SharkBotStateMachine(_agent, _sharkModel, _sharkStaticData, _player, _spawner);

    private void Update() =>
        _stateMashine?.Update();

    public void Construct(SpawnerFish spawner, SharkStaticData sharkStaticData, PlayerView player)
    {
        _spawner = spawner;
        _sharkStaticData = sharkStaticData;
        _player = player;
    }
}
