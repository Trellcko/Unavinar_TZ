using System;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Finish
{

	[AddComponentMenu("Finish (Collision Events)")]
	public class CollisionEvents : MonoBehaviour
	{
		[TagProperty]
		[SerializeField] private string _playerTag;

        public event Action PlayerColided;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(_playerTag))
            {
                PlayerColided?.Invoke();
            }
        }
    }
}