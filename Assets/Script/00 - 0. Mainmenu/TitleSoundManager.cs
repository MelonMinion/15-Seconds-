using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundManager : MonoBehaviour
{
    GameObject TitleBackgroundMusic;
    public AudioSource titleAudioSource;

    void Awake()
    {
        TitleBackgroundMusic = GameObject.Find("TitleSoundManager");
        titleAudioSource = TitleBackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장
        if (titleAudioSource.isPlaying){
            Debug.Log("재생중인데~");
            return; //배경음악이 재생되고 있다면 패스
        }
        else
        { 
            titleAudioSource.pitch = 1;
            titleAudioSource.Play();
            DontDestroyOnLoad(TitleBackgroundMusic); //배경음악 계속 재생하게
        }
    }
}