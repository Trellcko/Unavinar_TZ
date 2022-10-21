using System.Collections.Generic;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	public class FormChecker : MonoBehaviour
	{
        [SerializeField] private GameData _gameData;
        [SerializeField] private LayerMask _playerBlockLayerMask;

		private List<Transform> _blocks =  new List<Transform>();
        private RaycastHit[] _hits =  new RaycastHit[1];

		public void AddBlock(Transform block)
        {
			_blocks.Add(block);
        }

		public void RemoveBlock(Transform block)
        {
			_blocks.Remove(block);
        }

		public bool CheckForm()
        {
            foreach (Transform block in _blocks)
            {
                Ray ray = new Ray(block.position, Vector3.left);

                if (Physics.Raycast(ray, _gameData.DistanceBetweenGates, _playerBlockLayerMask))
                {
                    Debug.DrawRay(block.position, Vector3.left * _gameData.DistanceBetweenGates, Color.red, 100f);

                    return false;
                }
            }
            return true;
        }
    }
}