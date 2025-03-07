﻿using UnityEngine;

namespace Assets.Project.AssetProviders
{
    public class AssetProvider
    {
        public Fish Instantiate(Fish fish, Vector3 whereToSpawn, Quaternion identity) =>
            Object.Instantiate(fish, whereToSpawn, identity);

        public BotSharkView Instantiate(string path, Vector3 position) =>
            Object.Instantiate(Resources.Load<BotSharkView>(path), position, Quaternion.identity);

        public PlayerView Instantiate<T>(string path, Vector3 position) where T : class =>
            Object.Instantiate(Resources.Load<PlayerView>(path), position, Quaternion.identity);
    }
}