using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class ButtonControllers : MonoBehaviour
    {
        public void OnClickButton()
        {
            Destroy(gameObject);
        }
    }
}