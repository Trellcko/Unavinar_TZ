using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Trell.Unavinar_TZ.UI
{
    [RequireComponent(typeof(Image))]
    public class DraggingPanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public Vector3 StartPosition { get; private set; }
        public Vector3 CurrentPosition { get; private set; }

        public bool IsDragging { get; private set; }

        public event Action DragBegined;

        public event Action DragEnded;

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsDragging = true;
            CurrentPosition = StartPosition = eventData.pointerPressRaycast.screenPosition;
            DragBegined?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            CurrentPosition = eventData.pointerCurrentRaycast.screenPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            DragEnded?.Invoke();
            IsDragging = false;
        }
    }
}