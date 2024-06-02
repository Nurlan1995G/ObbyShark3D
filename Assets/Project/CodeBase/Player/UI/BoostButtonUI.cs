using UnityEngine;

namespace Assets.Project.CodeBase.Player.UI
{
    public class BoostButtonUI : MonoBehaviour
    {
        private PlayerMover _playerMover;

        public void Initialize(PlayerMover playerMover) =>
            _playerMover = playerMover;

        public void OnBoostButtonPressed()=>
            _playerMover.OnBoostStarted();

        public void OnBoostButtonReleased() =>
            _playerMover.OnBoostCanceled();
    }
}
