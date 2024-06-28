using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ButtonRow
{
    public Button[] buttons;
}

public class ModelTargetSwitch : MonoBehaviour
{
    public GameObject[] modelTargets;
    public Button[] modelTargetButtons;
    public ButtonRow[] uiButtonRows; // Using the wrapper class

    void Start()
    {
        // Assign button click events for model targets
        for (int i = 0; i < modelTargetButtons.Length; i++)
        {
            int index = i; // Capture the current value of i
            modelTargetButtons[i].onClick.AddListener(() =>
            {
                SwitchModel(index);
                EnableUIButtons(index);
                DisableAllExceptRow(index);
            });
        }

        // Initially show the first model and hide others
        SwitchModel(0);
        EnableUIButtons(0);
        DisableAllExceptRow(0);
    }

    public void SwitchModel(int index)
    {
        for (int i = 0; i < modelTargets.Length; i++)
        {
            modelTargets[i].SetActive(i == index);
        }
    }

    public void EnableUIButtons(int rowIndex)
    {
        // Ensure rowIndex is within bounds
        if (rowIndex < 0 || rowIndex >= uiButtonRows.Length)
        {
            Debug.LogError("Row index is out of bounds.");
            return;
        }

        for (int col = 0; col < uiButtonRows[rowIndex].buttons.Length; col++)
        {
            uiButtonRows[rowIndex].buttons[col].interactable = true;
        }
    }

    public void DisableAllExceptRow(int rowIndex)
    {
        // Ensure rowIndex is within bounds
        if (rowIndex < 0 || rowIndex >= uiButtonRows.Length)
        {
            Debug.LogError("Row index is out of bounds.");
            return;
        }

        for (int row = 0; row < uiButtonRows.Length; row++)
        {
            if (row != rowIndex)
            {
                for (int col = 0; col < uiButtonRows[row].buttons.Length; col++)
                {
                    uiButtonRows[row].buttons[col].interactable = false;
                }
            }
        }
    }
}
