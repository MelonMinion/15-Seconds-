using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject gameManager;

    void Awake() {
        gameManager = GameObject.Find("GameManager");
    }

    private void Update() {
        DontDestroyOnLoad(gameManager);
    }
}
