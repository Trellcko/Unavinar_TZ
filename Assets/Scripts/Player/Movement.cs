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


        private float _currentSpeedChange;
        private float _currentMaxSpeed;
        private Vector3 _direction = Vector3.left;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _currentSpeedChange = -_speedChange;
            ResetSpeed();
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_direction * _currentSpeedChange * Time.fixedDeltaTime, ForceMode.VelocityChange);

            if (_rigidbody.velocity.x > -_normalSpeed && _currentSpeedChange < 0)
            {
                _rigidbody.velocity = _normalSpeed * _direction;
            }
            else if(_rigidbody.velocity.x < -_currentMaxSpeed && _currentSpeedChange > 0)
            {
                _rigidbody.velocity = _direction * _currentMaxSpeed;
            }
        }

        public void SetSpeedToZero()
        {
            _currentMaxSpeed = 0;
            _normalSpeed = 0;
            _currentSpeedChange = _speedChange;
        }

        public void SpeedUp()
        {
            _currentMaxSpeed = _speedUp;
            _currentSpeedChange = _speedChange;
        }
        public void ResetSpeed()
        {
            _currentMaxSpeed = _normalSpeed;
            _currentSpeedChange = -_speedChange;
        }

        public void PushBack()
        {
            _rigidbody.velocity = -_direction * _pushModifier;
            _currentSpeedChange = _speedChange;
        }
    }
}