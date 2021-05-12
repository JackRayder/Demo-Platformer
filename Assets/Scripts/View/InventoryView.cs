using UnityEngine;
using UnityEngine.UI;

namespace Demo
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Text _titleField;
        [SerializeField] private Image _imageField;

        public void Render(IItem item)
        {
            _titleField.text = item.Title;
            _imageField.sprite = item.Image;
        }
    }
}