using TMPro;
using UnityEngine;

public class ScoreLevelBar : MonoBehaviour
{
    [field: SerializeField] public TextMeshProUGUI ScoreText;

    public void SetScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}
