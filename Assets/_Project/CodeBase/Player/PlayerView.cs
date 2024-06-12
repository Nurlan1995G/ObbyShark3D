using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Player.Respawn;
using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public class PlayerView : Shark
{
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private PlayerMover _mover;
    private HatManager _hatManager;

    private UIPopup _uiPopup;
    private RespawnShark _respawn;
    private PositionStaticData _positionStaticData;

    public Action<PlayerView> PlayerDied;

    public void Construct(PositionStaticData positionStaticData,GameConfig gameConfig, UIPopup uiPopup
        , BoostButtonUI boostButtonUI)
    {
        _respawn = new RespawnShark();

        _positionStaticData = positionStaticData ?? throw new ArgumentNullException(nameof(positionStaticData));
        _uiPopup = uiPopup;
        _mover.Construct(gameConfig.PlayerData, boostButtonUI);
    }

    public void Destroys(SharkModel killerShark = null)
    {
        PlayerDied?.Invoke(this);
        gameObject.SetActive(false);

        if (killerShark != null)
            _respawn.SetKillerShark(killerShark, this, _uiPopup);

        _respawn.SelectAction();
    }

    public void Teleport()
    {
        transform.position = _positionStaticData.InitPlayerPosition;
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        Score = 1;
        ScoreLevelBar.SetScore(Score);
        ScoreCount = 0;
        ParametrRaising = 10;
        gameObject.SetActive(true);
    }

    public override string GetSharkName()
    {
        NickName.NickNameText.text = AssetAdress.NickPlayer;
        return AssetAdress.NickPlayer;
    }

    public void OnHatButtonPress(int hatIndex)
    {
        _hatManager.ChangeHat(hatIndex);
    }
}
