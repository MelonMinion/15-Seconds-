using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameOption : MonoBehaviour
{
    FullScreenMode screenMode;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenBtn;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public AudioMixer mixer;
    public Text bgmText;
    public Text sfxText;
    List<Resolution> resolutions = new List<Resolution>();
    public int resolutionNum;

    private void Start() 
    {
        bgmSlider.value = PlayerPrefs.GetFloat("Bgm", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("Sfx", 0.75f);
        bgmText.text = Mathf.FloorToInt(bgmSlider.value * 100).ToString();
        sfxText.text = Mathf.FloorToInt(sfxSlider.value * 100).ToString();
        InitUI();
    }

    private void Update() {
        if(Input.GetKeyDown("escape")) SceneManager.LoadScene("MainMenu");
    }
    void InitUI()
    {
        for(int i = 0; i < Screen.resolutions.Length; i++){
            if(Screen.resolutions[i].refreshRate == 60) resolutions.Add(Screen.resolutions[i]);
        }

        resolutionDropdown.options.Clear();

        int optionNum = 0;
        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + " x " + item.height;
            resolutionDropdown.options.Add(option);

            if(item.width == Screen.width && item.height == Screen.height) resolutionDropdown.value = optionNum;
            optionNum++;
        }

        resolutionNum = PlayerPrefs.GetInt("ResolutionNum", 21);
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);

        resolutionDropdown.RefreshShownValue();
        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
        PlayerPrefs.SetInt("ResolutionNum", resolutionNum);
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
    }

    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        resolutionNum = PlayerPrefs.GetInt("ResolutionNum", 21);
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
    }

    public void BackBtnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetBgmLevel(float sliderValue)
    {
        mixer.SetFloat("Bgm", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Bgm", sliderValue);
        bgmText.text = Mathf.FloorToInt(bgmSlider.value * 100).ToString();
    }

    public void SetSfxLevel(float sliderValue)
    {
        mixer.SetFloat("Sfx", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Sfx", sliderValue);
        sfxText.text = Mathf.FloorToInt(sfxSlider.value * 100).ToString();
    }
}
