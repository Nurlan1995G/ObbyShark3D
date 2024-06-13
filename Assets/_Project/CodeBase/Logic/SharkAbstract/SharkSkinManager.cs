using System.Collections.Generic;
using UnityEngine;

public class SharkSkinManager : MonoBehaviour
{
    [field: SerializeField] public List<SharkSkin> SkinsSharks = new List<SharkSkin>();

    private List<int> _idSharkSkin = new List<int> { 31620, 31482, 31482, 31408, 32128, 31596 };

    private SharkSkin _currentSkin;

    private void Awake()
    {
        for (int i = 0; i < SkinsSharks.Count; i++)
        {
            if(i < _idSharkSkin.Count)
                SkinsSharks[i].Id = _idSharkSkin[i];
        }
    }

    public void ChangeSkinShark(int indexSkin)
    {
        if (indexSkin < 0 || indexSkin >= SkinsSharks.Count)
        {
            Debug.LogError("Invalid skinShark index");
            return;
        }

        if (_currentSkin != null)
        {
            _currentSkin.gameObject.SetActive(false);
        }

        _currentSkin = SkinsSharks[indexSkin];
        _currentSkin.gameObject.SetActive(true);
    }
}
