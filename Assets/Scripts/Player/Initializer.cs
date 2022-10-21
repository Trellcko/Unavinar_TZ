using Trell.Unavinar_TZ.Core;
using UnityEngine;
using Trell.Unavinar_TZ.Player.Block;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player Initializer")]
	public class Initializer : MonoBehaviour
	{
		[SerializeField] private CollisionEvents _cubePrefab;
		[SerializeField] private GameData _gameData;
		[SerializeField] private Player.GateBlockInnerCollsionHandler _playerCollisionHandler;
		[SerializeField] private Vector3[] _form;

		private Transform _platerTransform;

		private void Awake()
        {
			_platerTransform = _playerCollisionHandler.transform;
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
					continue;
                }

			 CollisionEvents collisionEvents =	Instantiate(_cubePrefab, (cubePosition * _gameData.CubeSize) + _platerTransform.position, Quaternion.identity, _platerTransform);

			_playerCollisionHandler.AddCollisionEvents(collisionEvents);
			}
        }
	}
}