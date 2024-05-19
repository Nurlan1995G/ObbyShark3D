using Assets.Project.CodeBase.SharkEnemy.Static;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Project.CodeBase.SharkEnemy.StateMashine.State
{
    public class AgentBotSharkMoveToPlayerState : AgentMoveState
    {
        private float _chaseDuration = 10f; // Продолжительность преследования в секундах
        private float _timeLastDetected; // Время последнего обнаружения игрока
        private PlayerView _player;
        private Vector3 _position;
        private Transform _transform;

        public AgentBotSharkMoveToPlayerState(NavMeshAgent agent, SharkModel sharkModel, SharkStaticData sharkStaticData, PlayerView player, SpawnerFish spawnerFish) : base(agent, sharkModel, sharkStaticData, spawnerFish)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void Update()
        {
            if (IsChangedStateToPlayer)
                MoveTo(_position, _transform);
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Move(Vector3 positionPlayer, Transform transform)
        {
            _position = positionPlayer;
            _transform = transform;
        }

        private void FindLogic()
        {
            //GameObject targetObject = DetectTarget("Player");

            //PositionObject(targetObject);

            //PositionSharkBot();
        }

        private void PositionObject(GameObject targetObject)
        {
            if (targetObject != null)
            {
                Debug.Log("Акуле боту обнаружен объект: " + targetObject.name);

                // Проверяем, является ли обнаруженный объект игроком или акулой
                if ((targetObject.CompareTag("Player") && _player.ScoreLevel < _sharkModel.ScoreLevel))
                {
                    if (_timeLastDetected <= _chaseDuration)
                    {
                        Debug.Log("Акуле боту начинает преследование объекта: " + targetObject.name);
                        MoveTo(targetObject.transform.position, _sharkModel.transform);
                        _timeLastDetected += Time.deltaTime;
                    }
                    else
                    {
                        _timeLastDetected = 0;
                        Debug.Log("Произошло обнуление");
                    }
                }
            }
        }

       /* private void PositionSharkBot()
        {
            if (IsObjectNotReached(SharkModel.transform) && SharkModel.ScoreLevel < SharkModel.ScoreLevel)
            {
                Debug.Log("Акуле боту интересен другая акула");

                if (_timeLastDetected <= _chaseDuration)
                {
                    Debug.Log("Акуле боту начинает преследование другой акулы");
                    Debug.Log(_timeLastDetected += Time.time);

                    MoveTo(SharkModel.transform.position, SharkModel.transform);
                    _timeLastDetected += Time.time;
                }
                else
                {
                    _timeLastDetected = 0;
                    Debug.Log("произошло обнуление");
                }
            }
        }*/
    }
}
