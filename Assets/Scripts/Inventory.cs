using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Demo
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private Transform _container;


        public void Render(ItemConfig items)
        {
                var cell = Instantiate(_inventoryView, _container);
                cell.Render(items);
        }
    }
}