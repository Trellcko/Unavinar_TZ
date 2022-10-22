using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    [AddComponentMenu("Player (Gate Collision Handler)")]
	public class GateCollisionHandler : MonoBehaviour
	{
		[SerializeField] private CollisionEvents _collisionEvents;
		[SerializeField] private Movement _movement;
        [SerializeField] private ScoreCounter _scoreCounter;
		[SerializeField] private BlockContainer _blockContainer;
        [SerializeField] private int _scoreForGate;
        [SerializeField] private int _addValueModifier;

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
            _scoreCounter.TurnOffCounting();
            _movement.ResetSpeed();
            _blockContainer.StopVisualEffects();
            _scoreCounter.SaveScore();

            if(_scoreCounter.IsModifierBlocked == false)
            {
                _scoreCounter.AddTempScore(_scoreForGate);
                _scoreCounter.IncreaseModifier(_addValueModifier);
            }
            _scoreCounter.UnBlockModifier();
        }
    }
}