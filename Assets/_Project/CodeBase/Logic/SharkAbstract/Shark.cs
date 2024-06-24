using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public abstract class Shark : MonoBehaviour
{
    [field: SerializeField] protected ScoreLevelBar ScoreLevelBar;
    [SerializeField] protected NickName NickName;
    [SerializeField] private float _localScaleX = 0.2f;
    [SerializeField] private GameObject _crown;
    [SerializeField] protected GameObject SharkSkin;
    
    private TopSharksManager _topSharkManager;

    protected int Score = 1;
    protected int ParametrRaising = 10;
    protected int ScoreCount;

    public int ScoreLevel => Score;

    public event Action OnScoreChanged;

    private void Start() =>
        _topSharkManager.RegisterShark(this);

    private void Update() =>
        IncreaseSize();

    private void OnDestroy() =>
        _topSharkManager.UnregisterShark(this);

    public void Init(TopSharksManager topSharksManager) =>
        _topSharkManager = topSharksManager;

    public abstract string GetSharkName();

    public void AddScore(int score)
    {
        Score += score;
        ScoreLevelBar.SetScore(Score);
        OnScoreChanged?.Invoke();
    }

    public void SetCrown(bool isActive) => 
        _crown.SetActive(isActive);
    
    private void IncreaseSize()
    {
        int increase = Score;
        ScoreCount = increase / ParametrRaising;

        if (ScoreCount >= 2)
        {
            SharkSkin.transform.localScale += new Vector3(_localScaleX, _localScaleX, _localScaleX);
            ParametrRaising *= 3;
        }
    }
}
