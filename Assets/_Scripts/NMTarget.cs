using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMTarget : MonoBehaviour
{
    public float targetSurvivalTime = 30.0f;
    private AudioSource audioSource;
    public AudioClip deathAudioClip;

    public bool niuniu = true;

    private void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = deathAudioClip;
        audioSource.loop = false;
        if(niuniu) {
            GameManager.main.AddNiuNiu();
        }
        else {
            GameManager.main.AddMaMa();
        }
            
        Invoke("ReachTarget", targetSurvivalTime);
    }

    public void TriggerDeath() {
        audioSource.Play();
        CancelInvoke();
        GameManager.main.NMSL(niuniu);
        GameManager.main.ShakeCamera();
    }

    private void ReachTarget() {
        Destroy(gameObject);
    }
}
