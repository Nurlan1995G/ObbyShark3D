using Assets.Project.CodeBase.SharkEnemy.StateMashine.Interface;
using Assets.Project.CodeBase.SharkEnemy.StateMashine.State;
using Assets.Project.CodeBase.SharkEnemy.Static;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AI;

namespace Assets.Project.CodeBase.SharkEnemy.StateMashine
{
    public class SharkBotStateMachine : ISwitchState
    {
        private List<IState> _states;
        private IState _currentState;

        public SharkBotStateMachine(NavMeshAgent agent, SharkModel sharkModel, SharkStaticData sharkStaticData, PlayerView playerView, SpawnerFish spawnerFish)
        {
            _states = new List<IState>
            {
                //new AgentBotSharkMoveToFishes(agent, sharkModel,sharkStaticData),
                //new AgentBotSharkMoveToPlayerState(agent, sharkModel, sharkStaticData, playerView),
                //new AgentMoveBotSharkMoveToSharkState(agent, sharkModel, sharkStaticData)
                new AgentMoveState(agent,sharkModel, sharkStaticData, spawnerFish),
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<State>() where State : IState
        {
            IState state = _states.FirstOrDefault(state => state is State);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();
    }
}
