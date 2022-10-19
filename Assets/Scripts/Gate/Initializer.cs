using System;
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

		[Min(1)]
		[SerializeField] private float _distanceBetweenGates = 10f;

		[NonReorderable]
		[SerializeField] private List<GateData> _gateData;
		private void Awake()
        {
			Initialize();
        }

        private void Initialize()
        {
			int maxX = _gameData.MaxFormSize.x / 2;
			int maxY = _gameData.MaxFormSize.y;

			foreach (var gateData in _gateData)
			{
				for (int x = -maxX; x <= maxX; x++)
				{
					for (int y = 0; y <= maxY; y++)
					{
						GameObject block = _innerBlock;
						Vector3 position = new Vector3(0, y, x);

						if (x == -maxX || x == maxX || y == maxY)
						{
							block = _outerBlock;
						}

						else if(gateData.EmptyBlocks.Contains(position))
                        {
							continue;
                        }

						Instantiate(block, new Vector3(0, y, x) * _gameData.CubeSize, Quaternion.identity);
					}
				}
			}
		}
    }

	[Serializable]
	public class GateData
    {
		[field: SerializeField] public List<Vector3> EmptyBlocks;
    }
}