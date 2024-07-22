using Assets.CodeBase.CameraLogic;
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
    [SerializeField] private EffectCoin _effectCoin;

    private UIPopup _uiPopup;
    private RespawnShark _respawn;
    private PositionStaticData _positionStaticData;
    private SoundHandler _soundhandler;

    public Action<PlayerView> PlayerDied;
    private CameraRotater _cameraRotater;

    public void Construct(PositionStaticData positionStaticData,GameConfig gameConfig, UIPopup uiPopup
        , BoostButtonUI boostButtonUI, SoundHandler soundHandler, CameraRotater cameraRotater)
    {
        _respawn = new RespawnShark();

        _positionStaticData = positionStaticData ?? throw new ArgumentNullException(nameof(positionStaticData));
        _uiPopup = uiPopup;
        _soundhandler = soundHandler;
        _mover.Construct(gameConfig.PlayerData, boostButtonUI);
        _cameraRotater = cameraRotater;
    }

    public void Destroys(SharkModel killerShark = null)
    {
        PlayerDied?.Invoke(this);
        _soundhandler.PlayLose();
        SetInitialSizeBox();
        gameObject.SetActive(false);
        ScoreLevelBar.SetInitialPositionY();

        if (killerShark != null)
            _respawn.SetKillerShark(killerShark, this, _uiPopup);

        _respawn.SelectAction();
    }

    public void Teleport()
    {
        transform.position = _positionStaticData.InitPlayerPosition;
        ResetScaleAndRotation();
        ResetScoreLevelBar();
        _cameraRotater.ResetRotationCamera();
        gameObject.SetActive(true);
        _soundhandler.PlayWin();
    }


    public override void SetPlayerViewWallet()
    {
        base.SetPlayerViewWallet();

        Wallet.Add(15);
    }

    public override void SetPlayerViewHeightCoins()
    {
        base.SetPlayerViewHeightCoins();

        _effectCoin.SetNewInitPosition();
    }

    public override string GetSharkName()
    {
        NickName.NickNameText.text = AssetAdress.NickPlayerRu;
        return AssetAdress.NickPlayerRu;
    }

    private void ResetScaleAndRotation()
    {
        SharkSkin.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void ResetScoreLevelBar()
    {
        Score = 1;
        ScoreLevelBar.SetScore(Score);
        ScoreCount = 0;
        ParametrRaising = 10;
    }
}
