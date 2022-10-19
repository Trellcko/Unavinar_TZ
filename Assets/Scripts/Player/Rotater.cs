using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	public class Rotater : MonoBehaviour
	{
		[Min(1)]
		[SerializeField] private float _rotatePower = 1f;

		private Quaternion _roundingRotation;

		private bool _doRotateToNearestSide;

		private void Update()
		{
			if (_doRotateToNearestSide)
			{
				transform.rotation = Quaternion.RotateTowards(transform.rotation, _roundingRotation, Time.deltaTime * _rotatePower);
			}
		}

        public void Rotate(float y)
        {
			Quaternion rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + y, 0));

			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * _rotatePower);
		}
		
		public void RotateToNearestSide()
        {
			_doRotateToNearestSide = true;

			float yAngel = transform.rotation.eulerAngles.y;

			float newYAngel = Mathf.Round(yAngel / 90) * 90;
			_roundingRotation = Quaternion.Euler(0, newYAngel, 0);
		}

		public void StopRotateToNearesSide()
        {
			_doRotateToNearestSide = false;
        }
	}
}