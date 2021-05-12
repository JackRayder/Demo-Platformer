using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{

    public class FrogMove : IDisposable
    {
        private const float _walkSpeed = 150f;
        private const float _animationSpeed = 10f;
        private const float _jumpForce = 3f;
        private const float _jumpTresh = 0.1f;
        private const float _movingTresh = 0.1f;
        private const float _flyTresh = 1f;
        private const float _groundLevel = -2.5f;
        private const float _g = -10f;
        private float onWall = 0;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private bool _doJump;
        private float _xAxisInput;

        private LevelObjectView _view;
        private SpriteAnimator _spriteAnimator;
        private Contactpoller _contactpoller;
        private List<LevelObjectView> _wallsViews;

        public FrogMove(LevelObjectView view, List<LevelObjectView> wallsViews, SpriteAnimator spriteAnimator)
        {
            _wallsViews = wallsViews;
            _view = view;
            _spriteAnimator = spriteAnimator;
            _view.OnLevelObjectContact += OnLevelObjectContact;
            _contactpoller = new Contactpoller(_view._collider2D);
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_wallsViews.Contains(contactView))
            {
                onWall = 0.2f;
            }
        }

        public void FixedUpdate()
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            _contactpoller.Update();
            var walks = Mathf.Abs(_xAxisInput) > _movingTresh;
            var newVelocity = 0f;

            if (walks && (_xAxisInput > 0 || !_contactpoller.HasLeftContact) && (_xAxisInput < 0 || !_contactpoller.HasRightContact))
            {
                newVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
                _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
            }
            _view._rigidbody2D.velocity = _view._rigidbody2D.velocity.Change(x: newVelocity);

            if ((_contactpoller.IsGrounded || onWall > 0) && _doJump && Mathf.Abs(_view._rigidbody2D.velocity.y) <= _jumpTresh)
            {
                _view._rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }

            if (_contactpoller.IsGrounded)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, walks ? AnimState.Run : AnimState.Idle, true, _animationSpeed);
            }
            else if (Mathf.Abs(_view._rigidbody2D.velocity.y) > _flyTresh)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
            }

            if (onWall > 0)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.SpecialMove, true, _animationSpeed);
            }

            onWall -= Time.deltaTime;
        }
        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}