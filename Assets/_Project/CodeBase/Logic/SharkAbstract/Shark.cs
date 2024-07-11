using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public abstract class Shark : MonoBehaviour
{
    [field: SerializeField] protected ScoreLevelBar ScoreLevelBar;
    [SerializeField] protected NickName NickName;
    [SerializeField] protected GameObject SharkSkin;
    [SerializeField] protected BoxCollider BoxCollider;
    [SerializeField] private float _localScaleX = 0.2f;
    [SerializeField] private GameObject _crown;

    protected int Score = 1;
    protected int ParametrRaising = 10;
    protected int ScoreCount;

    private TopSharksManager _topSharkManager;

    private float _centerZ = -0.35f;
    private float _sizeX = 0.8f;
    private float _sizeZ = 1.5f;

    public int ScoreLevel => Score;

    public event Action OnScoreChanged;

    public void Init(TopSharksManager topSharksManager)
    {
        _topSharkManager = topSharksManager;
        SetInitialSizeBox();
        _topSharkManager.RegisterShark(this);
    }

    private void Update() =>
        IncreaseSize();

    private void OnDestroy() =>
        _topSharkManager.UnregisterShark(this);

    public abstract string GetSharkName();
    public virtual void SetPlayerViewHeightCoins() { }
    public virtual void SetPlayerViewWallet() { }

    public void SetCrown(bool isActive) => 
        _crown.SetActive(isActive);

    public void AddScore(int score)
    {
        Score += score;
        ScoreLevelBar.SetScore(Score);
        SetPlayerViewWallet();
        OnScoreChanged?.Invoke();
    }
    
    protected void SetInitialSizeBox()
    {
        _centerZ = -0.35f;
        _sizeX = 0.8f;
        _sizeZ = 1.5f;

        BoxCollider.center = new Vector3(0, 0, _centerZ);
        BoxCollider.size = new Vector3(_sizeX, 0.3f, _sizeZ);
    }

    private void IncreaseSize()
    {
        int increase = Score;
        ScoreCount = increase / ParametrRaising;

        if (ScoreCount >= 2)
        {
            SharkSkin.transform.localScale += new Vector3(_localScaleX, _localScaleX, _localScaleX);
            ParametrRaising *= 3;
            ScoreLevelBar.IncreasePositionY();
            SetBoxCollider();
            SetPlayerViewHeightCoins();
        }
    }

    private void SetBoxCollider() 
    {
        _centerZ -= 0.3f;
        _sizeX += 0.5f;
        _sizeZ += 1f;

        BoxCollider.center = new Vector3(0, 0, _centerZ);
        BoxCollider.size = new Vector3(_sizeX, 0.5f, _sizeZ);
    }
}
