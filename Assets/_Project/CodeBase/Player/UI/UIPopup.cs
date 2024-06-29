using Assets.Project.CodeBase.Player.Respawn;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.CodeBase.Player.UI
{
    public class UIPopup : MonoBehaviour
    {
        [SerializeField] private Button respawnButton;
        [SerializeField] private Button revengeButton;
        [SerializeField] private ADTimer _adTimer;

        private RespawnShark respawnPlayer;

        public void Initialize(RespawnShark respawnPlayer)
        {
            this.respawnPlayer = respawnPlayer;
            respawnButton.onClick.AddListener(OnRespawn);
            revengeButton.onClick.AddListener(OnRevenge);
        }

        public void OnRespawn()
        {
            respawnPlayer.Respawn();
            gameObject.SetActive(false);
        }

        public void OnRevenge()
        {
            respawnPlayer.Revenge();
            _adTimer.ShowAdvertisement();
            _adTimer.ResetAndStartTimer();
            gameObject.SetActive(false);
        }
    }
}
