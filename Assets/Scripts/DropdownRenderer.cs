using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownRenderer : MonoBehaviour
{
    public Dropdown dropdown;
    public DropdownField field;
    private List<string> _dropdownOptions;

    private static List<string> EnumToStringList<T>()
    {
        List<string> stringList = new List<string>();
        var enumNames = Enum.GetNames((typeof(T)));
        foreach (string enumName in enumNames)
        {
            stringList.Add(enumName);
        }

        return stringList;
    }

    private void Start()
    {
        InitialValue();
        InitialEvent();
    }

    private void InitialValue()
    {
        int dropdownValue = 0;
        dropdown.options.Clear();
        switch (field)
        {
            case DropdownField.Graphic:
            {
                _dropdownOptions = EnumToStringList<Graphic>();
                dropdownValue = PlayerSetting.Instance.GetGraphic();
                break;
            }
            case DropdownField.Language:
            {
                _dropdownOptions = EnumToStringList<Language>();
                dropdownValue = PlayerSetting.Instance.GetLanguage();
                break;
            }
            default:
            {
                return;
            }
        }

        foreach (var dropdownOption in _dropdownOptions)
        {
            var option = new Dropdown.OptionData(dropdownOption);
            dropdown.options.Add(option);
        }

        dropdown.value = dropdownValue;
    }

    private void InitialEvent()
    {
        dropdown.onValueChanged.AddListener((value) =>
        {
            switch (field)
            {
                case DropdownField.Graphic:
                {
                    PlayerSetting.Instance.SetGraphic(value);
                    break;
                }
                case DropdownField.Language:
                {
                    PlayerSetting.Instance.SetLanguage(value);
                    break;
                }
                default:
                {
                    return;
                }
            }
        });
    }
}