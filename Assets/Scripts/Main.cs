using System.Collections.Generic;
using UnityEngine;


namespace Demo
{

    public class Main : MonoBehaviour
    {
        [SerializeField] Camera _camera;
        [SerializeField] private List<LevelObjectView> _wallList;
        [SerializeField] private List<LevelObjectView> _itemList;
        [SerializeField] private List<LevelObjectView> _characterViews;
        [SerializeField] private int _playeranimationSpeed = 5;
        [SerializeField] private Inventory _inventory;

        private FoxyMove _foxyController;
        private EagleMove _eagleController;
        private FrogMove _frogController;
        private SpriteAnimator _frogAnimator;
        private SpriteAnimator _eagleAnimator;
        private SpriteAnimator _foxyAnimator;
        private CameraController _cameraController;
        private ItemManager _itemManager;



        private void Awake()
        {
            SpriteAnimConfg eagleConfig = Resources.Load<SpriteAnimConfg>("Eagle");
            _eagleAnimator = new SpriteAnimator(eagleConfig);
            _eagleAnimator.StartAnimation(_characterViews[1]._spriteRenderer, AnimState.Idle, true, _playeranimationSpeed);
            _eagleController = new EagleMove(_characterViews[1], _eagleAnimator);
            SpriteAnimConfg foxyConfig = Resources.Load<SpriteAnimConfg>("Foxy");
            _foxyAnimator = new SpriteAnimator(foxyConfig);
            _foxyAnimator.StartAnimation(_characterViews[0]._spriteRenderer, AnimState.Idle, true, _playeranimationSpeed);
            _foxyController = new FoxyMove(_characterViews[0], _foxyAnimator);
            SpriteAnimConfg frogConfig = Resources.Load<SpriteAnimConfg>("Frog");
            _frogAnimator = new SpriteAnimator(frogConfig);
            _frogAnimator.StartAnimation(_characterViews[2]._spriteRenderer, AnimState.Idle, true, _playeranimationSpeed);
            _frogController = new FrogMove(_characterViews[2], _wallList, _frogAnimator);
            _cameraController = new CameraController(_characterViews, _camera);
            _itemManager = new ItemManager(_characterViews, _itemList, _inventory);

        }

        private void Update()
        {
            _foxyAnimator.Update();
            _eagleAnimator.Update();
            _frogAnimator.Update();
            _cameraController.Update();
        }

        private void FixedUpdate()
        {
            if (_cameraController.counter == 1)
            {
                _foxyController.FixedUpdate();
            }

            if (_cameraController.counter == 2)
            {
                _eagleController.FixedUpdate();
            }
            if (_cameraController.counter == 3)
            {
                _frogController.FixedUpdate();
            }
        }
    }

}
