using System;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    [field: SerializeField] public GameObject FishScale;
    [SerializeField] protected ScoreLevelBarFish ScoreLevelBarFish;

    private Shark _playerView;

    public int ScoreLevel { get; protected set; }

    public event Action<Fish> FishDied;

    private void Start()
    {
        WriteScoreLevel();
        ScoreLevelBarFish.ScoreText.text = ScoreLevel.ToString();
    }

    private void Update()
    {
        UpdateScoreTextColor();
    }

    public void Construct(Shark playerView)
    {
        _playerView = playerView;
    }

    public void Destroys()
    {
        FishDied?.Invoke(this);
        Destroy(gameObject);
    }

    protected abstract int WriteScoreLevel();

    private void UpdateScoreTextColor()
    {
        if (_playerView != null)
        {
            if (_playerView.ScoreLevel >= ScoreLevel)
            {
                ScoreLevelBarFish.ScoreText.color = Color.green;
            }
            else
            {
                ScoreLevelBarFish.ScoreText.color = Color.red;
            }
        }
    }
}
