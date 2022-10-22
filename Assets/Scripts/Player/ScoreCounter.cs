using System;
using System.Collections;
using Trell.Unavinar_TZ.Core;
using Trell.Unavinar_TZ.UI;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private PopUpTextSpawner _popupSpawner;
        [SerializeField] private float _countSpeed = 0.5f;

        public event Action ChangedMultiplayer;

        public bool IsModifierBlocked { get; private set; } = false;

        private int _currentScore = 0;

        public int Modifier { get; private set; } = 1;

        private bool _isCounting = false;

        private void Start()
        {
            StartCoroutine(CountCorun());
        }

        public void TurnOnCounting()
        {
            _isCounting = true;
        }

        public void TurnOffCounting()
        {
            _isCounting = false;
        }

        public void BlockModifier()
        {
            Modifier = 1;
            IsModifierBlocked = true;
            ChangedMultiplayer?.Invoke();
        }

        public void UnBlockModifier()
        {
            IsModifierBlocked = false;
        }

        public void IncreaseModifier(int count)
        {
            Modifier += count;
            ChangedMultiplayer?.Invoke();
        }

        public void ResetModifier()
        {
            ChangedMultiplayer?.Invoke();
            Modifier = 1;
        }

        public void AddTempScore(int count)
        {
            int totoalCount = count * Modifier;
            _currentScore += totoalCount;
            _popupSpawner.PopUp("+" + totoalCount.ToString());
        }

        public void SaveScore()
        {
            _score.Add(_currentScore);
            _currentScore = 0;
        }

        private IEnumerator CountCorun()
        {
            WaitForSeconds waiter = new WaitForSeconds(_countSpeed);

            while (true)
            {
                if (_isCounting)
                {
                    AddTempScore(1);
                }
                yield return waiter;
            }
        }
    }
}