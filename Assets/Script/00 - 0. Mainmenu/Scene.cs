using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    MainManager mainManager;
    int recentScreen = 1;
    int toGo;
    Vector3 destination;
    Vector3 goalPos;
    private void Awake() {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    private void OnEnable() {
        transform.position = new Vector3((10.8f - 10.8f * mainManager.screenValue), 0, 0);
    }

    private void Update() 
    {
        toGo = recentScreen - mainManager.screenValue;

        if(toGo != 0){
            goalPos = new Vector3((10.8f - 10.8f * mainManager.screenValue), 0, 0);
            SetDestination(goalPos);
            recentScreen = mainManager.screenValue;
            toGo = 0;
        }

        Move();
    }

    void SetDestination(Vector3 dest)
    {
        destination = dest;
        mainManager.isMove = true;
    }

    void Move()
    {
        if(mainManager.isMove){
            var dir = destination - transform.position;
            transform.position += dir.normalized * Time.deltaTime * 30f;
        }

        if(Vector3.Distance(transform.position, destination) <= 1f)
        {
            if(mainManager.screenValue == 9) mainManager.screenValue = 1;
            else if(mainManager.screenValue == 0) mainManager.screenValue = 8;
            transform.position = new Vector3((10.8f - 10.8f * mainManager.screenValue), 0, 0);
            mainManager.isMove = false;
        }
    }
}
