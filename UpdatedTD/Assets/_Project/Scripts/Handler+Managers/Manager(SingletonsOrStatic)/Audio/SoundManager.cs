using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GenericSoundManager
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private AudioSource musicSource, effectsSource;

        public const string MUSIC_KEY = "musicVolume";
        public const string SFX_KEY = "sfxVolume";

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);        
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void PlaySound(AudioClip clip)
        {
            effectsSource.PlayOneShot(clip);
        }

        public void ChangeMasterVolume()
        {

        }
    }
}
