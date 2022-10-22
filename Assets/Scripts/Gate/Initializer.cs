using System.Collections.Generic;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Gate
{
    [AddComponentMenu("Gates Initializer")]
	public class Initializer : MonoBehaviour
	{
		[SerializeField] private GameData _gameData;
		[SerializeField] private GameObject _innerBlock;
		[SerializeField] private GameObject _outerBlock;
        [SerializeField] private BlockContainer _blockContainer;

		[SerializeField] private Transform _startPoint;
		[SerializeField] private Transform _gamePlay;
        

		[NonReorderable]
		[SerializeField] private List<GateData> _gateData;
		private void Awake()
        {
			Initialize();
        }

        private void Initialize()
        {
			int maxz = _gameData.MaxFormSize.x / 2;
			int maxY = _gameData.MaxFormSize.y;

			for(int  i = 0; i < _gateData.Count; i++)
            {
                BlockContainer gate = SpawnGate(i);

                for (int z = -maxz; z <= maxz; z++)
                {
                    for (int y = 0; y <= maxY; y++)
                    {
                        Vector3 position = new Vector3(0, y, z);

                        if (_gateData[i].EmptyBlocks.Contains(position))
                        {
                            continue;
                        }

                        position += gate.transform.position;
                        gate.Add(SpawnBlock(maxz, maxY, gate.transform, position));
                    }
                }
            }
        }

        private GameObject SpawnBlock(int maxz, int maxY, Transform parent, Vector3 position)
        {
            GameObject block = _innerBlock;

            if (position.z == -maxz || position.z == maxz || position.y == maxY)
            {
                block = _outerBlock;
            }

            Vector3 spawnPosition = new Vector3(position.x, position.y * _gameData.CubeSize, position.z * _gameData.CubeSize);

            return Instantiate(block, spawnPosition, Quaternion.identity, parent);
        }

        private BlockContainer SpawnGate(int i)
        {
            Vector3 spawnPosition = new Vector3(_startPoint.position.x - _gameData.DistanceBetweenGates * (i + 1), 0, 0);

            return Instantiate(_blockContainer, spawnPosition, Quaternion.identity, _gamePlay);
        }
    }
}