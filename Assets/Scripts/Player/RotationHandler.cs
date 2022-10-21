using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	public class RotationHandler : MonoBehaviour
	{
		[SerializeField] private Rotater _rotater;
        [SerializeField] private FormChecker _formChecker;
		[SerializeField] private Movement _movement;

        private void OnEnable()
        {
            _rotater.RotationFixed += OnRotationFixed;
        }

        private void OnDisable()
        {
            _rotater.RotationFixed -= OnRotationFixed;
        }

        private void OnRotationFixed()
        {
            if(_formChecker.CheckForm())
            {
                _movement.SpeedUp();
                return;
            }
            _movement.ResetSpeed();
        }
    }
}