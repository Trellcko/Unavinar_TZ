using Trell.Unavinar_TZ.Core;
using UnityEngine;
using Trell.Unavinar_TZ.Player.Block;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player Initializer")]
	public class Initializer : MonoBehaviour
	{
		[SerializeField] private GameObject _cubePrefab;
		[SerializeField] private GameData _gameData;
		[SerializeField] private BlockContainer _blockContainer;
		[SerializeField] private Vector3[] _form;
		[SerializeField] private Transform _startPoint;
		

		private void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			int maxWidth = _gameData.MaxFormSize.x / 2;

			foreach (var cubePosition in _form)
			{
				float absX = Mathf.Abs(cubePosition.x);
				float absZ = Mathf.Abs(cubePosition.z);

				if (absX > maxWidth || cubePosition.y > _gameData.MaxFormSize.y || absZ > maxWidth)
				{
					continue;
				}

				GameObject block = Instantiate(_cubePrefab, (cubePosition * _gameData.CubeSize) + _startPoint.position, Quaternion.identity, _startPoint);
				_blockContainer.Add(block);
			}
		}
	}
}