using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public GameObject loadingScreen;
    public GameObject menuScreen;
    public GameObject optionsScreen;
    public GameObject soundSettings;
    public GameObject qualitySettings;
    public Slider soundSlider;


    AsyncOperation currentLoading;

	// Use this for initialization
	void Start () {
        menuScreen.SetActive(true);
        loadingScreen.SetActive(false);
        optionsScreen.SetActive(false);
        soundSettings.SetActive(false);
        qualitySettings.SetActive(false);
        currentLoading = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        currentLoading = SceneManager.LoadSceneAsync("Village");
        if (currentLoading.isDone)
        {
            SceneManager.UnloadSceneAsync("Main Menu");
            currentLoading = null;
            SceneManager.LoadScene("Village", LoadSceneMode.Single);
        }
        else
        {
            loadingScreen.SetActive(true);
        }
    }

    public void Options()
    {
        menuScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void Back()
    {
        menuScreen.SetActive(true);
        optionsScreen.SetActive(false);
        soundSettings.SetActive(false);
        qualitySettings.SetActive(false);
    }

    public void BackToOptions()
    {
        optionsScreen.SetActive(true);
        soundSettings.SetActive(false);
        qualitySettings.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SoundMenu()
    {
        optionsScreen.SetActive(false);
        soundSettings.SetActive(true);
    }

    public void QualityMenu()
    {
        optionsScreen.SetActive(false);
        qualitySettings.SetActive(true);
    }

    public void OnValueChangedSound()
    {
        AudioListener.volume = soundSlider.value;
        PlayerPrefs.SetFloat("Sound Volume", AudioListener.volume);
    }

    public void HighQuality()
    {
        QualitySettings.SetQualityLevel(5);
    }

    public void AverageQuality()
    {
        QualitySettings.SetQualityLevel(2);
    }

    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0);
    }
}
