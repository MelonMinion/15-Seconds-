using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    GameObject BackgroundMusic;
    MinigameManager minigameManager;
    public AudioSource audioSource;

    void Awake()
    {
        minigameManager = GameObject.Find("MinigameManager").GetComponent<MinigameManager>();
        BackgroundMusic = GameObject.Find("SoundManager");
        audioSource = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (audioSource.isPlaying) return; //배경음악이 재생되고 있다면 패스
        else
        { 
            audioSource.pitch = 1;
            audioSource.Play();
            DontDestroyOnLoad(BackgroundMusic); //배경음악 계속 재생하게(이후 버튼매니저에서 조작)
        }
    }

    private void Update() {
        audioSource.pitch = ((Time.timeScale - 1) / 2) + 1;

        if(!minigameManager.isClear) audioSource.pitch = 1;
    }
}