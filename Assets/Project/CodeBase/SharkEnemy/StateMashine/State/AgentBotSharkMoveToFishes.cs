using Assets.Project.CodeBase.SharkEnemy.Static;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Project.CodeBase.SharkEnemy.StateMashine.State
{
    public class AgentBotSharkMoveToFishes : AgentMoveState
    {
        private Vector3 _closestFish;
        private Transform _transform;

        public AgentBotSharkMoveToFishes(NavMeshAgent agent, SharkModel sharkModel, SharkStaticData sharkStaticData, SpawnerFish spawnerFish)
            : base(agent, sharkModel, sharkStaticData, spawnerFish)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {

        }

        public override void Update() 
        {
            if (IsChangedStateToFishes)
                MoveTo(_closestFish, _transform);      
        }

        public void Move(Vector3 closestFish, Transform transform)
        {
            _closestFish = closestFish;
            _transform = transform;
        }
    }
}
