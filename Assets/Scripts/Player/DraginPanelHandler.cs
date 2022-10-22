using Trell.Unavinar_TZ.Core;
using Trell.Unavinar_TZ.UI;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    [AddComponentMenu("Player (Draging Panel Handler)")]
	public class DraginPanelHandler : MonoBehaviour
	{
		[SerializeField] private DragingPanel _draggingPanel;
		[SerializeField] private Rotater _rotator;
        [SerializeField] private BlockContainer _blockContainer;
        [SerializeField] private Movement _movement;
        [SerializeField] private ScoreCounter _scoreCounter;

        private float _previousX = 0;

        private void OnEnable()
        {
            _draggingPanel.DragBegined += OnDragBegined;
            _draggingPanel.DragEnded += OnEndDrag;
        }

        private void OnDisable()
        {
            _draggingPanel.DragBegined -= OnDragBegined;
            _draggingPanel.DragEnded -= OnEndDrag;
        }

        private void OnEndDrag()
        {
            _rotator.RotateToNearestSide();
        }

        private void OnDragBegined()
        {
            _scoreCounter.TurnOffCounting();
            _rotator.StopRotateToNearesSide();
            _movement.ResetSpeed();
            _blockContainer.StopVisualEffects();
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