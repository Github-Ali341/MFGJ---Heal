using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] private Slider masterVS;
    [SerializeField] private Slider sfxVS;
    [SerializeField] private Slider musicVS;
    [SerializeField] private AudioMixer mixer;

    private const float VOLUME_MIN = -25;
    private const float VOLUME_MAX = 40;

    private void Awake ()
    {
        SetupVolumeSlider(musicVS, "MusicVol");
        SetupVolumeSlider(masterVS, "MasterVol");
        SetupVolumeSlider(sfxVS, "SFXVol");
    }

    private void SetupVolumeSlider (Slider vs, string paramName)
    {
        vs.onValueChanged.AddListener(volume =>
        {
            float value = Mathf.Lerp(VOLUME_MIN, VOLUME_MAX, volume);
            mixer.SetFloat(paramName, value);
        });
    }
}
