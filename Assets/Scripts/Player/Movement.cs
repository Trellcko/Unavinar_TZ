using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    [RequireComponent(typeof(Rigidbody))]
	public class Movement : MonoBehaviour
	{
        [Min(0.1f)]
        [SerializeField] private float _normalSpeed = 0.5f;
        [Min(1)]
        [SerializeField] private float _speedUp = 1.5f;
        [Min(0.1f)]
        [SerializeField] private float _speedChange = 1f;
        [Min(0.1f)]
        [SerializeField] private float _pushModifier = 0.25f;

        private float _currentMaxSpeed;
        private Vector3 _direction = Vector3.left;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            ResetSpeed();
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_direction * _speedChange * Time.fixedDeltaTime, ForceMode.VelocityChange);
            if(_rigidbody.velocity.magnitude > _currentMaxSpeed)
            {
                _rigidbody.velocity = _direction * _currentMaxSpeed;
            }
        }

        public void SpeedUp()
        {
            _currentMaxSpeed = _speedUp;
        }
        public void ResetSpeed()
        {
            _currentMaxSpeed = _normalSpeed;
        }

        public void PushBack()
        {
            _rigidbody.velocity = -_direction * _pushModifier;
        }
    }
}