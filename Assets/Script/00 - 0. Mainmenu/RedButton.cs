using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    MainManager mainManager;
    public Sprite press;
    public Sprite notPress;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        mainManager.enter = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return)) spriteRenderer.sprite = press;
        else spriteRenderer.sprite = notPress;
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && !mainManager.enter){
            mainManager.screenSelect = false;
            audioSource.Play();
            mainManager.enter = true;
        }
    }
}
