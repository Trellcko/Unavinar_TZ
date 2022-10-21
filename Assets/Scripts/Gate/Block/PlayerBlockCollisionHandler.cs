using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Gate.Block
{
	[AddComponentMenu("Gate Block(Player Block Collision Handler)")]
	public class PlayerBlockCollisionHandler : MonoBehaviour
	{
		[TagProperty]
		[SerializeField] private string _newTag;

		[SerializeField] private CollisionEvents _collisionEvents;

        private void OnEnable()
        {
            _collisionEvents.PlayerBlockCollided += OnPlayerBlockCollided;
        }

        private void OnDisable()
        {
            _collisionEvents.PlayerBlockCollided -= OnPlayerBlockCollided;
        }

        private void OnPlayerBlockCollided()
        {
            gameObject.tag = _newTag;
        }
    }
}