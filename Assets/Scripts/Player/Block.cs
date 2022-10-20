using Trell.Unavinar_TZ.Gate;
using UnityEngine;

namespace Trell
{
	public class Block : MonoBehaviour
	{
        private void OnTriggerEnter(Collider other)
        {
            
            if(other.gameObject.CompareTag("Player"))
            {
                var collisionPoint = other.ClosestPoint(transform.position);
                Vector3 normal = transform.position - collisionPoint;

                other.gameObject.GetComponent<GateBlock>().AddForce(-normal * 100);
                GetComponentInParent<Movement>().PushBack();
            }
        }
    }
}