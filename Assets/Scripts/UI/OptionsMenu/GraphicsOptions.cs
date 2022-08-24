using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GraphicsOptions : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullscreenToggle, vSyncToggle;

    private Resolution[] _resolutions;
    private bool _fullscreen;

    private void Start ()
    {
        _resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new();

        int currentResolutionIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " X " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].EqualTo(Screen.currentResolution))
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.onValueChanged.AddListener(isOn =>
        {
            _fullscreen = isOn;
        });

        ReadGraphics();
    }

    private void ReadGraphics ()
    {
        _fullscreen = Screen.fullScreen;
        fullscreenToggle.isOn = _fullscreen;
        vSyncToggle.isOn = QualitySettings.vSyncCount != 0;
    }

    public void ApplyGraphics ()
    {
        QualitySettings.vSyncCount = vSyncToggle.isOn ? 1 : 0;
        Resolution resolution = _resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Screen.fullScreen = _fullscreen;
    }
}

static partial class Extensions
{
    public static bool EqualTo (this Resolution resolution, Resolution comparison)
    {
        return resolution.width == comparison.width && resolution.height == comparison.height;
    }
}