using UnityEngine;
using Newtonsoft.Json;

public class PlayerSetting : MonoBehaviour
{
    private const string SETTING = "SETTING";
    public static PlayerSetting Instance { get; private set; }
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
        _settingData = JsonConvert.DeserializeObject<SettingData>(PlayerPrefs.GetString(SETTING)) ?? new SettingData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetString(SETTING, JsonConvert.SerializeObject(_settingData));
    }

    public float GetSound()
    {
        return _settingData.Sound;
    }
    public void SetSound(float sound)
    {
        _settingData.Sound = sound;
        SaveData();
    }
    public float GetMusic()
    {
        return _settingData.Music;
    }
    public void SetMusic(float music)
    {
        _settingData.Music = music;
        SaveData();
    }
    public int GetGraphic()
    {
        return _settingData.Graphic;
    }
    public void SetGraphic(int graphic)
    {
        _settingData.Graphic = graphic;
        SaveData();
    }
    public int GetLanguage()
    {
        return _settingData.Language;
    }
    public void SetLanguage(int language)
    {
        _settingData.Language = language;
        SaveData();
    }
}
