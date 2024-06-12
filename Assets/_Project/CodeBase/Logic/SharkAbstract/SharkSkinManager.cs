using System.Collections.Generic;
using UnityEngine;

public class SharkSkinManager : MonoBehaviour
{
    [field: SerializeField] public List<GameObject> SkinsShark = new List<GameObject>();

    private GameObject _currentSkin;

    public void ChangeSkinShark(int indexSkin)
    {
        if (indexSkin < 0 || indexSkin >= SkinsShark.Count)
        {
            Debug.LogError("Invalid skinShark index");
            return;
        }

        if (_currentSkin != null)
        {
            _currentSkin.SetActive(false);
        }

        _currentSkin = SkinsShark[indexSkin];
        _currentSkin.SetActive(true);
    }
}
