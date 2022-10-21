using UnityEngine;

namespace Trell.Unavinar_TZ.Gate.Block
{
    [RequireComponent(typeof(Rigidbody))]
	public class Pusher : MonoBehaviour
	{
        private Rigidbody _rigibody;

        public bool WasPushed { get; private set; }

        private void Awake()
        {
            _rigibody = GetComponent<Rigidbody>();
        }

        public void Push(Vector3 force)
        {
            _rigibody.isKinematic = false;
            _rigibody.useGravity = true;
            _rigibody.AddForce(force, ForceMode.VelocityChange);
            WasPushed = true;
        }
	}
}