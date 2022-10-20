using System.Collections.Generic;
using UnityEngine;

namespace Trell.Unavinar_TZ.Gate
{
	[AddComponentMenu("Gate Block")]
	public class GateBlock : MonoBehaviour
	{
        [SerializeField] private Rigidbody _rg;

        private bool isInteractable = true;

        public void AddForce(Vector3 force)
        {
            if (isInteractable)
            {
                isInteractable = false;
                _rg.isKinematic = false;
                _rg.useGravity = true;
                _rg.AddForce(force, ForceMode.VelocityChange);
            }
        }
	}
}