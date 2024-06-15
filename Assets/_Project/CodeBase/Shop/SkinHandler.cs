using System.Collections.Generic;
using UnityEngine;

public class SkinHandler : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private List<RewardModel> _playerSkins;
    [SerializeField] private List<RewardModel> _hatSkins;

    private void OnEnable()
    {
        _shop.SkinCangedInShop += LoadSkins;
    }

    private void Start() =>
        LoadSkins();

    private void OnDisable()
    {
        _shop.SkinCangedInShop -= LoadSkins;
    }

    private void LoadSkins()
    {
        var selectedSkin = YandexSDK.Instance.Data.SelectedSkin;
        var selectedObject = YandexSDK.Instance.Data.SelectedObject;

        Load(selectedSkin, _playerSkins);
        Load(selectedObject, _hatSkins);
    }

    private void Load(int id, List<RewardModel> skins)
    {
        foreach (var skin in skins)
        {
            if (id == skin.ItemInfo.Id)
                skin.ChangeState(true);
            else
                skin.ChangeState(false);
        }
    }
}