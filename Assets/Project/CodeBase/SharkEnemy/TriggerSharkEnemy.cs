using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

public class TriggerSharkEnemy : MonoBehaviour
{
    [SerializeField] private SharkModel _sharkModel;
 
    private void OnTriggerEnter(Collider other) 
    {
         if(other.TryGetComponent(out Fish fish))
         {
            if (_sharkModel.ScoreLevel >= fish.ScoreLevel)
            {
                Debug.Log(fish.ScoreLevel + "Scorelevelfish");
                _sharkModel.AddScore(fish.ScoreLevel);
                fish.Destroys();
            }
         }

         if(other.TryGetComponent(out PlayerView playerView))
         {
            if(_sharkModel.ScoreLevel >= playerView.ScoreLevel)
            {
                _sharkModel.AddScore(playerView.ScoreLevel);
                playerView.Destroys();
                //playerView.PlayerDied += OnChangedDestoroys;
            }
         }

        if (other.TryGetComponent(out SharkModel targetSharkModel))
        {
            if (_sharkModel.ScoreLevel > targetSharkModel.ScoreLevel && _sharkModel != targetSharkModel)
            {
                _sharkModel.AddScore(targetSharkModel.ScoreLevel);
                targetSharkModel.Destroys();
            }
        }
    }

    private void OnChangedDestoroys(PlayerView playerView)
    {

    }
}
