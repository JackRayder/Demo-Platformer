using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{

    public class EagleMove
    {
        private const float _flySpeed = 150f;
        private const float _animationSpeed = 5f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private Vector3 _upScale = new Vector3(1, 1, 1);
        private Vector3 _downScale = new Vector3(1, -1, 1);

        private float _xAxisInput;
        private float _yAxisInput;

        private LevelObjectView _view;
        private SpriteAnimator _spriteAnimator;

        public EagleMove(LevelObjectView view, SpriteAnimator spriteAnimator)
        {
            _view = view;
            _spriteAnimator = spriteAnimator;
        }

        public void FixedUpdate()
        {
            _yAxisInput = Input.GetAxis("Vertical");
            _xAxisInput = Input.GetAxis("Horizontal");
            var XnewVelocity = 0f;
            var YnewVelocity = 0f;

            if ((_xAxisInput > 0) || (_xAxisInput < 0))
            {
                XnewVelocity = Time.fixedDeltaTime * _flySpeed * (_xAxisInput < 0 ? -1 : 1);
                _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
            }
            if ((_yAxisInput > 0) || (_yAxisInput < 0))
            {
                YnewVelocity = Time.fixedDeltaTime * _flySpeed * (_yAxisInput < 0 ? -1 : 1);
            }
            _view._rigidbody2D.velocity = _view._rigidbody2D.velocity.Change(x: XnewVelocity);
            _view._rigidbody2D.velocity = _view._rigidbody2D.velocity.Change(y: YnewVelocity);

            _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);

        }
    }
}