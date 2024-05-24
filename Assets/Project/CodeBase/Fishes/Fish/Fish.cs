using System;
using TMPro;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private PlayerView _playerView;

    public event Action<Fish> FishDied;

    public int ScoreLevel { get; protected set; }

    private void Start()
    {
        WriteScoreLevel();
        _scoreText.text = ScoreLevel.ToString();
    }

    private void Update()
    {
        UpdateScoreTextColor();
    }

    public void Construct(PlayerView playerView) =>
        _playerView = playerView;

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
                _scoreText.color = Color.green;
            }
            else
            {
                _scoreText.color = Color.red;
            }
        }
    }
}
