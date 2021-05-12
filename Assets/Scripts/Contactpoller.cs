using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{

    public class Contactpoller
    {
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];

        private const float _collisionTresh = 0.6f;
        private int _contactCount;
        private readonly Collider2D _collider2D;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        public Contactpoller(Collider2D Collider2D)
        {
            _collider2D = Collider2D;
        }

        public void Update()
        {
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            _contactCount = _collider2D.GetContacts(_contacts);

            for (int i = 0; i < _contactCount; i++)
            {
                var normal = _contacts[i].normal;
                var rB = _contacts[i].rigidbody;

                if (normal.y > _collisionTresh) IsGrounded = true;

                if (normal.x > _collisionTresh) HasLeftContact = true;

                if (normal.x < -_collisionTresh) HasRightContact = true;

            }
        }
    }
}