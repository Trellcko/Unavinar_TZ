using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player (Gate Collision Handler)")]
	public class GateCollisionHandler : MonoBehaviour
	{
		[SerializeField] private CollisionEvents _collisionEvents;
		[SerializeField] private Movement _movement;
		[SerializeField] private BlockContainer _blockContainer;

        private void OnEnable()
        {
            _collisionEvents.GateExited += OnGateExited;
        }

        private void OnDisable()
        {
            _collisionEvents.GateExited -= OnGateExited;
        }

        private void OnGateExited()
        {
            _movement.ResetSpeed();
            _blockContainer.StopVisualEffects();
        }
    }
}