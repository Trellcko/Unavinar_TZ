using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    public class FinishCollisionHandler : MonoBehaviour
	{
		[SerializeField] private CollisionEvents _collisionEvents;
        [SerializeField] private Movement _movement;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private DraginPanelHandler _draginPanelHandler;
        [SerializeField] private BlockContainer _blockContainer;
        [SerializeField] private int _scoreForFinish = 200;

        private void OnEnable()
        {
            _collisionEvents.Finished += OnFinished;
        }

        private void OnDisable()
        {
            _collisionEvents.Finished -= OnFinished;
        }

        private void OnFinished()
        {
            _draginPanelHandler.enabled = false;
            _blockContainer.StopVisualEffects();
            _movement.SetSpeedToZero();
            _scoreCounter.AddTempScore(_scoreForFinish);
            _scoreCounter.SaveScore();
            _scoreCounter.TurnOffCounting();
            
        }
    }
}