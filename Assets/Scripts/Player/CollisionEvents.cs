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

        [TagProperty]
        [SerializeField] private string _finishTag;

        public event Action GateExited;
        public event Action Finished;

        private Collider _previousCollider;
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(_finishTag))
            {
                if (_previousCollider != other)
                {
                    Finished?.Invoke();
                    _previousCollider = other;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_gateTag))
            {
                if (_previousCollider != other)
                {
                    print("|Player| " + other.name);
                    GateExited?.Invoke();
                    _previousCollider = other;
                }
            }
        }
    }
}