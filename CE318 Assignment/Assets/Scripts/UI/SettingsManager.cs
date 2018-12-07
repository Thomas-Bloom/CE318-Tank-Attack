using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {
    public Toggle musicToggle;
    public Slider volumeSlider;
    public Dropdown difficultyDropdown;
    public SaveLoadManager saveLoad;

    public AudioMixer mainMixer;

    private void Awake() {
        saveLoad = FindObjectOfType<SaveLoadManager>();

        if(SceneManager.GetActiveScene().buildIndex == 0)
            difficultyDropdown.value = saveLoad.difficultyNum;
    }

    private void Update() {
        saveLoad = FindObjectOfType<SaveLoadManager>();
    }

    public void SetVolume(float amount) {
        mainMixer.SetFloat("Volume", amount);
    }

    public void ToggleMusic(bool musicBool) {
        if(musicBool == false) {
            mainMixer.SetFloat("Music Volume", -80);
        }
        else {
            mainMixer.SetFloat("Music Volume", 0);
        }
    }

    public void LoadButton() {
        saveLoad.LoadGameLevel();
        saveLoad.LoadGameDifficulty();
    }

    public void SaveDifficulty() {
        saveLoad.SaveDifficulty();
    }
	
}
