using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;  // Reference to your TMP_Dropdown
    public GameObject buttonPrefab;  // Prefab of the button to use as an option

    void Start()
    {
        // Clear existing options
        dropdown.ClearOptions();

        // Add new options
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>
        {
            new TMP_Dropdown.OptionData("Option 1"),
            new TMP_Dropdown.OptionData("Option 2"),
            new TMP_Dropdown.OptionData("Option 3")
        };

        dropdown.AddOptions(options);

        // Customize the options
        CustomizeDropdownOptions();
    }

    void CustomizeDropdownOptions()
    {
        Transform template = dropdown.template;

        for (int i = 0; i < dropdown.options.Count; i++)
        {
            // Find the item template
            Transform item = template.GetChild(0).GetChild(i);

            // Destroy existing TextMeshProUGUI component
            Destroy(item.GetComponent<TextMeshProUGUI>());

            // Instantiate and setup button
            GameObject button = Instantiate(buttonPrefab, item);
            button.GetComponentInChildren<TextMeshProUGUI>().text = dropdown.options[i].text;

            // Optionally add button click listener
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => OnOptionSelected(index));
        }
    }

    void OnOptionSelected(int index)
    {
        // Handle button click
        Debug.Log("Selected option: " + dropdown.options[index].text);
    }
}
