using System;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Gate
{
	[AddComponentMenu("Gate (Collision Events)")]
	public class CollisionEvents : MonoBehaviour
	{
		[TagProperty]
		[SerializeField] private string _playerTag;

		public event Action PlayerExited;

        public void OnTriggerExit(Collider other)
        {
            if(other.CompareTag(_playerTag))
            {
                print("eXITED");
                PlayerExited?.Invoke();
            }
        }
    }
}