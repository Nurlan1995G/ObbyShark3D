using UnityEngine;

namespace Assets.Project.CodeBase.Player.UI
{
    public class EffectCoin : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;      // Скорость движения вверх
        [SerializeField] private float _fadeSpeed = 5f;      // Скорость исчезновения альфа

        [field: SerializeField] public CanvasGroup CanvasGroup;

        public bool IsFadingOut = false;

        private Vector3 _initialPosition;

        private void Start()
        {
            _initialPosition = transform.localPosition;
        }

        private void OnEnable()
        {
            CanvasGroup.alpha = 1f;
            transform.localPosition = _initialPosition;
        }

        void Update()
        {
            transform.localPosition += Vector3.up * _moveSpeed * Time.deltaTime;

            if (IsFadingOut)
            {
                CanvasGroup.alpha -= _fadeSpeed * Time.deltaTime;

                if (CanvasGroup.alpha <= 0f)
                {
                    CanvasGroup.alpha = 0f;
                    gameObject.SetActive(false);
                    IsFadingOut = false;
                    transform.localPosition = _initialPosition;
                }
            }
        }
    }
}
