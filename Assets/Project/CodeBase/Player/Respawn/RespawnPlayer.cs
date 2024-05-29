using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

namespace Assets.Project.CodeBase.Player.Respawn
{
    public class RespawnPlayer
    {
        private UIPopup _uiPopup;
        private SharkModel _killerShark;
        private PlayerView _playerView;

        public void SetKillerShark(SharkModel sharkModel, PlayerView playerView, UIPopup uIPopup)
        {
            _killerShark = sharkModel;
            _playerView = playerView;
            _uiPopup = uIPopup;
        }

        public void SelectAction()
        {
            _uiPopup.Initialize(this);
            _uiPopup.gameObject.SetActive(true);
        }

        public void Respawn()
        {
            Debug.Log("Player respawned");
            _playerView.Teleport();
        }

        public void Revenge()
        {
            if (_killerShark != null)
            {
                _killerShark.Destroys();
                Debug.Log("Отомстили!");
            }

            Respawn();
        }
    }
}
