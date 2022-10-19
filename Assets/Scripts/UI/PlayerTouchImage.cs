using UnityEngine;
using UnityEngine.UI;

namespace Trell.Unavinar_TZ.UI
{
    [RequireComponent(typeof(Image))]
    public class PlayerTouchImage : MonoBehaviour
    {
        [SerializeField] private DraggingPanel _draggingPanel;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            _draggingPanel.DragBegined += OnDragBegined;
            _draggingPanel.DragEnded += OnDragEnded;
        }

        private void OnDisable()
        {
            _draggingPanel.DragBegined -= OnDragBegined;
            _draggingPanel.DragEnded -= OnDragEnded;
        }

        private void Update()
        {
            if(_draggingPanel.IsDragging)
            {
                transform.position = _draggingPanel.CurrentPosition;
            }
        }

        private void OnDragEnded()
        {
            _image.enabled = false;
        }

        private void OnDragBegined()
        {
            _image.enabled = true;
        }
    }
}