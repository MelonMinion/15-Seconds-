using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    MinigameManager minigameManager;
    AudioSource audioSource;
    Vector3 pos;
    public bool Crash = false;
    float minRoad;
    bool canMove = true;

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        minigameManager = GameObject.Find("MinigameManager").GetComponent<MinigameManager>();
    }

    private void Start() {
        //플레이어 시작 라인 선택
        if(minigameManager.lineIndex % 2 == 1) transform.position = new Vector3(0, 0, 0);
        else transform.position = new Vector3(-0.8f, 0, 0);
        minRoad = (((minigameManager.lineIndex + 1) * 0.8f) - (1.6f * (minigameManager.lineIndex)));
        
        audioSource.Play(); //오디오 재생
    }
    private void Update() {
        float h = Input.GetAxisRaw("Horizontal"); //왼쪽 오른쪽 구분
        pos = this.gameObject.transform.position; //현재 차 위치 확인

        //입력받은대로 차 이동
        if(Input.GetButtonDown("Horizontal") && canMove){
            if(h == -1)
                if(pos.x > minRoad + 0.1)
                    transform.Translate(new Vector3(-1.6f, 0, 0));
            if(h == 1)
                if(pos.x < minRoad * (-1) - 0.1)
                    transform.Translate(new Vector3(1.6f, 0, 0));
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){ //적과 부딪혔을 때
            animator.SetTrigger("doExplode");
            Crash = true;
            canMove = false;
            audioSource.Stop();
            minigameManager.isClear = false;
        }
    }

    void Disable(){
        spriteRenderer.enabled = false;
    }
}

