using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player Initializer")]
	public class Initializer : MonoBehaviour
	{
		[SerializeField] private GameObject _cubePrefab;
		[SerializeField] private GameData _gameData;
		[SerializeField] private Transform _playerTransform;
		[SerializeField] private Vector3[] _form;

		[SerializeField] private float _cubeScale = 0.2f;

		private void Awake()
        {
			Initialize();
        }

		private void Initialize()
        {
			int maxWidth = (int)(_cubeScale / 2);

			foreach(var cubePosition in _form)
            {
				float absX = Mathf.Abs(cubePosition.x);
				float absZ = Mathf.Abs(cubePosition.z);

				if(absX > maxWidth || cubePosition.y > _gameData.MaxFormSize.y || absZ > maxWidth)
                {
					return;
                }

				Instantiate(_cubePrefab, cubePosition * _cubeScale, Quaternion.identity, _playerTransform);
            }
        }
	}
}