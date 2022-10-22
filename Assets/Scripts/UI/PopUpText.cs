using System;
using System.Collections;
using TMPro;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.UI
{
    public class PopUpText : MonoBehaviour, IPoolable
    {
        [SerializeField] private TextMeshPro _textMeshPro;
        [SerializeField] private MeshRenderer _meshRenderer;


        [SerializeField] private int _sortingOrder;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _yEndValue;

        private Transform _cameraTransform;

        private void Awake()
        {
            _cameraTransform = Camera.main.transform;
            _meshRenderer.sortingOrder = _sortingOrder;
        }

        public void SetText(string text)
        {
            _textMeshPro.SetText(text);
        }

        public void SetColor(Color color)
        {
            _textMeshPro.color = color;
        }

        public void Animate(Action completed, Transform startPoint)
        {
            transform.position = startPoint.position;
            StartCoroutine(AnimateCorun(completed, startPoint));

        }

        private IEnumerator AnimateCorun(Action completed, Transform startPoint)
        {
            float duration = 0;
            float startY = transform.position.y;
            while(duration < _animationDuration)
            {
                
                float percent = Mathf.Clamp01(duration / _animationDuration);
                
                float y = Mathf.Lerp(startY, _yEndValue, percent);
                float alpha = Mathf.Lerp(1, 0, percent);



                transform.LookAt(_cameraTransform.position);
                transform.position = new Vector3(startPoint.position.x, y, startPoint.position.z);

                Color color = _textMeshPro.color;
                color.a = alpha;
                _textMeshPro.color = color;

                duration += Time.deltaTime;
                yield return null;
            }
            completed?.Invoke();

        }
    }
}
