using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneButtonPair
{
    public Button button;
    public string sceneName;
}

public class SceneManagerScript : MonoBehaviour
{
    public SceneButtonPair[] sceneButtonPairs;

    void Start()
    {
        // Assign button click events
        foreach (var pair in sceneButtonPairs)
        {
            pair.button.onClick.AddListener(() =>
            {
                OnButtonClick(pair.sceneName);
            });
        }
    }

    public void OnButtonClick(string sceneName)
    {
        // Save the button name in PlayerPrefs before loading the next scene
        PlayerPrefs.SetString("SelectedButton", sceneName);

        // Load the corresponding scene
        SceneManager.LoadScene(sceneName);
    }
}
