using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class LockerController : MonoBehaviour
    {
        private ItemManager _itemManager;
        private bool _open = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _open = true;
            Destroy(gameObject);
        }
    }

}

