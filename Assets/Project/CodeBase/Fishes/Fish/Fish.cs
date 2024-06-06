using System;
using TMPro;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    private Shark _playerView;
    private ScoreLevelBarFish _scoreLevelBarFish;

    public event Action<Fish> FishDied;

    public int ScoreLevel { get; protected set; }

    private void Start()
    {
        WriteScoreLevel();
        _scoreLevelBarFish.ScoreText.text = ScoreLevel.ToString();
    }

    private void Update()
    {
        UpdateScoreTextColor();
    }

    public void Construct(Shark playerView, ScoreLevelBarFish scoreBarObject)
    {
        _playerView = playerView;
        _scoreLevelBarFish = scoreBarObject;
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
                _scoreLevelBarFish.ScoreText.color = Color.green;
            }
            else
            {
                _scoreLevelBarFish.ScoreText.color = Color.red;
            }
        }
    }
}
