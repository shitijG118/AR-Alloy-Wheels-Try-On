using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Pair
{
    public GameObject left;
    public GameObject right;
}
public class PairWheelSwitch : MonoBehaviour
{
    public Pair[] wheelModels;
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
            wheelModels[i].left.SetActive(i == index);
            wheelModels[i].right.SetActive(i == index);
        }
    }
}
