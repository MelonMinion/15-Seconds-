using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;
    public int noCarLine = 0;
    public int gamePointLine = 0;
    public bool warningSet = false;
    public bool isClear = true;
    public GameObject warningPanel;
    public GameObject gamePointPanel;
    public GameObject enemyCar;
    public GameObject gamePoint;
    public GameObject road;
    public int lineIndex;
    float timer = 0f;
    int pointPercent;
    public bool timerActive = true;
    public bool whistle = false;
    bool panelSet = false;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start() {
        //랜덤 줄 수 선택
        int percent = Random.Range(1, 101);
        if(Time.timeScale == 1){
            lineIndex = 3;
        }
        else if(Time.timeScale == 1.1f){
            if(percent <= 90) lineIndex = 3;
            else lineIndex = 4;
        }
        else if(Time.timeScale == 1.2f){
            if(percent <= 80) lineIndex = 3;
            else if(percent <= 95) lineIndex = 4;
            else lineIndex = 5;
        }
        else if(Time.timeScale == 1.3f){
            if(percent <= 70) lineIndex = 3;
            else if(percent <= 90) lineIndex = 4;
            else lineIndex = 5;
        }
        else if(Time.timeScale == 1.4f){
            if(percent <= 60) lineIndex = 3;
            else if(percent <= 85) lineIndex = 4;
            else if(percent <= 95) lineIndex = 5;
            else lineIndex = 6;
        }
        else if(Time.timeScale == 1.5f){
            if(percent <= 50) lineIndex = 3;
            else if(percent <= 80) lineIndex = 4;
            else if(percent <= 90) lineIndex = 5;
            else lineIndex = 6;
        }
        else if(Time.timeScale == 1.6f){
            if(percent <= 40) lineIndex = 3;
            else if(percent <= 65) lineIndex = 4;
            else if(percent <= 80) lineIndex = 5;
            else if(percent <= 95) lineIndex = 6;
            else lineIndex = 7;
        }
        else if(Time.timeScale == 1.7f){
            if(percent <= 30) lineIndex = 3;
            else if(percent <= 50) lineIndex = 4;
            else if(percent <= 70) lineIndex = 5;
            else if(percent <= 90) lineIndex = 6;
            else lineIndex = 7;
        }
        else if(Time.timeScale == 1.8f){
            if(percent <= 20) lineIndex = 3;
            else if(percent <= 35) lineIndex = 4;
            else if(percent <= 60) lineIndex = 5;
            else if(percent <= 85) lineIndex = 6;
            else lineIndex = 7;
        }
        else if(Time.timeScale == 1.9f){
            if(percent <= 10) lineIndex = 3;
            else if(percent <= 20) lineIndex = 4;
            else if(percent <= 50) lineIndex = 5;
            else if(percent <= 80) lineIndex = 6;
            else lineIndex = 7;
        }
        else{
            if(percent <= 35) lineIndex = 5;
            else if(percent <= 70)lineIndex = 6;
            else lineIndex = 7;
        }

        //도로 생성
        road = GameObject.Find(lineIndex.ToString() + " Road");
        for(int i = 0; i < 3; i++)
            road.transform.GetChild(i).gameObject.SetActive(true);

        //차 없는 라인 선택
        noCarLine = Random.Range(1, lineIndex + 1);

        //게임 포인트 라인 선택
        pointPercent = Random.Range(1, 11);
        if(pointPercent <= 3){
            while(true){
                gamePointLine = Random.Range(1, lineIndex + 1);
                if(gamePointLine != noCarLine)  break;
            }
        }
    }   

    private void Update() {
        timer += Time.deltaTime; //타이머 실행

        //3초후 경고 사인
        if(timer > 3){
            whistle = true;
            if(!panelSet){
                panelSet = true;
                for(int i = 1; i < lineIndex + 1; i++){
                    if(i == gamePointLine){
                        GameObject obj = Instantiate(gamePointPanel, new Vector3(((lineIndex + 1) * 0.8f - (1.6f * ((lineIndex + 1) - i))), 0, 0), gamePointPanel.transform.rotation) as GameObject;
                        GameObject obj2 = Instantiate(gamePoint, new Vector3(((lineIndex + 1) * 0.8f - (1.6f * ((lineIndex + 1) - i))), 6.5f, 0), gamePoint.transform.rotation) as GameObject; 
                    }
                    else if(i != noCarLine){
                        GameObject obj = Instantiate(warningPanel, new Vector3(((lineIndex + 1) * 0.8f - (1.6f * ((lineIndex + 1) - i))), 0, 0), warningPanel.transform.rotation) as GameObject;
                        GameObject obj2 = Instantiate(enemyCar, new Vector3(((lineIndex + 1) * 0.8f - (1.6f * ((lineIndex + 1) - i))), 6.5f, 0), enemyCar.transform.rotation) as GameObject; 
                    }
                }  
            }
        }

        //게임 클리어 선언
        if(timer > 7){
            if(isClear){
                SceneManager.LoadScene("testCount");
            }
        }
    }
}
