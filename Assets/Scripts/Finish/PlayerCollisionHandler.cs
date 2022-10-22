using UnityEngine;

namespace Trell.Unavinar_TZ.Finish
{
	[AddComponentMenu("Finish(Player Collision Handler)")]
	public class PlayerCollisionHandler : MonoBehaviour
	{
		[SerializeField] private CollisionEvents _collisionEvents;
        [SerializeField] private ParticleSystem[] _particleSystem;

        private void OnEnable()
        {
            _collisionEvents.PlayerColided += OnPlayerColided;
        }

        private void OnDisable()
        {
            _collisionEvents.PlayerColided -= OnPlayerColided;
        }

        private void OnPlayerColided()
        {
            foreach(var particle in _particleSystem)
            {
                particle.Play();
            }
        }
    }
}