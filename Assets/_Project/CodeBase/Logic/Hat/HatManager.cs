using Assets.Project.AssetProviders;
using UnityEngine;

public class HatManager 
{
    private GameObject _currentHat;
    private HatManagerData _hatManagerData;
    private AssetProvider _assetProvider;

    public void Construct(GameConfig gameConfig, AssetProvider assetProvider)
    {
        _hatManagerData = gameConfig.HatManagerData;
        _assetProvider = assetProvider;
    }

    public void ChangeHat(int hatIndex)
    {
        if (hatIndex < 0 || hatIndex >= _hatManagerData.Hats.Count)
        {
            Debug.LogError("Invalid hat index");
            return;
        }

        if (_currentHat != null)
        {
            //Destroy(_currentHat);
        }

        _currentHat = _assetProvider.Instantiate(_hatManagerData.Hats[hatIndex], _hatManagerData.HatPosition);
        _currentHat.transform.localPosition = Vector3.zero;
        _currentHat.transform.localRotation = Quaternion.identity;
    }
}
