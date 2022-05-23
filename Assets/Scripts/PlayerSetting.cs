using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class PlayerSetting : MonoBehaviour
{
    public static PlayerSetting Instance { get; private set; }

    public Slider sound;
    public Slider music;
    public Dropdown graphic;
    public Dropdown language;

    private SettingData _settingData;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Just only one Instance!");
            return;
        }

        Instance = this;
        LoadData();
    }

    private void LoadData()
    {
        _settingData = JsonConvert.DeserializeObject<SettingData>(PlayerPrefs.GetString("setting"));
        if (_settingData != null)
        {
            sound.value = _settingData.sound;
            music.value = _settingData.music;
            graphic.value = _settingData.graphic;
            language.value = _settingData.language;
        }
        else
        {
            _settingData = new SettingData();
        }
    }

    private void SaveData()
    {
        PlayerPrefs.SetString("setting", JsonConvert.SerializeObject(_settingData));
    }

    public void SetSound(float sound)
    {
        _settingData.sound = sound;
        SaveData();
    }
    public void SetMusic(float music)
    {
        _settingData.music = music;
        SaveData();
    }

    public void SetGraphic(int graphic)
    {
        _settingData.graphic = graphic;
        SaveData();
    }
    public void SetLanguage(int language)
    {
        _settingData.language = language;
        SaveData();
    }
}
