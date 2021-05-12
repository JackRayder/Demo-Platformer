using System;
using UnityEngine;

namespace Demo
{

    public class LevelObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Rigidbody2D _rigidbody2D;
        public Collider2D _collider2D;
        public Collider2D _crouchCollider2D;
        public ItemConfig _itemConfig;

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var levelObject = collision.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}