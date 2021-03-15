using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fruit.Loot
{
    [CreateAssetMenu(menuName = "Fruit Framework/Loot/Lootable", fileName = "NewLootable")]
    public class Lootable : ScriptableObject
    {
        [SerializeField]
        protected string itemName = "";
        [SerializeField, TextArea]
        protected string description = "";
        [SerializeField, TextArea]
        protected Sprite sprite;
    }
}

