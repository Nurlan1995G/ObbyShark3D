using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hats = new List<GameObject>();

    private GameObject _currentHat;

    public void ChangeHat(int hatIndex)
    {
        if (hatIndex < 0 || hatIndex >= _hats.Count)
        {
            Debug.LogError("Invalid hat index");
            return;
        }

        if (_currentHat != null)
        {
            _currentHat.SetActive(false);
        }

        _currentHat = _hats[hatIndex];
        _currentHat.SetActive(true);
    }
}
