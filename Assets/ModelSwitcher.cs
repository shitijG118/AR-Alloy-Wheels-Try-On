using UnityEngine;
using UnityEngine.UI;

public class ModelSwitcher : MonoBehaviour
{
    public GameObject[] wheelModels;
    public Button[] modelButtons;

    void Start()
    {
        // Assign button click events
        for (int i = 0; i < modelButtons.Length; i++)
        {
            int index = i; // Capture the current value of i
            modelButtons[i].onClick.AddListener(() => SwitchModel(index));
        }

        // Initially show the first model and hide others
        SwitchModel(0);
    }

    public void SwitchModel(int index)
    {
        for (int i = 0; i < wheelModels.Length; i++)
        {
            wheelModels[i].SetActive(i == index);
        }
    }
}
