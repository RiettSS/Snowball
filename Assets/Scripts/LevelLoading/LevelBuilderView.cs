using UnityEngine;

namespace LevelLoading
{
    public class LevelBuilderView : MonoBehaviour
    {
        public void BuildLevel(string levelName)
        {
            Debug.Log(levelName);
        }

        public void SpawnCoin(CoinDTO coinDto)
        {
            var prefab = PrefabDictionary.GetPrefab(SavableObjectType.Coin);

            Debug.Log(prefab.transform.position);
            
            UnityEngine.Vector3 position =
                new UnityEngine.Vector3(coinDto.Position.X, coinDto.Position.Y, coinDto.Position.Z);
            
            UnityEngine.Vector3 rotation =
                new UnityEngine.Vector3(coinDto.Rotation.X, coinDto.Rotation.Y, coinDto.Rotation.Z);

            var coin = GameObject.Instantiate(prefab, position, Quaternion.identity, null);
            coin.transform.Rotate(rotation);
        }
    }
}