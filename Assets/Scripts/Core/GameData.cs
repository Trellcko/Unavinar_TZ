using UnityEngine;

namespace Trell.Unavinar_TZ.Core
{
	[CreateAssetMenu(menuName = "GameData", fileName = "new GameData", order = 41)]
	public class GameData : ScriptableObject
	{
		[field: SerializeField] public float CubeSize { get; private set; } = 0.2f;

		[field: SerializeField] public Vector2Int MaxFormSize { get; private set; } = new Vector2Int(7, 9);
	}
}