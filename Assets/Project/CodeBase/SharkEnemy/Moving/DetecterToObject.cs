using Assets.Project.CodeBase.SharkEnemy.StateMashine.State;
using Assets.Project.CodeBase.SharkEnemy;
using System.Collections.Generic;
using UnityEngine;

public class DetecterToObject
{
    public const string PlayerTag = "Player";

    private readonly AgentMoveState _agentMoveState;
    private readonly SharkModel _sharkModel;

    private List<string> _sharkBotsTag = new List<string> { "Shark1", "Shark2" };

    private float _timeLastDetected;
    private float _chaseDuration = 10f;
    private float _cooldownTimer;
    private bool _isChasing = true;

    public DetecterToObject( AgentMoveState agentMoveState,  SharkModel sharkModel)
    {
        _agentMoveState = agentMoveState;
        _sharkModel = sharkModel;
    }

    public void DetectObject(Transform transform)
    {
        GameObject targetPlayer = StaticClassLogic.FindObject(PlayerTag);

        FindMissingShark(transform, targetPlayer);

        if (targetPlayer != null)
        {
            if (_agentMoveState.IsObjectNotReached(targetPlayer, transform) && targetPlayer.CompareTag(PlayerTag))
            {
                if (_isChasing)
                {
                    if (targetPlayer.GetComponent<PlayerView>().ScoreLevel > _sharkModel.ScoreLevel)
                        FleeFromObject(targetPlayer, transform);
                    else
                        PositionPlayerObject(targetPlayer, transform);
                }
            }
        }

        GetDelayTime();
    }

    private void GetDelayTime()
    {
        if (!_isChasing && _cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;

            if (_cooldownTimer < 0)
                _isChasing = true;
        }
    }

    private void FindMissingShark(Transform transform, GameObject targetPlayer)
    {
        foreach (var sharkTag in _sharkBotsTag)
        {
            GameObject targetShark = StaticClassLogic.FindObject(sharkTag);

            if(targetShark != null)
            {
                SharkModel sharkModel = targetShark.GetComponent<SharkModel>(); 
                
                if (sharkModel != _sharkModel)
                {
                    if (_agentMoveState.IsObjectNotReached(sharkModel.gameObject, transform) 
                    && !_agentMoveState.IsObjectNotReached(targetPlayer, transform))
                    {
                        if (_isChasing)
                        {
                            if (sharkModel.ScoreLevel > _sharkModel.ScoreLevel)
                                FleeFromObject(sharkModel.gameObject, transform);
                            else
                                PositionSharkObject(sharkModel.gameObject, transform);
                        }
                    }
                }
            }
        }
    }

    private void FleeFromObject(GameObject targetPlayer, Transform transform)
    {
        Vector3 fleeDirection = transform.position - targetPlayer.transform.position;
        Vector3 targetDirection = transform.position + fleeDirection;

        _agentMoveState.MoveTo(targetDirection, transform);
    }

    private void PositionSharkObject(GameObject positionShark, Transform transform)
    {
        if (_isChasing)
        {
            if (positionShark.GetComponent<SharkModel>().ScoreLevel < _sharkModel.ScoreLevel)
            {
                if (_timeLastDetected < _chaseDuration)
                {
                    _agentMoveState.MoveTo(positionShark.transform.position, transform);

                    _timeLastDetected += Time.deltaTime;
                }
                else
                    ResetTimePursuit();
            }
        }
    }

    private void PositionPlayerObject(GameObject positionTarget, Transform transform)
    {
        if (_isChasing)
        {
            if (positionTarget.GetComponent<PlayerView>().ScoreLevel < _sharkModel.ScoreLevel)
            {
                if (_timeLastDetected < _chaseDuration)
                {
                    _agentMoveState.MoveTo(positionTarget.transform.position, transform);

                    _timeLastDetected += Time.deltaTime;
                }
                else
                    ResetTimePursuit();
            }
        }
    }

    private void ResetTimePursuit()
    {
        _timeLastDetected = 0;
        _isChasing = false;
        _cooldownTimer = _chaseDuration / 2;
    }
}