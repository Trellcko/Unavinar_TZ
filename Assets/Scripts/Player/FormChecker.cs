using System.Collections.Generic;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    public class FormChecker : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private LayerMask _playerBlockLayerMask;
        [SerializeField] private BlockContainer _blockContainer;

        public bool CheckForm()
        {
            for (int i = 0; i < _blockContainer.Count; i++)
            {
                Ray ray = new Ray(_blockContainer[i].transform.position, Vector3.left);

                if (Physics.Raycast(ray, _gameData.DistanceBetweenGates, _playerBlockLayerMask))
                {
                    Debug.DrawRay(_blockContainer[i].transform.position, Vector3.left * _gameData.DistanceBetweenGates, Color.red, 100f);

                    return false;
                }
            }
            return true;
        }
    }
}