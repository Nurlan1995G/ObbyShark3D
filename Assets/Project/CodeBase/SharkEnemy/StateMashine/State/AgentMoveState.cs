using Assets.Project.CodeBase.SharkEnemy.Static;
using UnityEngine.AI;
using UnityEngine;
using Assets.Project.CodeBase.SharkEnemy.StateMashine.Interface;

namespace Assets.Project.CodeBase.SharkEnemy.StateMashine.State
{
    public class AgentMoveState : IState
    {
        protected NavMeshAgent _agent;
        protected SharkModel _sharkModel;
        private SharkStaticData _sharkStaticData;
        private readonly SpawnerFish _spawnerFish;
        private DetecterToObject _detecterToObject;
        private DetectorFish _detectorFish;

        public bool IsChangedStateToShark;
        public bool IsChangedStateToPlayer;
        public bool IsChangedStateToFishes;

        public AgentMoveState (NavMeshAgent agent, SharkModel sharkModel, SharkStaticData sharkStaticData, SpawnerFish spawnerFish)
        {
            _agent = agent;
            _sharkModel = sharkModel;
            _sharkStaticData = sharkStaticData;
            _spawnerFish = spawnerFish;

            _agent.speed = _sharkStaticData.SpeedMove;

            _detecterToObject = new DetecterToObject(this, sharkModel);
            _detectorFish = new DetectorFish(sharkModel,this);
        }

        public bool IsObjectNotReached(GameObject target, Transform transform)
        {
            if(target == null) return false;

            return Vector3.Distance(target.transform.position, transform.position) <= _sharkStaticData.MinimalDistanceToObject;
        }

        public void MoveTo(Vector3 position, Transform transform)
        {
            _agent.destination = position;
            RotateCharacter(position, transform, _sharkStaticData.RotateSpeed);
        }

        private void RotateCharacter(Vector3 targetPosition, Transform transform, float rotateSpeed)
        {
            Vector3 targetDirection = (targetPosition - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            _detectorFish.FindToFish(_spawnerFish, _sharkModel.transform, _agent);

            _detecterToObject.DetectObject(_sharkModel.transform, _sharkStaticData.MinimalDistanceToObject);
        }
    }
}
