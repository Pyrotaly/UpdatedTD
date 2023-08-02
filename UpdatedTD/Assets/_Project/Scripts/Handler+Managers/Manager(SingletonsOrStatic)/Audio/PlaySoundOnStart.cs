using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericSoundManager
{
    public class PlaySoundOnStart : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;

        private void Start()
        {
            SoundManager.Instance.PlaySound(clip);
        }
    }
}
