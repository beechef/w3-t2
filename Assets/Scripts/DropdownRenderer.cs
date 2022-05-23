using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DropdownRenderer : MonoBehaviour
{
    public Dropdown dropdown;
    public DropdownData dropDownData;
    private List<string> _dropdownOptions;
    void Start()
    {
        _dropdownOptions = dropDownData.options;
        dropdown.options.Clear();
        foreach (var dropdownOption in _dropdownOptions)
        {
            var option = new Dropdown.OptionData(dropdownOption);
            dropdown.options.Add(option);
        }
    }

    void Update()
    {
        
    }
}
