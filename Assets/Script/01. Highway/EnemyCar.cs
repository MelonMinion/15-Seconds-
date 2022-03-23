using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    MinigameManager minigameManager;
    public AudioClip windSound;
    public AudioClip carCrash;
    public float carSpeed;
    bool isWindSound = false;
    float timer = 0;

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        minigameManager = GameObject.Find("MinigameManager").GetComponent<MinigameManager>();
    }
    private void Update() {
        timer += Time.deltaTime; //타이머 실행

        //차 소리 재생
        if(timer > 0.6f){
            if(minigameManager.whistle){
                if(isWindSound == false){
                    audioSource.pitch = Time.timeScale + 0.2f;
                    audioSource.volume = 0.5f / (minigameManager.lineIndex - 2);
                    audioSource.Play();
                    isWindSound = true;
                }
            }
        }

        //차 이동
        if(timer > 1.3f){
            Vector3 curPos = transform.position;
            Vector3 nextPos = Vector3.down * carSpeed * Time.deltaTime;
            transform.position = curPos + nextPos;   
        }

    }

    private void OnTriggerEnter2D(Collider2D other) { 
        if(other.tag == "Player"){ //플레이어와 부딪혔을 때
            audioSource.PlayOneShot(carCrash, 1f);
            carSpeed = 0;
            animator.SetTrigger("doExplode");
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
