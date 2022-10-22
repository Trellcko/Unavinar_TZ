using System.Collections;
using TMPro;
using Trell.Unavinar_TZ.Player;
using UnityEngine;

namespace Trell.Unavinar_TZ.UI
{
    public class ModifierVisual : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _animationDuration = 0.5f;
        [SerializeField] private ScoreCounter _scoreCounter;
		private RectTransform _rectTransform;

		private string x = "x";

        private bool _isShowing = false;

        private Vector3 _hidePosition;
        private Vector3 _showPosition;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _hidePosition = _showPosition = _rectTransform.anchoredPosition;
            float hideX = _rectTransform.anchorMax.x * Screen.width * -1;
           _hidePosition.x = hideX;
        }

        private void OnEnable()
        {
            _scoreCounter.ChangedMultiplayer += OnChangedMultiplayer;
        }

        private void Start()
        {
            _rectTransform.anchoredPosition = _hidePosition;
        }

        private void OnDisable()
        {
            _scoreCounter.ChangedMultiplayer -= OnChangedMultiplayer;
        }

        public void SetText(int multiplayer)
        {
			_text.SetText(x+multiplayer.ToString());
			
        }
        public void Show()
        {
            StartCoroutine(AnimationCorun(_hidePosition, _showPosition));
            _isShowing = true;
        }
        public void Hide()
        {
            StartCoroutine(AnimationCorun(_showPosition, _hidePosition));
            _isShowing = false;
        }

        private IEnumerator AnimationCorun(Vector2 from, Vector2 to)
        {
            float duration = 0;
            while (duration < _animationDuration)
            {
                float percent = Mathf.Clamp01(duration / _animationDuration);

                _rectTransform.anchoredPosition = Vector2.Lerp(from, to, percent);
                duration += Time.deltaTime;
                yield return null;
            }
        }
        private void OnChangedMultiplayer()
        {
            if(_scoreCounter.Modifier <= 1 && _isShowing == true)
            {
                Hide();
            }
            else if(_isShowing == false && _scoreCounter.Modifier > 1)
            {
                SetText(_scoreCounter.Modifier);
                Show();
            }
        }

    }
}