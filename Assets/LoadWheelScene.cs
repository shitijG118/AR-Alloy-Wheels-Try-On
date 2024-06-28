using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadWheelScene : MonoBehaviour
{
    public void OnButtonClick()
    {
        // Save the button name in PlayerPrefs before loading the next scene
        PlayerPrefs.SetString("SelectedButton", gameObject.name);

        // Load the next scene
        SceneManager.LoadScene("AlloyChangeWheel");
    }
}
