using UnityEngine;

namespace Assets.Project.CodeBase.Fish.Factory
{
    [CreateAssetMenu(fileName = "FishFactory", menuName = "Fish/Factory")]
    public class FishStaticData : ScriptableObject
    {
        [field: SerializeField] public HedgehogFish HedgehogPrefab;
        [field: SerializeField] public BlueSergeonFish BlueSergeonPrefab;
        [field: SerializeField] public ClounFish ClounPrefab;
        [field: SerializeField] public AngelFish AngelFish;
        [field: SerializeField] public BelugaFish BelugaFish;
        [field: SerializeField] public PicassoFish PicassoFish;
        [field: SerializeField] public ParrotFish ParrotFish;
        [field: SerializeField] public NapoleonFish NapoleonFish;
        [field: SerializeField] public LunaFish LunaFish;
    }
}
