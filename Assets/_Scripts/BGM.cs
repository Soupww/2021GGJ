using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip bgm;
    private AudioSource source;

    private void Start() {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = bgm;
        source.loop = true;
        source.Play();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) { //按下ESC键则退出游戏
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }
    }
}
