using System;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player (Collision Events)")]
	public class CollisionEvents : MonoBehaviour
	{
		[TagProperty]
		[SerializeField] private string _gateTag;

        public event Action GateExited;

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag(_gateTag))
            {
                GateExited?.Invoke();
            }
        }
    }
}