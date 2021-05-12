using System;
using UnityEngine;

namespace Demo
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
    public class ItemConfig : ScriptableObject, IItem
    {
        public string Title => _title;
        public Sprite Image => _image;

        [SerializeField] private int id;
        [SerializeField] private string _title;
        [SerializeField] private Sprite _image;

    }
}