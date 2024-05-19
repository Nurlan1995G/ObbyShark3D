using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using Assets.Project.CodeBase.SharkEnemy.Static;
using UnityEngine;

namespace Assets.Project.CodeBase.SharkEnemy.Spawner
{
    public class SpawnPointEnemy : MonoBehaviour
    {
        private FactoryShark _factoryShark;
        private PositionStaticData _sharkPositionStaticData;
        private PlayerView _playerView;
        private SpawnerFish _spawnerFish;
        private SharkStaticData _sharkStaticData;

        public void Construct(FactoryShark factoryShark, PositionStaticData sharkPositionStaticData
            ,PlayerView playerView, SpawnerFish spawnerFish, SharkStaticData sharkStaticData)
        {
            _factoryShark = factoryShark;
            _sharkPositionStaticData = sharkPositionStaticData;
            _playerView = playerView;
            _spawnerFish = spawnerFish;
            _sharkStaticData = sharkStaticData;
        }

        public void RespawnBotShark(GameObject gameObject)
        {
            InitShark(_sharkPositionStaticData);
        }

        private void InitShark(PositionStaticData levelStaticData)
        {
            CreateSharkScene(levelStaticData.InitSharkOnePosition, AssetAdress.SharkEnemy1);

            CreateSharkScene(levelStaticData.InitSharkTwoPosition, AssetAdress.SharkEnemy2);
        }

        private BotSharkView CreateSharkScene(Vector3 positionShark, string sharkEnemy)
        {
            BotSharkView botShark = _factoryShark.CreateSharkEnemy(sharkEnemy, positionShark);

            botShark.Construct(_spawnerFish, _sharkStaticData, _playerView);

            return botShark;
        }
    }
}
