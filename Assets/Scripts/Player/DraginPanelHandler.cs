using Trell.Unavinar_TZ.UI;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player Draging Panel Handler")]
	public class DraginPanelHandler : MonoBehaviour
	{
		[SerializeField] private DragingPanel _draggingPanel;
		[SerializeField] private Rotater _rotator;

        private float _previousX = 0;

        private void OnEnable()
        {
            _draggingPanel.DragBegined += OnDragBegined;
            _draggingPanel.DragEnded += OnEndDrag;
        }

        private void OnEndDrag()
        {
            _rotator.RotateToNearestSide();
        }

        private void OnDragBegined()
        {
            _rotator.StopRotateToNearesSide();
        }

        public void Update()
        {
            if(_draggingPanel.IsDraging)
            {
                float x = _draggingPanel.CurrentPosition.x - _previousX;
                _rotator.Rotate(x);
                _previousX = _draggingPanel.CurrentPosition.x;
            }
        }

    }
}