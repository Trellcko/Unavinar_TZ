using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    [RequireComponent(typeof(Rigidbody))]
	public class Movement : MonoBehaviour
	{
        [Min(0.1f)]
        [SerializeField] private float _speed = 0.5f;
        [Min(1)]
        [SerializeField] private float _speedUpModifier = 1.5f;
        [Min(0.1f)]
        [SerializeField] private float _pushPower = 0.25f;

        private float _currentSpeed;
        private Vector3 _direction = Vector3.left;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            ResetSpeed();
        }

        private void FixedUpdate()
        {
            print(_currentSpeed);
            
            _rigidbody.AddForce(_direction * _currentSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        public void SpeedUp()
        {
            _currentSpeed = _speed * _speedUpModifier;
        }
        public void ResetSpeed()
        {
            _rigidbody.velocity = _speed * _direction;
            _currentSpeed = _speed;
        }

        public void PushBack()
        {
            _rigidbody.velocity = -_direction * _pushPower;
            _currentSpeed = _speed;
        }
    }
}