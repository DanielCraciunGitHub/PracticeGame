using UnityEngine;

namespace GameFlow
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioSource[] _audioSources;
        private static AudioClip _bulletSound;
        private static AudioClip _orbSound;

        private void Start() 
        {
            _audioSources = GetComponents<AudioSource>();
            _bulletSound = _audioSources[0].clip;
            _orbSound = _audioSources[1].clip;

        }
        public static void PlayLaserSound()
        {
            _audioSources[0].PlayOneShot(_bulletSound);
        }
        public static void PlayOrbSound()
        {
            _audioSources[1].PlayOneShot(_orbSound);
        }
    }
}