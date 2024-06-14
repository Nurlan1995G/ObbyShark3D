using UnityEngine;
using UnityEngine.UI;

public class GameActivator : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _shopButton;
    //[SerializeField] private Camera _mainCamera;
    //[SerializeField] private Player _character;

    private void Start()
    {
        //_mainCamera.enabled = false;
        //_character.TryStart(false);
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(ActivateGame);
        _shopButton.onClick.AddListener(DeacrivateGame);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(DeacrivateGame);
        _startButton.onClick.RemoveListener(ActivateGame);
    }

    private void ActivateGame()
    {
        //_mainCamera.enabled = true;
        //_character.TryStart(true);
        Time.timeScale = 1;
    }

    private void DeacrivateGame()
    {
        //_mainCamera.enabled = false;
        Time.timeScale = 0;
        //_character.TryStart(false);
    }
}