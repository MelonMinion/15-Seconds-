using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    MinigameManager minigameManager;
    private void Awake() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        minigameManager = GameObject.Find("MinigameManager").GetComponent<MinigameManager>();
    }

    private void Start() {
        animator.SetTrigger("doActive");
    }
    
    void Whistle(){
        audioSource.volume = 0.5f / (minigameManager.lineIndex - 2);
        if(minigameManager.whistle) audioSource.Play();
    }
}
