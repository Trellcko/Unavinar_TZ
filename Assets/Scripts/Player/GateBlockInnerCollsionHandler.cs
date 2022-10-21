using System.Collections.Generic;
using Trell.Unavinar_TZ.Gate.Block;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player (Gate Block Inner Collision Handler)")]
	public class GateBlockInnerCollsionHandler : MonoBehaviour
	{
        [SerializeField] private Movement _movement;
        [SerializeField] private float _pushBlockPower;

        private bool _isPushedThisFrame = false;

        private List<Block.CollisionEvents> _collisionEvents = new List<Block.CollisionEvents>();

        private void OnEnable()
        {
            foreach(var collisionEvents in _collisionEvents)
            {
                collisionEvents.GateBlockInnerCollided += OnGateBlockInnerCollided;
            }
        }

        private void OnDisable()
        {
            foreach (var collisionEvents in _collisionEvents)
            {
                collisionEvents.GateBlockInnerCollided -= OnGateBlockInnerCollided;
            }
        }

        private void Update()
        {
            _isPushedThisFrame = false;
        }

        public void AddCollisionEvents(Block.CollisionEvents collisionEvent)
        {
            _collisionEvents.Add(collisionEvent);
            collisionEvent.GateBlockInnerCollided += OnGateBlockInnerCollided;
        }

        public void RemoveEvent(Block.CollisionEvents collisionEvent)
        {
            _collisionEvents.Remove(collisionEvent);
            collisionEvent.GateBlockInnerCollided -= OnGateBlockInnerCollided;
        }

        private void OnGateBlockInnerCollided(Vector3 normal, GameObject other)
        {
            if (other.TryGetComponent(out Gate.Block.Pusher gateBlock))
            {
                if (gateBlock.WasPushed == false)
                {
                    gateBlock.Push(-normal * _pushBlockPower);

                    if (_isPushedThisFrame == false)
                    {
                        _movement.PushBack();
                        _isPushedThisFrame = true;
                    }
                }
            }
        }
    }
}