using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicManager : PersistentSingleton<MusicManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float timeBetweenClips;

    private int _index = -1;

    private IEnumerator Start ()
    {
        while (true)
        {
            // This returns next index, and if there isn't a next index then 0.
            _index = (_index + 1) % audioClips.Length;

            audioSource.clip = audioClips[_index];
            audioSource.Play();
            yield return new WaitForSecondsRealtime(audioClips[_index].length + timeBetweenClips);
        }
    }
}