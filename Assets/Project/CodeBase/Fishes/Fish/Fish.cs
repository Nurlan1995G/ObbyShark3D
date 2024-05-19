using System;
using TMPro;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;   
    
    public event Action<Fish> FishDied;

    public int ScoreLevel { get; protected set; }

    private void Start()
    {
        WriteScoreLevel();
        _scoreText.text = ScoreLevel.ToString();
    }

    public void Destroys()
    {
        FishDied?.Invoke(this);
        Destroy(gameObject);
    }

    protected abstract int WriteScoreLevel();
}
