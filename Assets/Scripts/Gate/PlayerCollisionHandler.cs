using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Gate
{
	[AddComponentMenu("Gate (Player Collision Handler)")]
	public class PlayerCollisionHandler : MonoBehaviour
	{
		[SerializeField] private CollisionEvents _collisionEvents;
        [SerializeField] private BlockContainer _blockContainer;

        private void OnEnable()
        {
            _collisionEvents.PlayerExited += OnPlayerExited;
        }

        private void OnDisable()
        {
            _collisionEvents.PlayerExited -= OnPlayerExited;
        }

        private void OnPlayerExited()
        {
            _blockContainer.PlayVisualEffects();
        }
    }
}