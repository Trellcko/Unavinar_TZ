using System;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player.Block
{
    [AddComponentMenu("Player Block (Collision Events)")]
	public class CollisionEvents : MonoBehaviour
	{
		[TagProperty]
		[SerializeField] private string _gateBlockInnerTag;

        public event Action<Vector3, GameObject> GateBlockInnerCollided;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_gateBlockInnerTag))
            {
                GateBlockInnerCollided?.Invoke(transform.position - other.ClosestPoint(transform.position), other.gameObject);
            }
        }
    }
}