using Assets.Project.AssetProviders;
using System;
using UnityEngine;

public class FishFactory
{
    private readonly FishStaticData _fishStaticData;
    private readonly AssetProvider _assetProvider;

    public FishFactory(ConfigFish configFish, AssetProvider assetProvider)
    {
        _fishStaticData = configFish.FishStaticData
            ?? throw new ArgumentNullException(nameof(configFish));
        _assetProvider = assetProvider ?? throw new ArgumentNullException(nameof(assetProvider));
    }

    public Fish GetFish(TypeFish fishType, Vector3 whereToSpawn)
    { 
        switch (fishType)
        {
            case TypeFish.Hedgehog:
                    return _assetProvider.Instantiate(_fishStaticData.HedgehogPrefab, whereToSpawn, Quaternion.identity);

            case TypeFish.BlueSergeon:
                    return _assetProvider.Instantiate(_fishStaticData.BlueSergeonPrefab, whereToSpawn
                        , Quaternion.identity);

            case TypeFish.Cloun:
                    return _assetProvider.Instantiate(_fishStaticData.ClounPrefab, whereToSpawn, Quaternion.identity);

            case TypeFish.Angel:
                return _assetProvider.Instantiate(_fishStaticData.AngelFishPrefab, whereToSpawn, Quaternion.identity);

            case TypeFish.Beluga:
                return _assetProvider.Instantiate(_fishStaticData.BelugaFishPrefab, whereToSpawn, Quaternion.identity);

            case TypeFish.Picasso:
                return _assetProvider.Instantiate(_fishStaticData.PicassoFishPrefab, whereToSpawn, Quaternion.identity);

            case TypeFish.Parrot:
                return _assetProvider.Instantiate(_fishStaticData.ParrotFishPrefab, whereToSpawn, Quaternion.identity);

            case TypeFish.Napoleon:
                return _assetProvider.Instantiate(_fishStaticData.NapoleonFishPrefab, whereToSpawn, Quaternion.identity);

            case TypeFish.Luna:
                return _assetProvider.Instantiate(_fishStaticData.LunaFishPrefab, whereToSpawn, Quaternion.identity);

            default:
                    throw new InvalidOperationException(nameof(fishType));
        }
    }
}
