using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Trell.Unavinar_TZ.UI
{
    [RequireComponent(typeof(Image))]
    public class DragingPanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public Vector3 CurrentPosition { get; private set; }

        public bool IsDraging { get; private set; }

        public Vector3 DeltaPosition { get; private set; }

        public event Action DragBegined;

        public event Action DragEnded;

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsDraging = true;
            CurrentPosition = eventData.pointerPressRaycast.screenPosition;
            DragBegined?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            CurrentPosition = eventData.pointerCurrentRaycast.screenPosition;
            DeltaPosition = eventData.delta;


        }

        public void OnEndDrag(PointerEventData eventData)
        {
            DragEnded?.Invoke();
            IsDraging = false;
        }
    }
}