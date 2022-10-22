using System.Collections;
using TMPro;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell
{
    public class ScoreVisual : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private float _animationDuration = 0.5f;

        private float _currentCount;

        private void OnEnable()
        {
            _score.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _score.Changed -= OnChanged;
        }

        private void OnChanged()
        {
            StartCoroutine(AnimateCorun());
        }

        private IEnumerator AnimateCorun()
        {
            float duration = 0;
            int count;
            do
            {
                float percent = Mathf.Clamp01(duration / _animationDuration);

                count = (int)Mathf.Lerp(_currentCount, _score.Value, percent);

                _textMeshPro.SetText(count.ToString());
                duration += Time.deltaTime;
                yield return null;
            }
            while (duration < _animationDuration);
            _currentCount = count;
        }
    }
}