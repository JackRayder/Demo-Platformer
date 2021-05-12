using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class CameraController
    {
        public int counter = 1;
        private Camera _camera;
        private List<LevelObjectView> _characterViews;
        private float offsetY = 1.5f;
        private float offsetZ = 10f;

        public CameraController(List<LevelObjectView> characterViews, Camera camera)
        {
            _characterViews = characterViews;
            _camera = camera;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                counter += 1;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                counter -= 1;
            }
            if (counter == 4)
            {
                counter = 1;
            }
            if (counter == 0)
            {
                counter = 3;
            }
            if (counter == 1)
            {
                _camera.transform.position = new Vector3(_characterViews[0].transform.position.x, _characterViews[0].transform.position.y + offsetY, _characterViews[0].transform.position.z - offsetZ);

            }
            if (counter == 2)
            {
                _camera.transform.position = new Vector3(_characterViews[1].transform.position.x, _characterViews[1].transform.position.y, _characterViews[1].transform.position.z - offsetZ);
            }
            if (counter == 3)
            {
                _camera.transform.position = new Vector3(_characterViews[2].transform.position.x, _characterViews[2].transform.position.y + offsetY, _characterViews[2].transform.position.z - offsetZ);
            }
        }
    }
}