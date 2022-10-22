using System.Collections.Generic;
using Trell.Unavinar_TZ.Gate.Block;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	[AddComponentMenu("Player (Gate Block Inner Collision Handler)")]
	public class GateBlockInnerCollsionHandler : MonoBehaviour
	{
        [SerializeField] private Movement _movement;
        [SerializeField] private BlockContainer _blockContainer;
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

        private void Start()
        {
            for (int i = 0; i < _blockContainer.Count; i++)
            {
                Block.CollisionEvents collisionEvents = _blockContainer[i].GetComponent<Block.CollisionEvents>();
                _collisionEvents.Add(collisionEvents);
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

      
        private void OnGateBlockInnerCollided(Vector3 normal, GameObject other)
        {
            if (other.TryGetComponent(out Pusher gateBlock))
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