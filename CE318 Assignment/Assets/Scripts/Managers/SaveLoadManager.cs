using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
class Data {
    public int levelIndex;
    public int difficulty;
}

public class SaveLoadManager : MonoBehaviour {
    public static SaveLoadManager saveLoad;
    public int levelIndex;
    public int difficultyNum;

    public Dropdown difficultyDropdown;

    public enum DifficultyLevel {
        EASYMODE,
        NORMALMODE,
        HARDMODE
    }

    public DifficultyLevel difficultyLevel;

    private void Awake() {
        if (saveLoad == null) {
            DontDestroyOnLoad(gameObject);
            saveLoad = this;
        }
        else if (saveLoad != this) {
            Destroy(gameObject);
        }
 
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            difficultyDropdown = FindObjectOfType<Dropdown>();

            difficultyDropdown.value = difficultyNum;
        }
    }

    private void Update() {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            difficultyDropdown = FindObjectOfType<Dropdown>();
        }
    }

    public void SaveLevelNum() {
        string fileName = Application.persistentDataPath + "/savenumber.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(fileName, FileMode.OpenOrCreate);

        Data data = new Data();
        data.levelIndex = SceneManager.GetActiveScene().buildIndex;

        bf.Serialize(file, data);
        file.Close();

        print("Saved data to file: " + file.Name);
    }

    public void SaveDifficulty() {
        string fileName = Application.persistentDataPath + "/savedifficulty.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(fileName, FileMode.OpenOrCreate);

        Data data = new Data();
        data.difficulty = difficultyNum;

        bf.Serialize(file, data);
        file.Close();

        print("Saved data to file: " + file.Name);
    }

    public void LoadGameLevel() {
        string fileName = Application.persistentDataPath + "/savenumber.dat";

        if (File.Exists(fileName)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileName, FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();

            levelIndex = data.levelIndex;

            print("Loaded data from file: " + file.Name);

            SceneManager.LoadScene(levelIndex);
        }
    }

    public void LoadGameDifficulty() {
        string fileName = Application.persistentDataPath + "/savedifficulty.dat";

        if (File.Exists(fileName)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileName, FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();

            difficultyNum = data.difficulty;
        }
    }

    public void ChangeDifficulty(int num) {
        switch (num) {
            case 0:
                difficultyLevel = DifficultyLevel.EASYMODE;
                difficultyNum = 0;
                break;
            case 1:
                difficultyLevel = DifficultyLevel.NORMALMODE;
                difficultyNum = 1;
                break;
            case 2:
                difficultyLevel = DifficultyLevel.HARDMODE;
                difficultyNum = 2;
                break;
        }
    }

}
