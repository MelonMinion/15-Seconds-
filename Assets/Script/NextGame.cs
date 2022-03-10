using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextGame : MonoBehaviour
{
    float waitingTime = 3;
    float timer = 0;
    int percent;
    void Start()
    {
        percent = Random.Range(1, 3);
        if(percent == 1){
            Time.timeScale += 0.1f;
            Debug.Log(Time.timeScale.ToString() + "배로 속도 업!");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > waitingTime){
            SceneManager.LoadScene("01.Highway");
        }
    }
}
