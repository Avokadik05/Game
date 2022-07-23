using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class SettingMenu : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _cm;
    [SerializeField]
    private Slider _sensSlider;

    float _maxSpeed;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
        
        if(_maxSpeed <= 0)
        {
            _cm.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 2f;
            _cm.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 2f;
            _sensSlider.value = 2f;
        }
        else
        {
            _cm.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = _maxSpeed;
            _cm.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = _maxSpeed;
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ExitSettings()
    {
        SceneManager.LoadScene("Level");
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("SensitivityPreference", _sensSlider.value);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;

        if (PlayerPrefs.HasKey("SensitivityPreference"))
        {
            _sensSlider.value = PlayerPrefs.GetFloat("SensitivityPreference");
            _maxSpeed = PlayerPrefs.GetFloat("SensitivityPreference");
        }
        else
        {
            _maxSpeed = 2f;
            _sensSlider.value = 2f;
        }
    }

    public void ChangeSensitivity()
    {
        _cm.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = _maxSpeed;
        _cm.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = _maxSpeed;

        _maxSpeed = _sensSlider.value;
    }
}