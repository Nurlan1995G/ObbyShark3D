using Assets.Project.CodeBase.Player.Respawn;
using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private ScoreLevelBar _scoreLevelBar;
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private float _localScaleX = 0.2f;

    private UIPopup _uiPopup;

    private RespawnPlayer _respawn;
    private PositionStaticData _positionStaticData;

    private int _parametrRaising = 10;
    private int _score = 1;
    private int _scoreCount;

    public int ScoreLevel => _score;
   
    public Action<PlayerView> PlayerDied;

    private void Start() =>
        _respawn = new RespawnPlayer();

    private void Update() =>
        IncreasePlayer();

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

    public void Construct(PositionStaticData positionStaticData,GameConfig gameConfig, UIPopup uiPopup
        , BoostButtonUI boostButtonUI)
    {
        _positionStaticData = positionStaticData ?? throw new ArgumentNullException(nameof(positionStaticData));
        _uiPopup = uiPopup;
        _mover.Construct(gameConfig.PlayerData, boostButtonUI);
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreLevelBar.SetScore(_score);
    }

    public void Destroys(SharkModel killerShark = null)
    {
        PlayerDied?.Invoke(this);
        gameObject.SetActive(false);

        if (killerShark != null)
            _respawn.SetKillerShark(killerShark,this,_uiPopup);

        _respawn.SelectAction();
    }

    public void Destroyss()
    {
        PlayerDied?.Invoke(this);
        gameObject.SetActive(false);
        _respawn.SelectAction();
        Teleport();
    }

    public void Teleport()
    {
        _mover.AgentDisable();
        transform.position = _positionStaticData.InitPlayerPosition;
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        _score = 1;
        _scoreLevelBar.SetScore(_score);
        _scoreCount = 0;
        _parametrRaising = 10;
        gameObject.SetActive(true);
        _mover.AgentEnable();
    }
}