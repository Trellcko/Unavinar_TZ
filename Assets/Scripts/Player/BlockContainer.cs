using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trell.Unavinar_TZ.Player
{
	public class BlockContainer : MonoBehaviour
	{
        public int Count => _blocks.Count;
     
        private List<GameObject> _blocks = new List<GameObject>();

        private List<ParticleSystem> _blocksParticles = new List<ParticleSystem>();

        private bool _isPlaying;

        public GameObject this[int index]
        {
            get { return _blocks[index]; }
        }

        public void PlayVisualEffects()
        { 
            foreach(var particle in _blocksParticles)
            {
                particle.Play();
            }
            _isPlaying = true;
        }

        public void StopVisualEffects()
        {
            if (_isPlaying)
            {
                foreach (var particle in _blocksParticles)
                {
                    particle.Stop();
                }
                _isPlaying = false;
            }
        }

        public void Add(GameObject block)
        {
            _blocks.Add(block);
            _blocksParticles.Add(block.GetComponentInChildren<ParticleSystem>());
        }

        public void Remove(GameObject block)
        {
            int index = _blocks.IndexOf(block);
            _blocks.RemoveAt(index);
            _blocksParticles.RemoveAt(index);
        }
    }
}