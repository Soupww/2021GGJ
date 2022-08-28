using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    int NMCount = 0;
    int NMSLCount = 0;
    public GameObject gameLostBoard;
    public GameObject gameSuccessBoard;
    public AudioClip successClip;
    public AudioClip failClip;
    private AudioSource audioSource;
    public static GameManager main;

    public GameObject niuniuHead;
    public GameObject mamaHead;
    public GameObject headHolder;
    public GameObject heartHolder;
    public GameObject crossImage;
    public GameObject heartImage;
    public Text timerText;
    private float timer = 30.0f;

    public Text successText;
    public int life = 4;

    List<GameObject> mamaheads = new List<GameObject>();
    List<GameObject> niuniuheads = new List<GameObject>();
    List<GameObject> hearts = new List<GameObject>();

    int niuniuCount = 0;
    int mamaCount = 0;

    private float mamaAnchorX = 450f;
    private float niuniuAnchorX = 50f;

    private float heartAnchorX = 50f;

    private Vector3 deltaPos = Vector3.zero;
    private float shakerTimer = 0.0f;

    private void Awake() {
        main = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        for(int i = 0; i < life; i++) {
            GameObject heart = Instantiate(heartImage, heartHolder.transform);
            heart.SetActive(true);
            heart.GetComponent<RectTransform>().anchoredPosition = new Vector3(heartAnchorX, 0, 0);
            heartAnchorX += 100f;
            hearts.Add(heart);
        }
    }

    public void AddMaMa() {
        mamaCount += 1;
        GameObject head = Instantiate(mamaHead, headHolder.transform);
        head.SetActive(true);
        head.GetComponent<RectTransform>().anchoredPosition = new Vector3(mamaAnchorX, 0, 0);
        mamaheads.Add(head);
        mamaAnchorX += 100f;
    }

    public void AddNiuNiu() {
        niuniuCount += 1;
        GameObject head = Instantiate(niuniuHead, headHolder.transform);
        head.SetActive(true);
        head.GetComponent<RectTransform>().anchoredPosition = new Vector3(niuniuAnchorX, 0, 0);
        niuniuheads.Add(head);
        niuniuAnchorX += 100f;
    }

    public void GameSuccess() {
            Time.timeScale = 0;
            gameSuccessBoard.SetActive(true);
            audioSource.clip = successClip;
            successText.text = mamaCount.ToString() + "匹马活了&" + niuniuCount.ToString() + "头牛活了！";
            audioSource.Play();
    }

    private void FixedUpdate() {
        if(shakerTimer > 0) {
            shakerTimer -= Time.fixedDeltaTime;
            transform.localPosition -= deltaPos;
            deltaPos = Random.insideUnitSphere / 3.0f;
            transform.localPosition += deltaPos;
        }
        timer -= Time.fixedDeltaTime;
        timerText.text = ((int)timer).ToString() + "s";
        if(timer < 0) GameSuccess();
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

    public void NMSL(bool niuniu) {
        if(niuniu) niuniuCount -= 1;
        else mamaCount -= 1;
        NMCount -= 1;
        NMSLCount += 1;
        hearts[life - NMSLCount].SetActive(false);
        if(niuniu) {
            GameObject head = niuniuheads[0];
            GameObject cross = Instantiate(crossImage, headHolder.transform);
            cross.SetActive(true);
            cross.GetComponent<RectTransform>().anchoredPosition = head.GetComponent<RectTransform>().anchoredPosition;
            niuniuheads.RemoveAt(0);
        } else {
            GameObject head = mamaheads[0];
            GameObject cross = Instantiate(crossImage, headHolder.transform);
            cross.SetActive(true);
            cross.GetComponent<RectTransform>().anchoredPosition = head.GetComponent<RectTransform>().anchoredPosition;
            mamaheads.RemoveAt(0);
        }
        if(NMSLCount >= life) {
            Debug.Log("Lost");
            Invoke("StopGame", 2.0f);
        }
        
    }

    public void Restart() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }

    private void StopGame() {
        Time.timeScale = 0;
        gameLostBoard.SetActive(true);
        audioSource.clip = failClip;
        audioSource.Play();
    }

    public void ShakeCamera() {
        shakerTimer = 1.0f;
    }
}
