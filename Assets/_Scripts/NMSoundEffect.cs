using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMSoundEffect : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    public float baseInterval = 10f;
    private void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = false;
        Invoke("NormalVoice", Random.Range(baseInterval, baseInterval * 1.5f));
    }

    private void NormalVoice() {
        audioSource.Play();
        Invoke("NormalVoice", Random.Range(baseInterval,baseInterval * 1.5f));
    }
}
