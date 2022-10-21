using System;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Gate.Block
{
	[AddComponentMenu("Gate Block(Collsion Events)")]
	public class CollisionEvents : MonoBehaviour
	{
		[TagProperty]
		[SerializeField] private string _playerBlockTag;

		public event Action PlayerBlockCollided;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(_playerBlockTag))
            {
                PlayerBlockCollided?.Invoke();
            }
        }
    }
}