using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private ScoreLevelBar _scoreLevelBar;
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private float _localScaleX = 0.2f;
    [SerializeField] private PlayerControllerMover _mover;

    private int _score = 1;

    public int ScoreLevel => _score;

    private int _parametrRaising = 10;
    public Action<PlayerView> PlayerDied;
    private PositionStaticData _positionStaticData;

    private int _scoreCount;

    private void Update()
    {
        IncreasePlayer();
    }

    private void IncreasePlayer()
    {
        int increase = _score;

        _scoreCount = increase / _parametrRaising;

        if (_scoreCount >= 2)
        {
            transform.localScale += new Vector3(_localScaleX, _localScaleX, _localScaleX);
            _parametrRaising *= 3;
        }
    }

    public void Construct(PositionStaticData positionStaticData)
    {
        _positionStaticData = positionStaticData ?? throw new ArgumentNullException(nameof(positionStaticData));
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreLevelBar.SetScore(_score);
    }

    public void Destroys()
    {
        PlayerDied?.Invoke(this);
        gameObject.SetActive(false);
        Teleport();
    }

    private void Teleport()
    {
        _mover.CharacterControlDis();
        transform.position = _positionStaticData.InitPlayerPosition;
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        _score = 1;
        _scoreLevelBar.SetScore(_score);
        _scoreCount = 0;
        _parametrRaising = 10;
        gameObject.SetActive(true);
        _mover.CharacterControlEnab();
    }
}