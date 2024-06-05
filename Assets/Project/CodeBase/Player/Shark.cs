using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] private ScoreLevelBar _scoreLevelBar;
    [SerializeField] private float _localScaleX = 0.2f;

    private int _score = 1;
    private int _parametrRaising = 10;
    private int _scoreCount;

    public int ScoreLevel => _score;

    private void Update() =>
        IncreaseSize();

    private void IncreaseSize()
    {
        int increase = _score;
        _scoreCount = increase / _parametrRaising;

        if (_scoreCount >= 2)
        {
            transform.localScale += new Vector3(_localScaleX, _localScaleX, _localScaleX);
            _parametrRaising *= 3;
        }
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreLevelBar.SetScore(_score);
    }
}