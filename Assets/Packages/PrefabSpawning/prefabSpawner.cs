using System;
using UnityEditor;
using UnityEngine;

namespace Packages.PrefabSpawning
{
    public class PrefabSpawner : MonoBehaviour
    {
        [Serializable]
        private struct AssetAndLocation
        {
            public GameObject gameObject;
            public Vector2 location;
        }
        [SerializeField] private AssetAndLocation[] items;

        private void Start()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (PrefabUtility.IsPartOfAnyPrefab(items[i].gameObject))
                {
                    try { Instantiate(items[i].gameObject, items[i].location, Quaternion.identity); }
                    catch { print("Fill in the prefab spawner fields!"); }
                }
                else
                {
                    Debug.Log("Only spawn prefabs!");
                }
            }
        }
    }
}
