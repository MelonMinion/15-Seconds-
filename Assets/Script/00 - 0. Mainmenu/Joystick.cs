using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    float h, v;
    Animator animator;
    MainManager mainManager;
    AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        animator = GetComponent<Animator>();
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(v == 0) h = Input.GetAxisRaw("Horizontal");
        if(h == 0) v = Input.GetAxisRaw("Vertical");

        if(animator.GetBool("Center") && !mainManager.isMove && !mainManager.enter){
            if(v == -1) animator.SetTrigger("Front");
            else if(v == 1) animator.SetTrigger("Back");
            else if(h == -1){
                animator.SetTrigger("Left");
                audioSource.PlayOneShot(clip);
                if(mainManager.screenSelect) mainManager.screenValue--;
            }
            else if(h == 1) {
                animator.SetTrigger("Right");
                audioSource.PlayOneShot(clip);
                if(mainManager.screenSelect) mainManager.screenValue++;
            }
            animator.SetBool("Center", false);
        }

        if(v == 0 && h == 0 && !animator.GetBool("Center")){
            animator.SetBool("Center", true);
        }

    }
}
