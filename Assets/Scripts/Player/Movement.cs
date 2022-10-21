using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    [RequireComponent(typeof(Rigidbody))]
	public class Movement : MonoBehaviour
	{
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private float _pushPower = 0.25f;

        private Vector3 _direction = Vector3.left;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_direction * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        public void PushBack()
        {
            _rigidbody.velocity = -_direction * _pushPower;
        }
    }
}