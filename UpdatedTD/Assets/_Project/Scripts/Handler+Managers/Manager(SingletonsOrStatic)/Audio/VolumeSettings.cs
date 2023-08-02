using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace UpdatedTD
{
    //TODO : Might have some quality of life issues here...
    //TODO : Add save system loading here somehow
    public class VolumeSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider musicSlider, sfxSlider;

        const string MIXER_MUSIC = "MusicVolume";
        const string MIXER_SFX = "SFXVolume";

        private void Awake()
        {
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat(GenericSoundManager.SoundManager.MUSIC_KEY, musicSlider.value);
            PlayerPrefs.SetFloat(GenericSoundManager.SoundManager.SFX_KEY, sfxSlider.value);
        }

        private void SetMusicVolume(float value)
        {
            mixer.SetFloat(MIXER_MUSIC, value);
        }

        private void SetSFXVolume(float value)
        {
            mixer.SetFloat(MIXER_SFX, value);
        }

        private void LoadVolume()
        {
            //TODO : Load player pref volume...
            float musicVolume = PlayerPrefs.GetFloat(GenericSoundManager.SoundManager.MUSIC_KEY, 1f);
            float sfxVolume = PlayerPrefs.GetFloat(GenericSoundManager.SoundManager.SFX_KEY, 1f);

            mixer.SetFloat(VolumeSettings.MIXER_MUSIC, musicVolume);
            mixer.SetFloat(VolumeSettings.MIXER_SFX, sfxVolume);
        }
    }
}
