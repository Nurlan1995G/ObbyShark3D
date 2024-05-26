using UnityEngine;

namespace Assets.Project.CodeBase.SharkEnemy
{
    public class SharkModel : MonoBehaviour
    {
        [SerializeField] private ScoreLevelBar _scoreLevelBar;
        [SerializeField] private TriggerSharkEnemy _triggerSharkEnemy;
        [SerializeField] private float _localScaleX = 0.2f;

        private int _score = 1;

        public int ScoreLevel => _score;

        private int _parametrRaising = 10;

        private void Update()
        {
            int increase = _score;
            int score;

            score = increase / _parametrRaising;

            if (score >= 2)
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

        public void Destroys() =>
            Destroy(gameObject);
    }
}
