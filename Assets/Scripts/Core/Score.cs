using System;
using UnityEngine;

namespace Trell.Unavinar_TZ.Core
{
	public class Score : MonoBehaviour
	{
        public event Action Changed;

        public int Value { get; private set; }

        public void Add(int value)
        {
            if (value <= 0)
            {
                return;
            }
            Value += value;
            Changed?.Invoke();
        }

        public void Reset()
        {
            Value = 0;
            Changed?.Invoke();
        }
    }
}