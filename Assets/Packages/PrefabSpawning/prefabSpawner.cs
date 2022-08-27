using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class prefabSpawner : MonoBehaviour
{
    [Serializable]
    struct assetAndLocation
    {
        public GameObject gameObject;
        public Vector2 location;
    }
    [SerializeField] assetAndLocation[] items;

    void Start()
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
