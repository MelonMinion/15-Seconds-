using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoint : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    public float pointSpeed;
    float getPointSpeed = 2;
    float timer = 0;
    bool getPoint = false;

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        timer += Time.deltaTime;

        if(timer > 1.3f){
            Vector3 curPos = transform.position;
            Vector3 nextPos = Vector3.down * pointSpeed * Time.deltaTime;
            transform.position = curPos + nextPos;   
        }    

        if(getPoint){
            Vector3 curPos = transform.position;
            Vector3 nextPos = Vector3.up * getPointSpeed * Time.deltaTime;
            transform.position = curPos + nextPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            pointSpeed = 0;
            animator.SetTrigger("getPoint");
            getPoint = true;
            audioSource.Play();
        }
    }

    void Stop(){
        getPointSpeed = 0;
    }

    void Disable(){
        spriteRenderer.enabled = false;
    }
}
