using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player Initializer")]
	public class Initializer : MonoBehaviour
	{
		[SerializeField] private GameObject _cubePrefab;
		[SerializeField] private Transform _playerTransform;
		[SerializeField] private Vector3[] _form;

		[SerializeField] private float _cubeScale = 0.2f;

		private void Awake()
        {
			Initialize();
        }

		private void Initialize()
        {
			foreach(var cubePosition in _form)
            {
				Instantiate(_cubePrefab, cubePosition * _cubeScale, Quaternion.identity, _playerTransform);
            }
        }
	}
}