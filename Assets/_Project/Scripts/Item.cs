using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

namespace CreativeCoding.InventorySystem
{
    [Serializable]
    public class Item : ScriptableObject
    {
        public string itemName;
        [TextArea(1, 10)]
        public string description;
        public Gradient outlineGradient;
        public AssetReferenceT<Sprite> thumbnail;
        public float weight = 1;
        public uint baseCost = 1;
        public AssetReferenceT<AudioClip> selectionSound;
        public AssetReferenceT<AudioClip> usingSound;
        public string[] properties;
    }
}