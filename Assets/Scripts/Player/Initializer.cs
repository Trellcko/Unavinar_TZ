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

		private void Awake()
        {
			Initialize();
        }

		private void Initialize()
        {
			int maxWidth = _gameData.MaxFormSize.x / 2;

			foreach(var cubePosition in _form)
            {
				float absX = Mathf.Abs(cubePosition.x);
				float absZ = Mathf.Abs(cubePosition.z);

				if(absX > maxWidth || cubePosition.y > _gameData.MaxFormSize.y || absZ > maxWidth)
                {
					print(absX);
					print(cubePosition.y);
					print(absZ);
					print(maxWidth);
					continue;
                }

				Instantiate(_cubePrefab, (cubePosition * _gameData.CubeSize) + _playerTransform.position, Quaternion.identity, _playerTransform);
            }
        }
	}
}