using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainManager : MonoBehaviour
{
    public int screenValue;
    public bool screenSelect = true;
    GameObject scene;
    GameObject nowScene;
    public GameObject blackScreen;
    GameObject blackScene;
    float timer;
    public bool isMove = false;
    public bool enter;
    SpriteRenderer spriteRenderer;
    public Animator sceneAnimator;
    public Animator blackAnimator;
    public AudioMixer mixer;
    float volumeValue;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        screenValue = 1;
        
        volumeValue = PlayerPrefs.GetFloat("Bgm", 0.75f);
        mixer.SetFloat("Bgm", Mathf.Log10(volumeValue) * 20);
        volumeValue = PlayerPrefs.GetFloat("Sfx", 0.75f);
        mixer.SetFloat("Sfx", Mathf.Log10(volumeValue) * 20);
    }

    private void Update() {
        if(screenValue > 9) screenValue = 9;
        else if(screenValue < 0) screenValue = 0;

        if(!screenSelect){
            timer = 0;
            scene = GameObject.Find("Scene");
            blackScreen = GameObject.Find("BlackScreen");
            Debug.Log(scene + " 찾음! " + blackScreen + " 찾음! ");
            nowScene = scene.transform.GetChild(screenValue).gameObject;
            nowScene.SetActive(true);
            sceneAnimator = nowScene.GetComponent<Animator>();
            nowScene.transform.position = new Vector3(nowScene.transform.position.x, nowScene.transform.position.y, -4);
            sceneAnimator.SetTrigger("Expand");
            for(int i = 0; i < 2; i++){
                blackScene = blackScreen.transform.GetChild(i).gameObject;
                blackAnimator = blackScene.GetComponent<Animator>();
                blackAnimator.SetTrigger("In");
            }
            screenSelect = true;
        }
        
        if(sceneAnimator != null){
            timer += Time.deltaTime;
            if(timer > 2){
                SceneChange();
            }
        }
    }

    void SceneChange(){
        DontDestroyOnLoad(this);
        if(screenValue == 1){

        }
        else if(screenValue == 2){

        }
        else if(screenValue == 3){

        }
        else if(screenValue == 4){

        }
        else if(screenValue == 5){

        }
        else if(screenValue == 6){

        }
        else if(screenValue == 7){
            SceneManager.LoadScene("Setting");
        }
        else if(screenValue == 8){
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
