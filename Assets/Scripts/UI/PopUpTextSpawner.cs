using TMPro;
using Trell.Unavinar_TZ.Core;
using UnityEngine;

namespace Trell.Unavinar_TZ.UI
{
	public class PopUpTextSpawner : MonoBehaviour
	{

		[SerializeField] private PopUpText _popUpText;
		[SerializeField] private Transform point;

		private Pool<PopUpText> _pool;

		private void Awake()
		{
			_pool = new Pool<PopUpText>(() => Instantiate(_popUpText, transform), x => x.gameObject.SetActive(false), x => x.gameObject.SetActive(true), 10);
		}

		public void PopUp(string text)
		{
			var spawnedText = _pool.Give();
			spawnedText.SetText(text);
			spawnedText.Animate(() => { _pool.Take(spawnedText); }, point);
		}
	}
}
