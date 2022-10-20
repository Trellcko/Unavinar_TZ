using UnityEngine;

namespace Trell
{
	public class Movement : MonoBehaviour
	{
		Rigidbody _rigidbody;

        Vector3 _speed = Vector3.left*0.5f;

        private bool _isPushingThisFrame = false;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _isPushingThisFrame = false;
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        public void PushBack()
        {
            if (_isPushingThisFrame == false)
            {
                _isPushingThisFrame = true;
                _rigidbody.velocity = Vector3.right * 0.5f;
            }
        }
    }
}