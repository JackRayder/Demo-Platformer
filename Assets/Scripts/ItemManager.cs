using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{

    public class ItemManager : IDisposable
    {
        private List<LevelObjectView> _itemViews;
        private List<LevelObjectView> _characterViews;
        private ItemConfig _itemConfig;
        private Inventory _inventory;
        public bool check = false;

        public ItemManager(List<LevelObjectView> characterViews, List<LevelObjectView> itemViews, Inventory inventory)
        {
            _inventory = inventory;
            _characterViews = characterViews;
            _itemViews = itemViews;
            _characterViews[0].OnLevelObjectContact += OnLevelObjectContact;
            _characterViews[1].OnLevelObjectContact += OnLevelObjectContact;
            _characterViews[2].OnLevelObjectContact += OnLevelObjectContact;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {

            if (_itemViews.Contains(contactView))
            {
                check = true;
                _itemConfig = contactView._itemConfig;
                _inventory.Render(_itemConfig);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _characterViews[0].OnLevelObjectContact -= OnLevelObjectContact;
            _characterViews[1].OnLevelObjectContact -= OnLevelObjectContact;
            _characterViews[2].OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}