using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameVolumeInitializer : MonoBehaviour
{
    [SerializeField] private Slider masterVS;
    [SerializeField] private Slider sfxVS;
    [SerializeField] private Slider musicVS;
    [SerializeField] private AudioMixer mixer;

    private const float VOLUME_MIN = -25;
    private const float VOLUME_MAX = 40;

    private void Awake ()
    {
        SetVolume(musicVS, "MusicVol");
        SetVolume(masterVS, "MasterVol");
        SetVolume(sfxVS, "SFXVol");
    }

    private void SetVolume (Slider s, string paramName)
    {
        mixer.SetFloat(paramName, Mathf.Lerp(VOLUME_MIN, VOLUME_MAX, s.value));
    }
}
