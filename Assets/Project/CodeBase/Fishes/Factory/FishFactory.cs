using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Fish.Factory;
using System;
using UnityEngine;

public class FishFactory
{
    private readonly FishStaticData _fishStaticData;
    private readonly AssetProvider _assetProvider;

    public FishFactory(FishStaticData fishStaticData, AssetProvider assetProvider)
    {
        _fishStaticData = fishStaticData ?? throw new ArgumentNullException(nameof(fishStaticData));
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
                return _assetProvider.Instantiate(_fishStaticData.AngelFish, whereToSpawn, Quaternion.identity);

            case TypeFish.Beluga:
                return _assetProvider.Instantiate(_fishStaticData.BelugaFish, whereToSpawn, Quaternion.identity);

            case TypeFish.Picasso:
                return _assetProvider.Instantiate(_fishStaticData.PicassoFish, whereToSpawn, Quaternion.identity);

            case TypeFish.Parrot:
                return _assetProvider.Instantiate(_fishStaticData.ParrotFish, whereToSpawn, Quaternion.identity);

            case TypeFish.Napoleon:
                return _assetProvider.Instantiate(_fishStaticData.NapoleonFish, whereToSpawn, Quaternion.identity);

            case TypeFish.Luna:
                return _assetProvider.Instantiate(_fishStaticData.LunaFish, whereToSpawn, Quaternion.identity);

            default:
                    throw new InvalidOperationException(nameof(fishType));
        }
    }
}
