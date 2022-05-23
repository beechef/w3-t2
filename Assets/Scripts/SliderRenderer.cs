using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRenderer : MonoBehaviour
{
    public Slider slider;
    public SliderField field;

    private void Start()
    {
        InitialValue();
        InitialEvent();
    }

    private void InitialValue()
    {
        float sliderValue = 0;
        switch (field)
        {
            case SliderField.Sound:
            {
                sliderValue = PlayerSetting.Instance.GetSound();
                break;
            }
            case SliderField.Music:
            {
                sliderValue = PlayerSetting.Instance.GetMusic();
                break;
            }
            default:
            {
                return;
            }
        }

        slider.value = sliderValue;
    }

    private void InitialEvent()
    {
        slider.onValueChanged.AddListener((value) =>
        {
            switch (field)
            {
                case SliderField.Sound:
                {
                    PlayerSetting.Instance.SetSound(value);
                    break;
                }
                case SliderField.Music:
                {
                    PlayerSetting.Instance.SetMusic(value);
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