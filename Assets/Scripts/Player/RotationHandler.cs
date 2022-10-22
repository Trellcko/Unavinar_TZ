using System.Collections.Generic;
using Trell.Unavinar_TZ.Core;
using Trell.Unavinar_TZ.UI;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    public class RotationHandler : MonoBehaviour
    {
        [SerializeField] private Rotater _rotater;
        [SerializeField] private FormChecker _formChecker;
        [SerializeField] private Movement _movement;
        [SerializeField] private BlockContainer _blockContainer;
        [SerializeField] private PopUpSpawner _spawner;

        private void OnEnable()
        {
            _rotater.RotationFixed += OnRotationFixed;
        }

        private void OnDisable()
        {
            _rotater.RotationFixed -= OnRotationFixed;
        }

        private void OnRotationFixed()
        {
            if (_formChecker.CheckForm())
            {
                _movement.SpeedUp();
                _blockContainer.PlayVisualEffects();
                _spawner.PopUp("+1");
                return;
            }
            _blockContainer.StopVisualEffects();
            _movement.ResetSpeed();
        }
    }
}